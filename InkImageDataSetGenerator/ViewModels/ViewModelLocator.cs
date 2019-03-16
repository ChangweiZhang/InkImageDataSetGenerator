using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace InkImageDataSetGenerator.ViewModels
{
    public class ViewModelLocator : ViewModelBase
    {
        private static ViewModelLocator _instance;
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            _instance = this;
        }

        public MainViewModel Main
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }

        public static ViewModelLocator Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
