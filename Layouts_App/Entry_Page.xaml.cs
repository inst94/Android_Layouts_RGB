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
    public partial class Entry_Page : ContentPage
    {
        Editor ed;
        Label lb;
        public Entry_Page()
        {
            ed = new Editor
            {
                Placeholder = "Sisesta siis teksti",
                BackgroundColor = Color.White,
                TextColor = Color.Red,
                Keyboard=Keyboard.Email
            };
            ed.TextChanged += Ed_TextChanged;
            lb = new Label
            {
                Text = "Mingi tekst",
                TextColor = Color.Orange
            };
            Button tagasi = new Button
            { Text = "Tagasi" };
            tagasi.Clicked += Tagasi_Clicked;
            StackLayout st = new StackLayout
            { Children = { ed, lb, tagasi } };
            st.BackgroundColor = Color.Aqua;
            Content = st;
        }

        private async void Tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        int i = 0;
        private void Ed_TextChanged(object sender, TextChangedEventArgs e)
        {
            ed.TextChanged -= Ed_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';
            if(key=='A')
            {
                i++;
                lb.Text = key.ToString() + ": " + i;
            }
            ed.TextChanged += Ed_TextChanged;
        }
    }
}