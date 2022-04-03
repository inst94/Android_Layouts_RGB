using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frame_Page : ContentPage
    {
        Label lbl;
        Frame fr;
        Grid gr;
        BoxView b;
        public Frame_Page()
        {
            lbl = new Label
            {
                Text = "Raami kujundus",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label))
            };
            gr = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(2,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}

                },
                ColumnDefinitions =
                {
                     new ColumnDefinition{Width=new GridLength(2,GridUnitType.Star)},
                     new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
                }
            };
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    b = new BoxView { Color = Color.White };
                    gr.Children.Add(b, c, r);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    b.GestureRecognizers.Add(tap);
                }
            }
            //gr.Children.Add(new BoxView { Color = Color.Blue }, 0, 0);
            //gr.Children.Add(new BoxView { Color = Color.Green }, 1, 0);
            //gr.Children.Add(new BoxView { Color = Color.Red }, 0, 1);
            //gr.Children.Add(new BoxView { Color = Color.YellowGreen }, 1, 1);
            //gr.Children.Add(new BoxView { Color = Color.Purple }, 0, 2);
            //gr.Children.Add(new BoxView { Color = Color.Pink }, 1, 2);

            fr = new Frame
            {
                Content=gr,
                BorderColor = Color.FromRgb(20, 120, 255),
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = { lbl, fr }
            };
            Content = st;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (BoxView)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            b.Color = Color.Black;
        }
    }
}