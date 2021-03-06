using ProductivityInside.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace ProductivityInside
{
    public sealed partial class ValutesPage : Page
    {
        public ValutesPage()
        {
            this.InitializeComponent();

            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = "Список валют";

            for (int i = 0; i < MainPage.valutes.Count; i++)
            {
                MainPage.valutes[i].IsSelected = ' ';
            }

            MainPage.valutes.First(v => v.CharCode == MainPage.chengedValuteCode).IsSelected = '\u2713';

            lbValutes.ItemsSource = MainPage.valutes;
        }

        private void lbValutes_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var selectedCode = lbValutes.SelectedItem.ToString();
            var selectedValute = MainPage.valutes.First(v => v.CharCode == selectedCode);

            if (MainPage.isLeftButtonPressed)
            {
                MainPage.leftValute = selectedValute;
            }
            else
            {
                MainPage.rightValute = selectedValute;
            }

            Frame.Navigate(typeof(ConverterPage));
        }
    }
}