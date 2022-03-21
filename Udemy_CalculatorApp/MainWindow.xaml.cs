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

namespace Udemy_CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Class variable definitions
        /// </summary>
        
        double lastNumber, result;


        public MainWindow()
        {
            InitializeComponent();
            

            // Event Handlers Defitions
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentButton.Click += PercentButton_Click;
            equalsButton.Click += EqualsButton_Click;
        }

        /// <summary>
        /// Click event handler for the Equals Button on the Calculator Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// Click Event Handler for the Percentage Button  on the calculator app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        /// <summary>
        /// Click Event Handler for the negative button on the calc app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        /// <summary>
        /// Click event handler for the AC button on the calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // saving the last number so we could do an operation on it
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                //resetting the label so the user can start typing the next number
                resultLabel.Content = "0";
            }
        }

        /// <summary>
        /// Click Event Handler for the Seven Button on the Calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            //need to evaluate what button has been presswed
            int selectedValue = 0;

            if(sender == zeroButton)
                selectedValue = 0;
            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }
}
