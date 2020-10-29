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
using System.Windows.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Crazy_Mouse_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random _random = new Random();
        int playerScore = 0;
        public static int xMouseLocation = 20;
        public static int yMouseLocation = 20;

        public MainWindow()
        {
            InitializeComponent();

            System.Threading.Thread crazyMouseThread = new System.Threading.Thread(new System.Threading.ThreadStart(CrazyMouseThread));
            crazyMouseThread.Start();

        }

        public void CrazyMouseThread()
        {

            int moveX = 0;
            int moveY = 0;

            while (true)
            {
                moveX = _random.Next(xMouseLocation) - (xMouseLocation / 2);
                moveX = _random.Next(yMouseLocation) - (yMouseLocation / 2);
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(System.Windows.Forms.Cursor.Position.X + moveX, System.Windows.Forms.Cursor.Position.Y + moveY);
                System.Threading.Thread.Sleep(50);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }
        private int increment = 0;
        private void dtTicker(object sender, EventArgs e)
        {
            increment++;

            TimerLabel.Content = increment.ToString();

            if (increment == 21)
            {
                Environment.Exit(0);
            }

            if(increment <= 21)
            {
                
            }


        }


        

       
        private void first_button_Click(object sender, RoutedEventArgs e)
        {
            if (xTheButton.Height == 20)
            {

                System.Windows.MessageBox.Show("Congrats You Win");
                Environment.Exit(0);


            }
            else
            {
                // this will be score, fix when done

                playerScore++;
                xMyScore.Text = playerScore.ToString();

                xMouseLocation = xMouseLocation + 2;
                yMouseLocation = yMouseLocation + 2;

                xTheButton.Height = xTheButton.Height - 5;
                xTheButton.Width = xTheButton.Width - 7;
            }

        }
        DispatcherTimer dt = new DispatcherTimer();
    }
}