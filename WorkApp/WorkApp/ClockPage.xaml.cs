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
           
        }
       
        public void DateSelectedHandler(object sender, DateChangedEventArgs e)
        {
           if (e.NewDate >= DateTime.Today )
            {
                VisualStateManager.GoToState(datePicker, "Valid");
            }
           else
            {
                VisualStateManager.GoToState(datePicker, "Invalid");
            }
            datePickerText.Text = "Дата запуска " + e.NewDate.ToString("dd/MM/yyyy");
        }

        
        public void TimeChangedHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "Time")
            {
                if (datePicker.Date > DateTime.Today)
                {
                    VisualStateManager.GoToState(timePicker, "Valid");
                }
                else
                    if (datePicker.Date == DateTime.Today)
                    {
                        DateTime dt = datePicker.Date + timePicker.Time;
                        var comp = dt.CompareTo(DateTime.Now);
                        if (comp < 0)
                        {
                            VisualStateManager.GoToState(timePicker, "Invalid");
                        }
                        else
                        {
                            VisualStateManager.GoToState(timePicker, "Valid");
                        }

                    }
                    else
                    {
                        VisualStateManager.GoToState(timePicker, "Invalid");
                    }
                timePickerText.Text = "Время запуска " + timePicker.Time;
            }
                

        }

        
        public void VolumeChangedHandler(object sender, ValueChangedEventArgs e )
        {
           
            sliderText.Text = string.Format("Громкость: {0}", e.NewValue);
        }

        
        public void Save_Click(object sender, EventArgs e)
        {
           
            var str = "Будильник установлен : " + datePickerText.Text + " , " + timePickerText.Text;
            DisplayAlert("Внимание", str , "OK");
           
            var controls = new View[] { datePicker, timePicker , sliderVolume , switchEveryDay };
            ButtonChangeProperty(controls);

        }

        private void ButtonChangeProperty( View[] views)
        {
            foreach (var view in views)
                view.IsEnabled = false;
        } 

        private async void Return_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}