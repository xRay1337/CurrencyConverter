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
        CbrResponse cbrResponse;

        DateTime currentDate;

        List<Valute> valutes;
        
        public MainPage()
        {
            this.InitializeComponent();

            cbrResponse = LoadData();
            currentDate = cbrResponse.Date;
            valutes = cbrResponse.Valute.Values.ToList();


            //new MessageDialog(valutes.Count.ToString()).ShowAsync();
        }

        public CbrResponse LoadData()
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

                return cbrResponse;
            }
            catch (WebException ex)
            {
                throw;
            }
            catch (IOException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ConverterPage), cbrResponse);
        }
    }
}