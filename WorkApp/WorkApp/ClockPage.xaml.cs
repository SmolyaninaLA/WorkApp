using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClockPage : ContentPage
    {
        public ClockPage()
        {
            InitializeComponent();
            AlarmClock();
        }

        public void AlarmClock()
        {
           

            var datePicker = new DatePicker
            {
                Format = "D",

                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7),
            };

            var datePickerText = new Label { Text = "Дата запуска ", Margin = new Thickness(40, 20, 0, 0) };

            stackLayout.Children.Add(datePickerText);
            stackLayout.Children.Add(datePicker);
            
            var timePickerText = new Label { Text = "Время запуска ", Margin = new Thickness(40, 20, 0, 0) };
            var timePicker = new TimePicker
            {
                Time = new TimeSpan(13, 0, 0)
            };

            stackLayout.Children.Add(timePickerText);
            stackLayout.Children.Add(timePicker);

            Slider slider = new Slider
            {
                Minimum = 0,
                Maximum = 50,
                Value = 15.0,
                ThumbColor = Color.DodgerBlue,
                MinimumTrackColor = Color.DodgerBlue,
                MaximumTrackColor = Color.Gray
            };

            var sliderText = new Label { Text = $"Громкость сигнала: {slider.Value} ", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(40, 30, 0, 0) };

            stackLayout.Children.Add(sliderText);
            stackLayout.Children.Add(slider);

            var switchHeader = new Label { Text = "Каждый день", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(40, 5, 0, 0) };
            stackLayout.Children.Add(switchHeader);

            Switch switchControl = new Switch
            {
                IsToggled = false,
                HorizontalOptions = LayoutOptions.Center,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue,
            };
            stackLayout.Children.Add(switchControl);

            Button buttonSave = new Button
            {
                Text = "Сохранить",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            stackLayout.Children.Add(buttonSave);

            Button buttonReturn = new Button
            {
                Text = "На главную",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            stackLayout.Children.Add(buttonReturn);

            timePicker.PropertyChanged += (sender, e) => TimeChangedHandler(sender, e, timePickerText, timePicker);
            datePicker.DateSelected += (sender, e) => DateSelectedHandler(sender, e, datePickerText);
            slider.ValueChanged += (sender, e) => VolumeChangedHandler(sender, e, sliderText);
            buttonSave.Clicked += (sender, e) =>  Save_Click(sender,e,datePickerText,timePickerText);
            buttonReturn.Clicked += Return_Click;

        }

        public void DateSelectedHandler(object sender, DateChangedEventArgs e, Label datePickerText)
        {
           
            datePickerText.Text = "Дата запуска " + e.NewDate.ToString("dd/MM/yyyy");
        }

        public void TimeChangedHandler(object sender, PropertyChangedEventArgs e, Label timePickerText, TimePicker timePicker)
        {
            
            if (e.PropertyName == "Time")
                timePickerText.Text = "Время запуска " + timePicker.Time;
        }

        public void VolumeChangedHandler(object sender, ValueChangedEventArgs e, Label header)
        {
            header.Text = String.Format("Громкость: {0}", e.NewValue);
        }

        public void Save_Click(object sender, EventArgs e, Label dt, Label tm)
        {
            var str = "Будильник установлен : " + dt.Text + " , " + tm.Text;
            DisplayAlert("Внимание", str , "OK");
        }

        private async void Return_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}