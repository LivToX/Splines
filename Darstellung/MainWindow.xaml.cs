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
            DrawAxes();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Check if Click auf selber stelle wie anderer Punkt
            if (CheckIfStelleBelegt())
                return;

            MyCanvas.Children.Clear();
            ReDrawPoints();
            DrawAxes();

            //Füge punkt in Liste hinzu
            Controller.AddPunkt(Mouse.GetPosition(MyCanvas).X, Mouse.GetPosition(MyCanvas).Y);

            //Punkte Darstellung
            AddPoint();

            //Zeichne Kurve
            DrawFunction();
        }
        private bool CheckIfStelleBelegt()
        {
            StelleBelegt stelleBelegt = new StelleBelegt();
            
            if (Controller.punkte is not null)
                for (int i = 0; i < Controller.punkte.Count; i++)
                    if (Mouse.GetPosition(MyCanvas).X == Controller.punkte[i].x)
                    {
                        stelleBelegt.Show();
                        return true;
                    }
            return false;
        }

        private void DrawAxes()
        {
            //X
            for (int i = 0; i <= 8; i++)
            {
                Line lineX = new Line()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    X1 = i * 100,
                    Y1 = 596,
                    X2 = i * 100,
                    Y2 = 604
                };
                MyCanvas.Children.Add(lineX);
            }
            Line x = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                X1 = 0,
                Y1 = 600,
                X2 = 800,
                Y2 = 600
            };
            MyCanvas.Children.Add(x);

            //Y
            for (int i = 0; i <= 7; i++)
            {
                Line lineY = new Line()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    X1 = -4,
                    Y1 = i * 100,
                    X2 = 4,
                    Y2 = i * 100
                };
                MyCanvas.Children.Add(lineY);
            }
            Line y = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = 600
            };
            MyCanvas.Children.Add(y);
        }

        private void ReDrawPoints()
        {
            //Controller.punkte
            for (int i = 0; i < Controller.punkte.Count; i++)
            {
                Ellipse ellipse = new Ellipse()
                {
                    Fill = Brushes.Blue,
                    Height = 5,
                    Width = 5
                };
                Canvas.SetLeft(ellipse, Controller.punkte[i].x - 2.5);
                Canvas.SetTop(ellipse, KoordinatenRechner.KoordinatenUmrechnen(Controller.punkte[i].y) - 2.5);
                MyCanvas.Children.Add(ellipse);
            }
        }

        private void AddPoint()
        {
            Ellipse ellipse = new Ellipse()
            {
                Fill = Brushes.Red,
                Height = 5,
                Width = 5
            };
            Canvas.SetLeft(ellipse, Mouse.GetPosition(MyCanvas).X - 2);
            Canvas.SetTop(ellipse, Mouse.GetPosition(MyCanvas).Y - 2);
            MyCanvas.Children.Add(ellipse);
        }

        private void DrawFunction()
        {
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
