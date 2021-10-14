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
    public partial class WeatherPage : ContentPage
    {
        Label textLabel, textLabel1, textLabel2, textLabel3, textLabel4, textLabel5;
        public WeatherPage()
        {
            InitializeComponent();
            Weather();
        }

        public void Weather()
        {
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                }

            };
            BoxView redBox = new BoxView { Color = Color.Coral };
            BoxView blueBox = new BoxView { Color = Color.LightBlue };
            BoxView yellowBox = new BoxView { Color = Color.LightYellow };
            grid.Children.Add(redBox, 0, 0);
            grid.Children.Add(blueBox, 0, 1);
            grid.Children.Add(yellowBox, 0, 2);


            textLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = $"Утро",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center
            };
            grid.Children.Add(textLabel, 0, 0);

            textLabel1 = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = $" + 15 C",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            grid.Children.Add(textLabel1, 0, 0);

            textLabel2 = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = $"Вечер",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center
            };
            grid.Children.Add(textLabel2, 0, 1);

            textLabel3 = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = $" + 5 C",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            grid.Children.Add(textLabel3, 0, 1);

            textLabel4 = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = $"Атмосферное давление",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Center
            };
            grid.Children.Add(textLabel4, 0, 2);

            textLabel5 = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = $" 762 ММ ",
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            grid.Children.Add(textLabel5, 0, 2);

            Button buttonReturn = new Button
            {
                Text = "На главную",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand

            };

            grid.Children.Add(buttonReturn,0,2);
            buttonReturn.Clicked += Return_Click;

            Content = grid;
        }

        private async void Return_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}