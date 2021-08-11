using ProductivityInside.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class ConverterPage : Page
    {
        public ConverterPage()
        {
            this.InitializeComponent();

            leftButton.Content = MainPage.leftValute.CharCode;
            leftTBox.Text = "1";
            leftTBox.SelectionStart = leftTBox.Text.Length;

            rightButton.Content = MainPage.rightValute.CharCode;
            rightTBox.Text = Math.Round(MainPage.leftValute.GetCost() / MainPage.rightValute.GetCost(), 2).ToString();
            rightTBox.SelectionStart = rightTBox.Text.Length;

            updateButton.Content = $"Дата обновления {MainPage.currentDate:dd.MM.yyyy HH:mm}";
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.isLeftButtonPressed = true;
            MainPage.chengedValuteCode = leftButton.Content.ToString();
            Frame.Navigate(typeof(ValutesPage));
        }

        private void leftTBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void leftTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (leftTBox.Text != "")
            {
                MainPage.leftAmount = Convert.ToDouble(leftTBox.Text);

                double result = Math.Round(MainPage.leftAmount * (MainPage.leftValute.GetCost() / MainPage.rightValute.GetCost()), 2);

                rightTBox.Text = result.ToString();
            }
            else
            {
                rightTBox.Text = "";
            }
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.isLeftButtonPressed = false;
            MainPage.chengedValuteCode = rightButton.Content.ToString();
            Frame.Navigate(typeof(ValutesPage));
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
