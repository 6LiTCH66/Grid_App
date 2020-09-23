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
        Button btn, btn1;
        BoxView box;
        public KrestO()
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
                    box = new BoxView
                    {
                        Color = Color.FromRgb(200, 100, 50)
                    };

                    grid.Children.Add(box, i, j);
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    box.GestureRecognizers.Add(tap);
                }
            }
            btn = new Button()
            {
                Text = "Reset the Game!",
            };
            btn.Clicked += Btn_Clicked;

            btn1 = new Button()
            {
                Text = "Test",
            };

            StackLayout stackLayout = new StackLayout()
            {
                Children = {grid, btn, btn1}
            };
            Content = stackLayout;
        }

        

        int tp = 0;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            BoxView box = sender as BoxView;

            tp++;
            
            if (tp == 1)
            {
                box.Color = Color.Black;
            }
            else if(tp == 3)
            {
                box.Color = Color.White;
                tp = 0;
            }
        }
        private void Btn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}