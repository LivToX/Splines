using Splines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Darstellung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StelleBelegt stelleBelegt = new StelleBelegt();

            //Check if Click auf selber stelle wie anderer Punkt
            if (Controller.punkte is not null)
                for (int i = 0; i < Controller.punkte.Count; i++)
                    if (Mouse.GetPosition(MyCanvas).X == Controller.punkte[i].x)
                    {
                        stelleBelegt.Show();
                        return;
                    }

            //MyCanvas.Children.Clear();
            //Füge punkt in Liste hinzu
            Controller.AddPunkt(Mouse.GetPosition(MyCanvas).X, Mouse.GetPosition(MyCanvas).Y);

            Ellipse ellipse = new Ellipse()
            {
                Fill = Brushes.Black,
                Height = 4,
                Width = 4
            };

            //Punkte Darstellung
            Canvas.SetLeft(ellipse, Mouse.GetPosition(MyCanvas).X - 2);
            Canvas.SetTop(ellipse, Mouse.GetPosition(MyCanvas).Y - 2);
            MyCanvas.Children.Add(ellipse);

            //get zu ZeichnendePunkte  -> Darstellen
            if (Controller.punkte.Count > 3)
            {
                List<Punkt> zuZeichnen = Controller.GetZuZeichendePunkte();
                for (int i = 0; i < zuZeichnen.Count - 1; i++)
                {
                    Line line = new Line()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        X1 = zuZeichnen[i].x,
                        X2 = zuZeichnen[i + 1].x,
                        Y1 = zuZeichnen[i].y,
                        Y2 = zuZeichnen[i + 1].y
                    };

                    MyCanvas.Children.Add(line);
                }
            }
        }
    }
}
