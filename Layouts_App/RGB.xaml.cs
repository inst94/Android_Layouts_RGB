using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RGB : ContentPage
    {
        BoxView box;
        Label red_label, green_label, blue_label;
        Slider red_slider, green_slider, blue_slider;
        Random rnd;
        Button random_btn;
        public RGB()
        {
            box = new BoxView
            {
                Color = Color.Black,
                WidthRequest = 200,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            red_slider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Red,
            };
            red_label = new Label
            {
                Text = "Red",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            green_slider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Green,
                MaximumTrackColor = Color.Green,
            };
            green_label = new Label
            {
                Text = "Green",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            blue_slider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Blue,
                MaximumTrackColor = Color.Blue,
            };
            blue_label = new Label
            {
                Text = "Blue",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            random_btn = new Button
            {
                Text = "Generate random color"
            };
            red_slider.ValueChanged += Sld_ValueChanged;
            green_slider.ValueChanged += Sld_ValueChanged;
            blue_slider.ValueChanged += Sld_ValueChanged;
            random_btn.Clicked += Random_btn_Clicked;
            StackLayout st = new StackLayout
            {
                Children = { box, red_slider, red_label, green_slider, green_label, blue_slider, blue_label, random_btn }
            };
            Content = st;
        }

        private void Random_btn_Clicked(object sender, EventArgs e)
        {
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            red_label.Text = String.Format("Red = {0:X2}", Convert.ToInt32(rnd.Next(0, 255)).ToString());
            red_slider.Value = rnd.Next(0, 255);

            green_label.Text = String.Format("Green = {0:X2}", Convert.ToInt32(rnd.Next(0, 255)).ToString());
            green_slider.Value = rnd.Next(0, 255);

            blue_label.Text = String.Format("Blue = {0:X2}", Convert.ToInt32(rnd.Next(0, 255)).ToString());
            blue_slider.Value = rnd.Next(0, 255);

            random_btn.BackgroundColor = box.Color;
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == red_slider)
            {
                red_label.Text = String.Format("Red = {0:X2}", Convert.ToInt32(e.NewValue).ToString());
            }
            else if (sender == green_slider)
            {
                green_label.Text = String.Format("Green = {0:X2}", Convert.ToInt32(e.NewValue).ToString());
            }
            else if (sender == blue_slider)
            {
                blue_label.Text = String.Format("Blue = {0:X2}", Convert.ToInt32(e.NewValue).ToString());
            }
            box.Color = Color.FromRgb((int)red_slider.Value, (int)green_slider.Value, (int)blue_slider.Value);
        }
    }
}
