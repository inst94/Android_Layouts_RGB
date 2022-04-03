using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Layouts_App
{
    public partial class MainPage : ContentPage
    {
        Button Box_btn, Ent_btn, Timer_btn, Date_btn, Sld_btn, Frame_btn, Image_btn, Rgb_btn;
        public MainPage()
        {
            Box_btn = new Button
            {
                Text = "BoxView",
                BackgroundColor = Color.Red
            };
            Ent_btn = new Button
            {
                Text = "Entry",
                BackgroundColor = Color.Fuchsia
            };
            Timer_btn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.Fuchsia
            };
            Date_btn = new Button
            {
                Text = "Date/Time",
                BackgroundColor = Color.FloralWhite
            };
            Sld_btn = new Button
            {
                Text = "Slider/Stepper",
                BackgroundColor = Color.RosyBrown
            };
            Frame_btn = new Button
            {
                Text = "Frame",
                BackgroundColor = Color.LightPink
            };
            Image_btn = new Button
            {
                Text = "Image",
                BackgroundColor = Color.GreenYellow
            };
            Rgb_btn = new Button
            {
                Text = "RGB Color Sliders"
            };
            StackLayout st = new StackLayout
            {
                Children = { Box_btn, Ent_btn, Timer_btn, Date_btn, Sld_btn, Frame_btn, Image_btn, Rgb_btn }
            };
            st.BackgroundColor = Color.Aqua;
            Content = st;

            Ent_btn.Clicked += Start_Pages;
            Timer_btn.Clicked += Start_Pages;
            Box_btn.Clicked += Start_Pages;
            Date_btn.Clicked += Start_Pages;
            Sld_btn.Clicked += Start_Pages;
            Frame_btn.Clicked += Start_Pages;
            Image_btn.Clicked += Start_Pages;
            Rgb_btn.Clicked += Start_Pages;
        }
        private async void Start_Pages(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (sender== Date_btn)
            {
                await Navigation.PushAsync(new Date_Page());
            }
            else if(sender== Box_btn)
            {
                await Navigation.PushAsync(new BoxPage());
            }
            else if (sender== Timer_btn)
            {
                await Navigation.PushAsync(new Timer_Page());
            }
            else if (sender == Ent_btn)
            {
                await Navigation.PushAsync(new Entry_Page());
            }
            else if (sender == Sld_btn)
            {
                await Navigation.PushAsync(new StepperSlider_Page());
            }
            else if (sender == Frame_btn)
            {
                await Navigation.PushAsync(new Frame_Page());
            }
            else if (sender == Image_btn)
            {
                await Navigation.PushAsync(new Image_Page());
            }
            else if (sender == Rgb_btn)
            {
                await Navigation.PushAsync(new RGB());
            }
        }
    }
}
