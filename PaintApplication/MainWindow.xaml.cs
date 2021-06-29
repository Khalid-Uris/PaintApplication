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

namespace PaintApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int diameter = (int)Sizes.MEDIUM;        // set diameter of circle 
        private Brush brushColor = Brushes.Black;         // set the drawing color 
        private bool shouldErase = false; // specify whether to erase 
        private bool shouldPaint = false; // specify whether to paint

        private enum Sizes// size constants for diameter of the circle 
        { 
            SMALL = 4,
            MEDIUM = 15, 
            LARGE = 30 
        }


    public MainWindow()
        {
            InitializeComponent();
        }

        private void PaintCircle(Brush circleColor, Point position)
        {
            Ellipse newEllipse = new Ellipse(); // create an Ellipse
            newEllipse.Fill = circleColor; // set Ellipse's color 
            newEllipse.Width = diameter; // set its horizontal diameter 
            newEllipse.Height = diameter; // set its vertical diameter
                                          // set the Ellipse's position 
            Canvas.SetTop(newEllipse, position.Y);
            Canvas.SetLeft(newEllipse, position.X);
            paintCanvas.Children.Add(newEllipse);
        } // end method


        private void paintCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (shouldPaint)
            {
                Point mousePosition = e.GetPosition(paintCanvas);
                PaintCircle(brushColor, mousePosition);
            }

            if (shouldErase)
            {
                Point mousePosition = e.GetPosition(paintCanvas);
                PaintCircle(paintCanvas.Background, mousePosition);
            }
        }

        private void paintCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            shouldPaint = true;
        }

        private void paintCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            shouldPaint = false;
        }

        private void paintCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            shouldErase = true;
        }

        private void paintCanvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            shouldErase = false;
        }

        private void redRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Red;
        }

        private void blueRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Blue;
        }

        private void greenRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Green;
        }

        private void blackRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Black;
        }

        private void smallRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.SMALL;
        }

        private void MediumRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.MEDIUM;
        }

        private void largelRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.LARGE;
        }

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            int count = paintCanvas.Children.Count;
            // if there are any shapes on Canvas remove the last one added 
            if (count > 0)
                paintCanvas.Children.RemoveAt(count - 1);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            paintCanvas.Children.Clear();
        }
    }
}

    

