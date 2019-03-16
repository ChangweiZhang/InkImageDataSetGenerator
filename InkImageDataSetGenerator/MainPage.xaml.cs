using InkImageDataSetGenerator.ViewModels;
using Microsoft.Graphics.Canvas;
using System;
using System.Linq;
using Windows.AI.MachineLearning;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Media;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Input.Inking;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InkImageDataSetGenerator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            inkDataCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Touch | Windows.UI.Core.CoreInputDeviceTypes.Pen;
            var attr = new InkDrawingAttributes();
            attr.Color = Colors.White;
            attr.IgnorePressure = true;
            attr.PenTip = PenTipShape.Rectangle;
            attr.Size = new Size(10, 10);
            inkDataCanvas.InkPresenter.UpdateDefaultDrawingAttributes(attr);
            inkDataCanvas.InkPresenter.StrokesCollected += InkPresenter_StrokesCollected;
            //inkToolbar.InkDrawingAttributes.Color = Colors.White;
        }

        private async void InkPresenter_StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
        {
            CanvasDevice device = CanvasDevice.GetSharedDevice();
            CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (int)inkDataCanvas.ActualWidth, (int)inkDataCanvas.ActualHeight, 96);

            using (var ds = renderTarget.CreateDrawingSession())
            {
                ds.Clear(Colors.Black);
                ds.DrawInk(inkDataCanvas.InkPresenter.StrokeContainer.GetStrokes());
            }

            using (var ms = new InMemoryRandomAccessStream())
            {

                await renderTarget.SaveAsync(ms, CanvasBitmapFileFormat.Jpeg, 1);
                await ms.FlushAsync();
                var decoder = await BitmapDecoder.CreateAsync(ms);
                var img = await decoder.GetSoftwareBitmapAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore);

                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, ms);
                encoder.BitmapTransform.ScaledHeight = (uint)ViewModelLocator.Instance.Main.ImageSize;
                encoder.BitmapTransform.ScaledWidth = (uint)ViewModelLocator.Instance.Main.ImageSize;
                encoder.SetSoftwareBitmap(img);
                await encoder.FlushAsync();

                decoder = await BitmapDecoder.CreateAsync(ms);
                img = await decoder.GetSoftwareBitmapAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore);
                img = SoftwareBitmap.Convert(img, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore);

                var sbs = new SoftwareBitmapSource();
                await sbs.SetBitmapAsync(img);
                inkImage.Source = sbs;

                //var targetImage = new SoftwareBitmap(BitmapPixelFormat.Bgra8, img.PixelWidth, img.PixelHeight);
                // img.CopyTo(targetImage);
                ViewModelLocator.Instance.Main.CurrentInkImage = ms.CloneStream();
                ms.Dispose();
            }
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CanvasDevice device = CanvasDevice.GetSharedDevice();
            CanvasRenderTarget renderTarget = new CanvasRenderTarget(device, (int)inkDataCanvas.ActualWidth, (int)inkDataCanvas.ActualHeight, 96);

            using (var ds = renderTarget.CreateDrawingSession())
            {
                ds.Clear(Colors.Black);
                ds.DrawInk(inkDataCanvas.InkPresenter.StrokeContainer.GetStrokes());
            }

            using (var ms = new InMemoryRandomAccessStream())
            {

                await renderTarget.SaveAsync(ms, CanvasBitmapFileFormat.Jpeg, 1);
                await ms.FlushAsync();
                var decoder = await BitmapDecoder.CreateAsync(ms);
                var img = await decoder.GetSoftwareBitmapAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore);

                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, ms);
                encoder.BitmapTransform.ScaledHeight = 227;
                encoder.BitmapTransform.ScaledWidth = 227;
                encoder.SetSoftwareBitmap(img);
                await encoder.FlushAsync();

                decoder = await BitmapDecoder.CreateAsync(ms);
                img = await decoder.GetSoftwareBitmapAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore);
                img = SoftwareBitmap.Convert(img, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore);
                var model = await CustomGestureModel.CreateFromStreamAsync(await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///CustomGesture.onnx")));
                var output = await model.EvaluateAsync(new CustomGestureInput
                {
                    data = ImageFeatureValue.CreateFromVideoFrame(VideoFrame.CreateWithSoftwareBitmap(img))
                });

                if (output != null)
                {
                    var res = output.classLabel.GetAsVectorView().ToList();
                    var label = res.FirstOrDefault();
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                     {
                         await new MessageDialog(label).ShowAsync();
                     });
                }
            }
        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            inkDataCanvas.InkPresenter.StrokeContainer.Clear();
        }
    }
}
