// Settings Page

using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using YandexTrains.ViewModels;

// YandexTrains namespace
namespace YandexTrains
{
    // SettingsWindow class 
    public sealed partial class SettingsWindow : Page
    {
        private Action _translateMainPageSideBar;

        public SettingsViewModel Settings { get; set; }


        // SettingsWindow
        public SettingsWindow()
        {
            InitializeComponent();
        }//SettingsWindow


        // OnNavigatedTo
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _translateMainPageSideBar = e.Parameter as Action;
            Settings = new SettingsViewModel(_translateMainPageSideBar);
        }//OnNavigatedTo

    }//SettingsWindow class end

}//YandexTrains namespace end
