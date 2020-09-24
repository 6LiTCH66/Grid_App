using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grid_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KrestO : ContentPage
    {
        Button btn, btn1, btn2;
        BoxView box;
        Label lbl;
        Image img;
        Grid grid;
        void NewGame()
        {

            Grid grid = new Grid();
            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    img = new Image { Source = ImageSource.FromFile("nn.png") };

                    grid.Children.Add(img, i, j);
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    img.GestureRecognizers.Add(tap);
                }
            }


            btn = new Button()
            {
                Text = "Reset the Game!",
            };
            btn.Clicked += Btn_Clicked;


            btn1 = new Button()
            {
                FontSize = 24,
                Text = "X / 0",
            };
            btn1.Clicked += Btn1_Clicked;


            lbl = new Label()
            {
                Text = "",
                FontSize = 34,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };


            StackLayout stackLayout = new StackLayout()
            {
                BackgroundColor = Color.Blue,
                Children = { grid, btn, btn1, lbl }
            };
            Content = stackLayout;
        }
        public KrestO()
        {
            btn2 = new Button()
            {
                Text = "Start",
            };

            btn2.Clicked += Btn2_Clicked;

            StackLayout stackLayout = new StackLayout()
            {
                Children = { btn2 }
            };
            Content = stackLayout;

        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            btn2.IsVisible = false;
            NewGame();
        }

        

        int tp = 0;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            Image img1 = sender as Image;

            tp++;
            if (tp == 2)
            {
                img1.Source = ImageSource.FromFile("X.png");
                if (img1.Source  == img1.Source)
                {
                    img1.IsEnabled = false;
                }
            }
            else if(tp == 3)
            {
                img1.Source = ImageSource.FromFile("O.png");
                if (img1.Source == img1.Source)
                {
                    img1.IsEnabled = false;
                }
                tp = 0;
            }
        }
        private void Btn_Clicked(object sender, EventArgs e)  // button Reset the Game
        {
            NewGame();
            btn1.IsEnabled = true;
        }

        Random rnd = new Random();

        private void Btn1_Clicked(object sender, EventArgs e)
        {

            int rand = rnd.Next(1, 3);

            if (rand == 1)
            {
                lbl.Text = "X";
                tp = 1;
                
            }
            else if (rand == 2)
            {
                lbl.Text = "0";
                tp = 2;
            }
            btn1.IsEnabled = false;
        }
    }
}