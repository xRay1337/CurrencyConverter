using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProductivityInside.Models;
using Newtonsoft.Json;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace ProductivityInside
{
    public sealed partial class MainPage : Page
    {
        public static CbrResponse cbrResponse;
        public static DateTime currentDate;
        public static List<Valute> valutes;

        public static Valute leftValute;
        public static double leftAmount;

        public static Valute rightValute;
        public static double rightAmount;

        public static bool isLeftButtonPressed;

        public static string chengedValuteCode;


        public MainPage()
        {
            this.InitializeComponent();

            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = "Загрузка данных";

            cbrResponse = LoadData();
            currentDate = cbrResponse.Date;
            valutes = cbrResponse.Valute.Values.ToList();

            valutes.Sort(delegate(Valute v1, Valute v2)
            {
                return v1.Name.CompareTo(v2.Name);
            });

            leftValute = valutes.First(v => v.CharCode == "USD");
            leftAmount = 1;

            rightValute = valutes.First(v => v.CharCode == "RUR");
            rightAmount = rightValute.GetCost();

            //new MessageDialog(MainPage.rightAmount.ToString()).ShowAsync();
        }

        public static CbrResponse LoadData()
        {
            try
            {
                var uri = new Uri("https://www.cbr-xml-daily.ru/daily_json.js");

                var request = WebRequest.Create(uri);

                var response = request.GetResponse();

                string jsonText;

                using (var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    jsonText = stream.ReadToEnd();
                }

                var cbrResponse = JsonConvert.DeserializeObject<CbrResponse>(jsonText);

                cbrResponse.Valute.Add("RUR", new Valute("RUR", "Российский рубль", 1, 1));

                return cbrResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ConverterPage));
        }
    }
}