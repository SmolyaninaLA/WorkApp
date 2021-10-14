using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommonPage : ContentPage
    {
        public CommonPage()
        {
            InitializeComponent();

        }

        private async void Weather_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeatherPage());
        }

        private async void Clock_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClockPage());
        }
    }
}