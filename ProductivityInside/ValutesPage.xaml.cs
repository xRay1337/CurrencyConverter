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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProductivityInside
{
    public sealed partial class ValutesPage : Page
    {
        string currentValute;
        string buttonName;
        List<Valute> valutes;

        public ValutesPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            object[] param = (object[])(e.Parameter);

            buttonName = (string)(param[0]);
            currentValute = (string)(param[1]);
            valutes = (List<Valute>)(param[2]);

            new MessageDialog(buttonName).ShowAsync();

            valutes.Sort(delegate(Valute v1, Valute v2)
             {
                 return v1.Name.CompareTo(v2.Name);
             });

            lbValutes.ItemsSource = valutes;
        }
    }
}