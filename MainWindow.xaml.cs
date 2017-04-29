using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LabCanvas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         }

        public void DrawRectangle (double left, double top)
        {
            Rectangle rect = new Rectangle();
            rect.Width = 70;
            rect.Height = 50;
            rect.Fill = Brushes.Gold;

            DrawCanvas.Children.Add(rect);
            Canvas.SetLeft(rect, left);
            Canvas.SetTop(rect, top);
        }

        private void DrawPattern_Click(object sender, RoutedEventArgs e)
        {
            int k = 5;
            int top = 30;
            for(int i = 0; i < 5; i++)
            {
                int left = 400;
                for (int j = 0; j < k; j++)
                {
                    DrawRectangle(left, top);
                    left -= 80;
                }
                top += 60;
                k--;
            }
        }

        private void Dictionary_Click(object sender, RoutedEventArgs e)
        {
            OutputText.Text = "";
            Dictionary<string, string> states = new Dictionary<string, string>{
                {"Utah", "Salt Lake City"},
                {"Alaska", "Juneau"},
                {"Washington", "Seattle"},
                {"Oregon", "Salem"},
                {"California", "Sacramento"}};

            states["Hawaii"] = "Honolulu";
            states["Washington"] = "Olympia";

            bool contains = states.ContainsValue("Frankfort");
            foreach(KeyValuePair<string, string> state in states)
                OutputText.Text += string.Format("{0,-12} {1} \n", state.Key, state.Value);

            OutputText.Text += (contains ? "\nFrankfort has been entered." : "\nFrankfort has not been entered.");
        }

    }
}
