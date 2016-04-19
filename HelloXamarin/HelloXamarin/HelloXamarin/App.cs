using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HelloXamarin
{
    public class App : Application
    {
        private Entry syötekenttä;
        private Label arvauksenTulosLabel;

        private int oikeaLuku;

        public App()
        {
            Random rnd = new Random();
            oikeaLuku = rnd.Next(1, 21);

            // painonapin alustus
            Button arvaaNappi = new Button();
            arvaaNappi.Text = "Arvaa";
            arvaaNappi.Clicked += ArvaaNappi_Clicked;

            syötekenttä = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Text = ""
            };

            arvauksenTulosLabel = new Label();
            arvauksenTulosLabel.Text = "";

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    //VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Arvaa luku -peli",
                            TextColor = Color.Yellow
                        },
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Sovellusversio 0.10",
                            TextColor = Color.Silver
                        },
                        syötekenttä,
                        arvaaNappi,
                        arvauksenTulosLabel
                    }
                }
            };
        }

        private void ArvaaNappi_Clicked(object sender, EventArgs e)
        {
            int arvaus = int.Parse(syötekenttä.Text);
            if (arvaus < oikeaLuku)
            {
                arvauksenTulosLabel.Text = "Luku on suurempi.";
            }
            else if (arvaus > oikeaLuku)
            {
                arvauksenTulosLabel.Text = "Luku on pienempi.";
            }
            else if (arvaus == oikeaLuku)
            {
                arvauksenTulosLabel.Text = "Jee! Täsmälleen oikein!";
                Random rnd = new Random();
                oikeaLuku = rnd.Next(1, 21);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
