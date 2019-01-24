using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace VisualCalculator
{
    enum Operation { Add = 1, Subtract, Multiply, Divide};

    public partial class MainWindow : Window
    {
        static bool firstEntry = true;
        static double currentValue;
        static string previousEntry;
        static double previousValue;
        static uint flagState = 0;
        static double result = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnEntry_Click(object sender, RoutedEventArgs e)
        {
            Button numericButton = (Button)sender;
            int number;

            if(firstEntry)
            {
                if(int.TryParse(numericButton.Content.ToString(), out number))
                {
                    currentValue = Convert.ToDouble(number);
                    txtOut.Text = currentValue.ToString();
                }
                firstEntry = false;
            }
            else
            {
                if ((numericButton.Content.ToString() == "."))
                {
                    previousEntry = currentValue + ".";
                    txtOut.Text = previousEntry.ToString();
                }
                else if (int.TryParse(numericButton.Content.ToString(), out number))
                {
                    if (previousEntry != null)
                    {
                        previousEntry = previousEntry.ToString() + number.ToString();
                        txtOut.Text = previousEntry.ToString();
                        currentValue = double.Parse(previousEntry);
                    }
                    else
                    {
                        currentValue = Convert.ToDouble(currentValue.ToString() + number.ToString());
                        txtOut.Text = currentValue.ToString();
                    }
                }     
            } 
        }

        // 4 event handlers for operations:
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            previousValue = currentValue;
            currentValue = 0; 
            txtOut.Text = "+";
            flagState = (int)Operation.Add;
            previousEntry = null;
        }

        private void BtnSubtract_Click(object sender, RoutedEventArgs e)
        {
            previousValue = currentValue;
            currentValue = 0;
            txtOut.Text = "-";
            flagState = (int)Operation.Subtract;
            previousEntry = null;
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            previousValue = currentValue;
            currentValue = 0;
            txtOut.Text = "*";
            flagState = (int)Operation.Multiply;
            previousEntry = null;
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            previousValue = currentValue;
            currentValue = 0;
            txtOut.Text = "/";
            flagState = (int)Operation.Divide;
            previousEntry = null;
        }

        //Clear the current results
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {      
            currentValue = 0;
            txtOut.Text = " ";
            flagState = 0;
            result = 0;
            previousEntry = null;
        }

        //Handle the Equals button
        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            switch (flagState)
            {
                case (int)Operation.Add:
                    result = previousValue + currentValue;
                    txtOut.Text = result.ToString();
                    previousEntry = null ;
                    currentValue = 0;
                    break;
                case (int)Operation.Subtract:
                    result = previousValue - currentValue;
                    txtOut.Text = result.ToString();
                    previousEntry = null;
                    currentValue = 0;
                    break;
                case (int)Operation.Multiply:
                    result = previousValue * currentValue;
                    txtOut.Text = result.ToString();
                    previousEntry = null;
                    currentValue = 0;
                    break;
                case (int)Operation.Divide:
                    result = previousValue / currentValue;
                    txtOut.Text = result.ToString();
                    previousEntry = null;
                    currentValue = 0;
                    break;
            }
            firstEntry = true;
        }
    }
}
