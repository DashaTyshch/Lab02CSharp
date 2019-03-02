using Lab02Tyshchenko.Views;
using Lab02Tyshchenko.Windows;
using System;

namespace Lab02Tyshchenko.Model
{
    public enum ModesEnum
    {
        Main,
        Welcome
    }

    class NavigationModel
    {
        private ContentWindow _contentWindow;
        private MainView _mainView;
        private WelcomeView _welcomeView;

        public NavigationModel(ContentWindow contentWindow, Storage storage)
        {
            _contentWindow = contentWindow;
            _mainView = new MainView(storage);
            _welcomeView = new WelcomeView(storage);
        }

        public void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView;
                    break;
                case ModesEnum.Welcome:
                    _contentWindow.ContentControl.Content = _welcomeView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
