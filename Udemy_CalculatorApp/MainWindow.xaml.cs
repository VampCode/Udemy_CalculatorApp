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

        /// <summary>
        /// Click Event Handler for the Seven Button on the Calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sevenButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "7";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}7";
            }
        }
    }
}
