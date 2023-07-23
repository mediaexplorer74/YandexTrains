// Main Page

using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using YandexTrains.DataProvider;
using YandexTrains.Utilities;


// YandexTrains namespace

namespace YandexTrains
{
    // MainPage class
    public sealed partial class MainPage : Page
    {
        private readonly Translator _translator;


        // MainPage
        public MainPage()
        {
            InitializeComponent();

            _translator = new Translator("MainPage");

            UtilitiyListBox.SelectedIndex = 0;
            
            MainContentFrame.Navigate(typeof(TripPlannerWindow));

        }//MainPage

        // OnPointerEnterMainSplitViewPane
        private void OnPointerEnterMainSplitViewPane(object sender, PointerRoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = true;
        }//OnPointerEnterMainSplitViewPane 


        // OnPointerExitMainSplitViewPane
        private void OnPointerExitMainSplitViewPane(object sender, PointerRoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = false;

        }//OnPointerExitMainSplitViewPane


        // OnUtilityListBoxChanged
        private void OnUtilityListBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TripPlannerListItem.IsSelected)
                MainContentFrame.Navigate(typeof(TripPlannerWindow));

            if (DeparturesListItem.IsSelected)
                MainContentFrame.Navigate(typeof(DeparturesWindow));

            if (SettingsListItem.IsSelected)
                MainContentFrame.Navigate(typeof(SettingsWindow), new Action(() => 
                {
                    // Translate sidebar whenever the language setting is modified
                    DeparturesText.Text = _translator["Departures.Text"];
                    TripPlannerText.Text = _translator["TripPlanner.Text"];
                    SettingsText.Text = _translator["Settings.Text"];
                }));
        }//OnUtilityListBoxChanged

    }//MainPage class end

}//YandexTrains namespace end
