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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DisplayContents calc = new();
        public MainWindow()
        {
            InitializeComponent();
            calc.HistoryChanged += OnHistoryChanged;
            calc.CurrentInputChanged += OnCurrentInputChanged;
            calc.Reset();
        }
        private void OnHistoryChanged(string str)
        {
            HistoryDisplay.Content = str;
        }
        private void OnCurrentInputChanged(string str)
        {
            if (str.Length == 0)
            {
                str = "0";
            }
            CurrentInputDisplay.Content = str;
        }
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string contents = calc.Contents;
                Operator root = OperatorTreeParser.Parse(contents);
                double result = root.Calculate();
                calc.Reset();
                calc.CurrentInput = result.ToString();
            }
            catch
            {
                MessageBox.Show("can't calculate");
            }
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            calc.AddOp('/');
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            calc.AddOp('*');
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            calc.AddOp('+');
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            calc.AddOp('-');
        }

        private void BtnBackspace_Click(object sender, RoutedEventArgs e)
        {
            calc.PopLast();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            calc.Reset();
        }

        private void BtnRightBracket_Click(object sender, RoutedEventArgs e)
        {
            calc.AddRightBracket();
        }

        private void BtnLeftBracket_Click(object sender, RoutedEventArgs e)
        {
            calc.AddLeftBracket();
        }
    }
    // Buttons 0-9
    public partial class MainWindow
    {
        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('9');
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('8');
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('7');
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('4');
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('5');
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('4');
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('3');
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('2');
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('1');
        }
        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            calc.Add('0');
        }

    }
}

