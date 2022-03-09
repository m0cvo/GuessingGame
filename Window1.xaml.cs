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
    {   //introduce some global variables for use later
        int guess = 0;
        int guesses = 0;
        int rGuesses = 5;

        //instigate the random class
        Random R = new Random();
        int r = 0;
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
            try
            {
                //generate a random number as an int32 element
                if (r == 0)
                { r = R.Next(1, 9); }

                //Check that input is of correct format
                bool isNumeric = int.TryParse(GuessBox.Text, out int n);
                if (isNumeric == false)
                {
                    MessageBox.Show("please enter a numerical integer value only!");
                    GuessBox.Text = "";
                }
                else
                {
                    //take the users guess and compare it to the random number
                    guess = int.Parse(GuessBox.Text);
                    if (guess == r)
                    {
                        Window2 window2 = new Window2();
                        window2.Show();
                        this.Close();
                    }
                    else { tryAgain(); }
                }
            }
            catch (FormatException Fe)
            {
                MessageBox.Show("Numerical Integer between 1 and 9 please");
            }
            catch(IndexOutOfRangeException ie)
            {
                MessageBox.Show("between 1 and 9 only");
            }
            
        }
        
        private void tryAgain()
        {
            //see how many guesses the user has left
            guesses += 1;
            rGuesses -= 1;
            NumGuessBox.Text = guesses.ToString();
            RGuessBox.Text = rGuesses.ToString();
            //if all guesses have been used..
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
