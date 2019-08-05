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

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        
        string operation = "";
        string polynomial = "";

        public MainWindow()
        {
            BasicInitialize();
            InitializeComponent();
        }

        public void BasicInitialize() {
            polynomial = "";
            operation = "";
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            polynomial += '1';
            Input_number.Text = polynomial;
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            polynomial += '2';
            Input_number.Text = polynomial;
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            polynomial += '3';
            Input_number.Text = polynomial;
        }

        private void Button_4_Click_1(object sender, RoutedEventArgs e)
        {
            polynomial += '4';
            Input_number.Text = polynomial;
        }

        private void Button_5_Click_1(object sender, RoutedEventArgs e)
        {
            polynomial += '5';
            Input_number.Text = polynomial;
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            polynomial += '6';
            Input_number.Text = polynomial;
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            polynomial += '7';
            Input_number.Text = polynomial;
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            polynomial += '8';
            Input_number.Text = polynomial;
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            polynomial += '9';
            Input_number.Text = polynomial;
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            polynomial += '0';
            Input_number.Text = polynomial;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            polynomial="";
            Input_number.Text = "0";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            // Initialize
            String Calculate_polynomial = polynomial;
            polynomial = "";
            Input_number.Text = Calculate_polynomial;

            // Calculate and output
            m_stack s = new m_stack();
            string postfix_answer = s.GetPostfix(Calculate_polynomial); // Now postfix is set
            int decimal_answer = s.PostfixToDecimal();
            string binary_answer = Convert.ToString(decimal_answer, 2);
            string prefix_answer = s.GetPrefix(Calculate_polynomial);

            // Output Data to the 4 Textbox
            Postorder_output.Text = postfix_answer;
            Decimal_output.Text = decimal_answer.ToString();
            Binary_output.Text = binary_answer;
            Preorder_output.Text = prefix_answer;
        }
        /* ======================================================== */
        // Below are the function to get those answers
        // When Equal Button is Clicked, The Calculate_polynomial
        // is sent And then be handled..

        /* ======================================================== */

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int LastOfPoly = (polynomial.Length -1);

            if (polynomial[LastOfPoly] != '+' && polynomial[LastOfPoly] != '-' && polynomial[LastOfPoly] != '*' && polynomial[LastOfPoly] != '/')
            {
                polynomial += '+';
                Input_number.Text = polynomial;
            }
        }

        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            int LastOfPoly = (polynomial.Length - 1);

            if (polynomial[LastOfPoly] != '+' && polynomial[LastOfPoly] != '-' && polynomial[LastOfPoly] != '*' && polynomial[LastOfPoly] != '/')
            {
                polynomial += '-';
                Input_number.Text = polynomial;
            }
        }

        private void Mul_Click(object sender, RoutedEventArgs e)
        {
            int LastOfPoly = (polynomial.Length - 1);

            if (polynomial[LastOfPoly] != '+' && polynomial[LastOfPoly] != '-' && polynomial[LastOfPoly] != '*' && polynomial[LastOfPoly] != '/')
            {
                polynomial += '*';
                Input_number.Text = polynomial;
            }
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            int LastOfPoly = (polynomial.Length - 1);

            if (polynomial[LastOfPoly] != '+' && polynomial[LastOfPoly] != '-' && polynomial[LastOfPoly] != '*' && polynomial[LastOfPoly] != '/')
            {
                polynomial += '/';
                Input_number.Text = polynomial;
            }
        }

        private void Input_number_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Preorder_output_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Decimal_output_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Binary_output_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Postorder_output_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
