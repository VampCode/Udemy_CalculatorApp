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
        SelectedOperator selectedOperator; 

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
            //evaluate the selected operator and perform the appropiate operations

            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            { 
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }
            
        }

        /// <summary>
        /// Click Event Handler for the Percentage Button  on the calculator app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber; 

            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber ))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                resultLabel.Content = tempNumber.ToString();
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
            result = 0;
            lastNumber = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // saving the last number so we could do an operation on it
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                //resetting the label so the user can start typing the next number
                resultLabel.Content = "0";
            }

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == subtractButton)
                selectedOperator = SelectedOperator.Subtraction;
            if(sender == addButton)
                selectedOperator = SelectedOperator.Addition;
        }

        private void decimalButton_Click(object sender, RoutedEventArgs e)
        {
            //if the resultLabel does not contain a decimal then we want to add one
            if(!resultLabel.Content.ToString().Contains("."))
                resultLabel.Content = $"{resultLabel.Content}.";
        }



        /// <summary>
        /// Click Event Handler for the Seven Button on the Calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

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

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    /// <summary>
    /// Class to do simple math for the Calculator Operations
    /// </summary>
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
            { return n1 + n2; }
        public static double Subtract(double n1, double n2)
            { return n1 - n2; }
        public static double Multiply(double n1, double n2)
            { return n1 * n2; }
        public static double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

             return n1 / n2;
        }
    }
}
