using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Date_Page : ContentPage
    {
        DatePicker dp;
        Label lbl;
        TimePicker tp;
        bool on_off = true;
        public Date_Page()
        {
            lbl = new Label
            {
                Text = "Vali mingi kuupäev",
                BackgroundColor = Color.BurlyWood
            };
            dp = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-5),
                MaximumDate = DateTime.Now.AddDays(5),
                TextColor = Color.Red
            };
            dp.DateSelected += Dp_DateSelected;
            tp = new TimePicker
            {
                Time = new TimeSpan(12, 0, 0)
            };
            tp.PropertyChanged += Tp_PropertyChanged;

            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = { lbl, dp, tp }
            };
            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1, 0.2, 200, 50));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(dp, new Rectangle(0.1, 0.5, 300, 50));
            AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(tp, new Rectangle(0.5, 0.7, 300, 50));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
        }
        private void timer_btn_Clicked(object sender, EventArgs e)
        {
            if (on_off)
            { on_off = false; }
            else
            {
                on_off = true;
                Timer_start();
            }
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            lbl.Text = "Oli valitud kuupäev: " + e.NewDate.ToString("G");
        }

        private void Tp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lbl.Text = "Oli valitud aeg: " + dp.Date.ToString("G") + tp.Time;
            Timer_start();
        }

        private async void Timer_start()
        {
            var time = (int)(tp.Time.TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds);
            while(time!=0)
            {
                await Task.Delay(1000);
                lbl.Text = time.ToString();
                time = (int)(tp.Time.TotalSeconds - DateTime.Now.TimeOfDay.TotalSeconds);
                if(time==0)
                {
                    lbl.BackgroundColor = Color.Red;
                    var dur = TimeSpan.FromSeconds(0.3);
                    Vibration.Vibrate(dur);
                    break;
                }
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            label.Text = "Vajutatud";
        }

        private async void tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}