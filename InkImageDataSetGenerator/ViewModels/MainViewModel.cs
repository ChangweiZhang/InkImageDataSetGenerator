using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OpenCvSharp;
using System;
using System.IO;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace InkImageDataSetGenerator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private int imageSize = 280;

        public int ImageSize
        {
            get { return imageSize; }
            set
            {
                imageSize = value;
                RaisePropertyChanged(nameof(ImageSize));
            }
        }

        private string label;

        public string Label
        {
            get { return label; }
            set
            {
                label = value;
                RaisePropertyChanged(nameof(MainViewModel));
            }
        }

        private string startAngle = "-60";

        public string StartAngle
        {
            get { return startAngle; }
            set
            {
                startAngle = value;
                RaisePropertyChanged(nameof(StartAngle));
            }
        }

        private string endAngle = "60";

        public string EndAngle
        {
            get { return endAngle; }
            set
            {
                endAngle = value;
                RaisePropertyChanged(nameof(EndAngle));
            }
        }


        private IRandomAccessStream currentInkImage;

        public IRandomAccessStream CurrentInkImage
        {
            get { return currentInkImage; }
            set { currentInkImage = value; }
        }

        private int amount = 1000;

        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                RaisePropertyChanged(nameof(Amount));
            }
        }
        private string imageFolder;

        public string ImageFolder
        {
            get { return imageFolder; }
            set
            {
                imageFolder = value;
                RaisePropertyChanged(nameof(ImageFolder));
            }
        }

        public RelayCommand<InkCanvas> GenerateImageCommand => new RelayCommand<InkCanvas>(GenerateImage);

        private async void GenerateImage(InkCanvas canvas)
        {

            var _startAngle = -60d;
            var _endAngle = 60d;
            if (double.TryParse(StartAngle, out _startAngle) && double.TryParse(EndAngle, out _endAngle))
            {
                var step = (_endAngle - _startAngle) / Amount;
                var rootFolder = await KnownFolders.PicturesLibrary.CreateFolderAsync("InkDataSet", CreationCollisionOption.OpenIfExists);
                ImageFolder = rootFolder.Path;
                StorageFolder labelFolder = null;
                try
                {
                    labelFolder = await rootFolder.GetFolderAsync(Label);
                }
                catch
                {
                    labelFolder = await rootFolder.CreateFolderAsync(Label);
                }
                for (int i = 0; i < Amount; i++)
                {
                    var file = await labelFolder.CreateFileAsync($"{i}.jpg", CreationCollisionOption.GenerateUniqueName);
                    using (var fs = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        var img = Mat.FromStream(CurrentInkImage.AsStream(), ImreadModes.AnyColor);
                        var m = Cv2.GetRotationMatrix2D(new Point2f(ImageSize / 2, ImageSize / 2), _startAngle + i * step, 1);
                        var dst = img.WarpAffine(m, img.Size());

                        using (var data = dst.ToMemoryStream().AsRandomAccessStream())
                        {
                            var decoder = await BitmapDecoder.CreateAsync(data);
                            var encoder = await BitmapEncoder.CreateForTranscodingAsync(fs, decoder);
                            await encoder.FlushAsync();
                            img.Release();
                            m.Release();
                            dst.Release();
                        }

                    }

                }
                await canvas.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    canvas.InkPresenter.StrokeContainer.Clear();
                });
            }
            else
            {
                await Windows.UI.Xaml.Window.Current.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {
                    await new MessageDialog("please input correct parameters").ShowAsync();
                });
            }
        }
    }
}
