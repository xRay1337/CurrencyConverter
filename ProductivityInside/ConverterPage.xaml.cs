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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProductivityInside
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ConverterPage : Page
    {
        CbrResponse cbrResponse;

        DateTime currentDate;

        List<Valute> valutes;

        string leftValute = "RUB";
        double leftValue = 1;

        string rightValute = "USD";
        double rightValue;

        public ConverterPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is CbrResponse)
            {
                cbrResponse = (CbrResponse)e.Parameter;

                currentDate = cbrResponse.Date;

                valutes = cbrResponse.Valute.Values.ToList();
                valutes.Add(new Valute("RUR", 1, "Российский рубль", 1));

                rightValue = Math.Round(valutes.FirstOrDefault(v => v.CharCode == "USD").Value, 2);
                rightTBox.Text = rightValue.ToString();

                leftTBox.SelectionStart = leftTBox.Text.Length;
            }
        }

        private void leftTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (leftTBox.Text != "")
            {
                double leftValue = Convert.ToDouble(leftTBox.Text);
                double rightValue = valutes.FirstOrDefault(v => v.CharCode == rightValute).Value;
                double result = leftValue * rightValue;

                rightTBox.Text = result.ToString();
            }
            else
            {
                rightTBox.Text = "0.00";
            }
        }

        private void leftTBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            object[] param = new object[3] { nameof(rightButton), rightButton.Content, valutes };

            Frame.Navigate(typeof(ValutesPage), param);
        }
    }
}
