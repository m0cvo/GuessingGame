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
using System.Windows.Shapes;

namespace GuessingGame
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int guess = 0;
        int guesses = 0;
        int rGuesses = 5;

        Random R = new Random();
        public Window1()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            guess = int.Parse(GuessBox.Text);
            int r = Guessed(rnd);
            if (guess == r)
            {
                Window2 window2 = new Window2();
                window2.Show();
                this.Close();
            }
            else { tryAgain(); }
            
        }

        public static int Guessed(Random rnd)
        {
            return rnd.Next(1, 9);
        }

        private void tryAgain()
        {
            guesses += 1;
            rGuesses -= 1;
            NumGuessBox.Text = guesses.ToString();
            RGuessBox.Text = rGuesses.ToString();
            if(rGuesses == 0)
            {
                Window3 window3 = new Window3();
                window3.Show();
                this.Close();
            }

            else
            {
                GuessBox.Text = "";
                Label1.Content = "Try Again!";
            }
            return;
        }
    }
}
