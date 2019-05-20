using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_Calculator
{
    public partial class Form1 : Form
    {
        double operand1;
        string Op;
        bool bin = false, dec = true, oct = false, hex = false;
        bool IfOperationMade = false;

        public Form1()
        {
            InitializeComponent();
        }

        // десятичные цифры
        private void button0_Click(object sender, EventArgs e)
        {
            if (NumberTextBox.Text == "0" || NumberTextBox.Text == "∞" || NumberTextBox.Text == "не число" || IfOperationMade)
            {
                IfOperationMade = false;
                NumberTextBox.Text = "";
                NumberTextBox.Text = NumberTextBox.Text + (sender as Button).Text;
            }
            else NumberTextBox.Text = NumberTextBox.Text + (sender as Button).Text;
        }

        //ввод чисел 1-9 с кнопки
        private void digit1to9insert(object sender, EventArgs e)
        {
            double chislo;
            bool ifchislo = double.TryParse(NumberTextBox.Text, out chislo);

            if (NumberTextBox.Text == "0" || double.IsNaN(chislo) || double.IsInfinity(chislo) || IfOperationMade)
            {
                IfOperationMade = false;
                NumberTextBox.Text = "";
                NumberTextBox.Text = NumberTextBox.Text + (sender as Button).Text;
            }
            else NumberTextBox.Text = NumberTextBox.Text + (sender as Button).Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            digit1to9insert(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            digit1to9insert(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            digit1to9insert(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            digit1to9insert(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            digit1to9insert(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            digit1to9insert(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            digit1to9insert(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            digit1to9insert(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            digit1to9insert(sender, e);
        }
        //конец десятичных цифр

        //16-ричные цифры
        private void digitAtoFinsert(object sender, EventArgs e)
        {
            if (NumberTextBox.Text == "0" || IfOperationMade)
            {
                IfOperationMade = false;
                NumberTextBox.Text = "";
                NumberTextBox.Text = NumberTextBox.Text + (sender as Button).Text;
            }
            else NumberTextBox.Text = NumberTextBox.Text + (sender as Button).Text;
        }

        //цифры A-F
        private void buttonA_Click(object sender, EventArgs e)
        {
            digitAtoFinsert(sender, e);
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            digitAtoFinsert(sender, e);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            digitAtoFinsert(sender, e);
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            digitAtoFinsert(sender, e);
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            digitAtoFinsert(sender, e);
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            digitAtoFinsert(sender, e);
        }
        //конец цифр A-F

        //равно (бинарные операции)
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            double Result = 0;
            IfOperationMade = true;
            //сохраняем значение второго операнда
            //в переменной operand2
            double operand2 = double.Parse(NumberTextBox.Text);
            switch (Op)
            {   //в зависимости от знака операции
                //вычисляем выражение
                case "+": Result = operand1 + operand2; break;
                case "-": Result = operand1 - operand2; break;
                case "*": Result = operand1 * operand2; break;
                case "/": Result = operand1 / operand2; break;
                case "AND": {
                        string op2Str = NumberTextBox.Text;
                        operand2 = 0;

                        for (int i = 0; i < op2Str.Length; i++)
                        {
                            operand2 += (int)Char.GetNumericValue(op2Str[i]) * Math.Pow(2, op2Str.Length - i - 1);
                        }

                        Result = (int)operand1 & (int)operand2;
                        op2Str = Convert.ToString((int)Result, 2);
                        Result = int.Parse(op2Str);
                    } break;
                case "OR": {
                        string op2Str = NumberTextBox.Text;
                        operand2 = 0;

                        for (int i = 0; i < op2Str.Length; i++)
                        {
                            operand2 += (int)Char.GetNumericValue(op2Str[i]) * Math.Pow(2, op2Str.Length - i - 1);
                        }

                        Result = (int)operand1 | (int)operand2;
                        op2Str = Convert.ToString((int)Result, 2);
                        Result = int.Parse(op2Str);
                    } break;
                case "x^y": {
                        if (double.IsNaN(operand1) || double.IsInfinity(operand1)) Result = double.NaN;
                        else Result = Math.Pow(operand1, operand2);
                    } break;
            }
            NumberTextBox.Text = Result.ToString();
        }

        //знаки действий
        //сложение
        private void buttonPlus_Click(object sender, EventArgs e)
        {
                //сохраняем значение числа в переменной operand1
                operand1 = double.Parse(NumberTextBox.Text);
                //обнуляем содержимое окна ввода
                NumberTextBox.Text = "0";
                //сохраняем значение арифметической операции
                //в переменной Op
                Op = (sender as Button).Text;
        }

        //вычитание
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            //сохраняем значение числа в переменной operand1
            operand1 = double.Parse(NumberTextBox.Text);
            //обнуляем содержимое окна ввода
            NumberTextBox.Text = "0";
            //сохраняем значение арифметической операции
            //в переменной Op
            Op = (sender as Button).Text;
        }

        //умножение
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            //сохраняем значение числа в переменной operand1
            operand1 = double.Parse(NumberTextBox.Text);
            //обнуляем содержимое окна ввода
            NumberTextBox.Text = "0";
            //сохраняем значение арифметической операции
            //в переменной Op
            Op = (sender as Button).Text;
        }

        //деление
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            //сохраняем значение числа в переменной operand1
            operand1 = double.Parse(NumberTextBox.Text);
            //обнуляем содержимое окна ввода
            NumberTextBox.Text = "0";
            //сохраняем значение арифметической операции
            //в переменной Op
            Op = (sender as Button).Text;
        }

        //запятая
        private void buttonComa_Click(object sender, EventArgs e)
        {
            double chislo;
            bool check  = double.TryParse(NumberTextBox.Text,out chislo);

            //если в записи числа еще нет символа ','
            if (!NumberTextBox.Text.Contains(',') && !double.IsNaN(chislo) && !double.IsInfinity(chislo))
                    //добавляем ',' к записи числа
                    NumberTextBox.Text = NumberTextBox.Text + ",";
        }

        //очистка окна ввода
        private void buttonClear_Click(object sender, EventArgs e)
        {
            NumberTextBox.Text = "0";
        }

        //логическое И
        private void buttonAND_Click(object sender, EventArgs e)
        {
            string op1Str = NumberTextBox.Text;
            operand1 = 0;

            //сохраняем значение числа в переменной operand1
            for (int i = 0; i < op1Str.Length; i++)
            {
                operand1 += (int)Char.GetNumericValue(op1Str[i]) * Math.Pow(2, op1Str.Length - i - 1);
            }
            //обнуляем содержимое окна ввода
            NumberTextBox.Text = "0";
            //сохраняем значение арифметической операции
            //в переменной Op
            Op = (sender as Button).Text;
        }

        //логическое ИЛИ
        private void buttonOR_Click(object sender, EventArgs e)
        {
            string op1Str = NumberTextBox.Text;
            operand1 = 0;

            //сохраняем значение числа в переменной operand1
            for (int i = 0; i < op1Str.Length; i++)
            {
                operand1 += (int)Char.GetNumericValue(op1Str[i]) * Math.Pow(2, op1Str.Length - i - 1);
            }
            //обнуляем содержимое окна ввода
            NumberTextBox.Text = "0";
            //сохраняем значение арифметической операции
            //в переменной Op
            Op = (sender as Button).Text;
        }

        //логическое НЕ
        private void buttonNOT_Click(object sender, EventArgs e)
        {
            string op1Str = NumberTextBox.Text;

            //пошаговое инверитрование символов
            op1Str = op1Str.Replace('0', 'a');
            op1Str = op1Str.Replace('1', '0');
            op1Str = op1Str.Replace('a', '1');

            //убираю незначащие нули
            while (op1Str[0] != '1' && op1Str != "0")
            {
                op1Str = op1Str.Remove(0, 1);
            }

            NumberTextBox.Text = op1Str;
        }

        //убираем последнюю цифру (BackSpace)
        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            string textbox = NumberTextBox.Text;

            if (textbox.Length == 1 || NumberTextBox.Text == "∞" || NumberTextBox.Text == "не число" || NumberTextBox.Text == "-∞" || (textbox[0] == '-' && textbox.Length == 2)) NumberTextBox.Text = "0";
            else if (textbox.Length > 1 && NumberTextBox.Text != "не число" && NumberTextBox.Text != "-∞")
            {
                textbox = textbox.Remove(textbox.Length - 1, 1);
                NumberTextBox.Text = textbox;
            }
        }

        //смена знака
        private void buttonSignChange_Click(object sender, EventArgs e)
        {
            string textbox = NumberTextBox.Text;

            if (NumberTextBox.Text != "0" && NumberTextBox.Text != "не число" && NumberTextBox.Text != "Неверно введены дынные!")
            {
                if (textbox[0] != '-') NumberTextBox.Text = NumberTextBox.Text.Insert(0, "-");
                else NumberTextBox.Text = NumberTextBox.Text.Remove(0, 1);
            }
        }
        
        //квадратный корень
        private void buttonSQR_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;
            double x;
            bool ifXNum = double.TryParse(NumberTextBox.Text, out x);

            if (double.IsNaN(x) || double.IsInfinity(x) || x < 0)
            {
                x = double.NaN;
                NumberTextBox.Text = x.ToString();
            }
            else NumberTextBox.Text = Math.Sqrt(x).ToString();
        }

        //возведение в квадрат
        private void buttonSquare_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;
            double x;
            bool ifXNum = double.TryParse(NumberTextBox.Text, out x);

            if (double.IsNaN(x) || double.IsInfinity(x))
            {
                x = double.NaN;
                NumberTextBox.Text = x.ToString();
            }
            else NumberTextBox.Text = Math.Pow(x, 2).ToString();
        }

        // x ^ y
        private void buttonDegree_Click(object sender, EventArgs e)
        {
            double x;
            bool ifXNum = double.TryParse(NumberTextBox.Text, out x);

            //сохраняем значение числа в переменной operand1
            operand1 = x;
            //обнуляем содержимое окна ввода
            NumberTextBox.Text = "0";
            //сохраняем значение арифметической операции
            //в переменной Op
            Op = (sender as Button).Text;
        }

        // 1/x
        private void button1divx_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;
            double Result = 0;
            Result = 1 / double.Parse(NumberTextBox.Text);

            NumberTextBox.Text = Result.ToString();
        }

        // нахождение факториала числа
        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;
            if (double.Parse(NumberTextBox.Text) < 0 || NumberTextBox.Text == "∞" || NumberTextBox.Text == "не число") NumberTextBox.Text = "не число";
            else
            {
                double nd = double.Parse(NumberTextBox.Text);
                int result = 1, n = (int)nd;
                for (int i = 1; i <= n; i++) result *= i;

                NumberTextBox.Text = result.ToString();
            }
        }

        //число PI
        private void buttonPI_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;

            NumberTextBox.Text = Math.PI.ToString();
        }

        //Синус угла в радианах
        private void buttonSIN_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;
            double x;
            bool ifXNum = double.TryParse(NumberTextBox.Text, out x);

            if (double.IsNaN(x)) NumberTextBox.Text = "не число";
            else NumberTextBox.Text = Math.Sin(x).ToString();
        }

        //Косинус угла в радианах
        private void buttonCOS_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;
            double x;
            bool ifXNum = double.TryParse(NumberTextBox.Text, out x);

            if (double.IsNaN(x)) NumberTextBox.Text = "не число";
            else NumberTextBox.Text = Math.Cos(x).ToString();
        }

        //Тангенс угла в радианах
        private void buttonTAN_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;
            double x;
            bool ifXNum = double.TryParse(NumberTextBox.Text, out x);

            if (double.IsNaN(x)) NumberTextBox.Text = "не число";
            else NumberTextBox.Text = Math.Tan(x).ToString();
        }

        //число Эйлера
        private void buttonEilerN_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;

            NumberTextBox.Text = Math.E.ToString();
        }

        //число Эйлера в степени x
        private void buttonEDegX_Click(object sender, EventArgs e)
        {
            IfOperationMade = true;
            double x;
            bool ifXNum = double.TryParse(NumberTextBox.Text, out x);

            if (double.IsNaN(x) || double.IsInfinity(x)) NumberTextBox.Text = "не число";
            else NumberTextBox.Text = Math.Pow(Math.E, x).ToString();
        }

        //ввод с клавиатуры
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            double chislo;
            bool ifchislo = double.TryParse(NumberTextBox.Text, out chislo);
            string symbol;

            symbol = e.KeyChar.ToString();

            if (bin == true)
            {
                symbol = e.KeyChar.ToString();
                switch (symbol)
                {
                    case "0": button0_Click(button0, e); break;
                    case "1": button1_Click(button1, e); break;
                    case "=": buttonEqual_Click(sender, e); break;
                    case "\b": buttonBackSpace_Click(sender, e); break;
                    default: break;
                }
            }
            else if (oct == true)
            {
                if (e.KeyChar.ToString() == "\b") buttonBackSpace_Click(sender, e);

                if (char.IsDigit(e.KeyChar) && char.GetNumericValue(e.KeyChar) >= 0 && char.GetNumericValue(e.KeyChar) <= 7)
                {
                    if (NumberTextBox.Text == "0" || double.IsNaN(chislo) || double.IsInfinity(chislo) || IfOperationMade)
                    {
                        IfOperationMade = false;
                        NumberTextBox.Text = "";
                        NumberTextBox.Text = NumberTextBox.Text + e.KeyChar;
                    }
                    else NumberTextBox.Text = NumberTextBox.Text + e.KeyChar;
                }
            }
            else if (dec == true)
            {
                if (char.IsDigit(e.KeyChar))
                {
                    if (NumberTextBox.Text == "0" || double.IsNaN(chislo) || double.IsInfinity(chislo) || IfOperationMade)
                    {
                        IfOperationMade = false;
                        NumberTextBox.Text = "";
                        NumberTextBox.Text = NumberTextBox.Text + e.KeyChar;
                    }
                    else NumberTextBox.Text = NumberTextBox.Text + e.KeyChar;
                }

                symbol = e.KeyChar.ToString();
                switch (symbol)
                {
                    case "+": {
                            if (dec == true)
                            {
                                operand1 = double.Parse(NumberTextBox.Text);
                                NumberTextBox.Text = "0";
                                Op = e.KeyChar.ToString();
                            }
                        } break;
                    case "-": {
                            operand1 = double.Parse(NumberTextBox.Text);
                            NumberTextBox.Text = "0";
                            Op = e.KeyChar.ToString();
                        } break;
                    case "*": {
                            operand1 = double.Parse(NumberTextBox.Text);
                            NumberTextBox.Text = "0";
                            Op = e.KeyChar.ToString();
                        } break;
                    case "/": {
                            operand1 = double.Parse(NumberTextBox.Text);
                            NumberTextBox.Text = "0";
                            Op = e.KeyChar.ToString();
                        } break;
                    case "=": {
                            buttonEqual_Click(sender, e);
                        } break;
                    case ".": {
                            buttonComa_Click(sender, e);
                        } break;
                    case "\b": buttonBackSpace_Click(sender, e); break;
                    default: break;
                }
            }
            else if (hex == true)
            {
                if (e.KeyChar.ToString() == "\b") buttonBackSpace_Click(sender, e);

                string AF = "ABCDEF";
                int IndexAF = AF.IndexOf(char.ToUpper(e.KeyChar));
                if (char.IsDigit(e.KeyChar) || IndexAF >= 0)
                {
                    if (NumberTextBox.Text == "0" || double.IsNaN(chislo) || double.IsInfinity(chislo) || IfOperationMade)
                    {
                        IfOperationMade = false;
                        NumberTextBox.Text = "";
                        NumberTextBox.Text = NumberTextBox.Text + char.ToUpper(e.KeyChar);
                    }
                    else NumberTextBox.Text = NumberTextBox.Text + char.ToUpper(e.KeyChar);
                }
            }
        }

        //системы счисления
        private void radioButtonBin_CheckedChanged(object sender, EventArgs e)
        {
            IfOperationMade = true;
            bin = true;

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

            buttonA.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonD.Enabled = false;
            buttonE.Enabled = false;
            buttonF.Enabled = false;

            buttonNOT.Enabled = true;
            buttonOR.Enabled = true;
            buttonAND.Enabled = true;
            buttonPI.Enabled = false;
            buttonEDegX.Enabled = false;

            buttonDegree.Enabled = false;
            button1divx.Enabled = false;
            buttonFactorial.Enabled = false;
            buttonSIN.Enabled = false;
            buttonCOS.Enabled = false;
            buttonTAN.Enabled = false;
            buttonEilerN.Enabled = false;

            buttonSQR.Enabled = false;
            buttonSquare.Enabled = false;
            buttonDivide.Enabled = false;
            buttonMultiply.Enabled = false;
            buttonMinus.Enabled = false;
            buttonPlus.Enabled = false;
            buttonEqual.Enabled = true;
            buttonComa.Enabled = false;

            if (NumberTextBox.Text == "0" || NumberTextBox.Text == "∞"|| NumberTextBox.Text == "-∞" || NumberTextBox.Text == "не число")
            {
                oct = false;
                dec = false;
                hex = false;
            }
            else
            {
                if (hex == true)
                {
                    hex = false;

                    string Bin = "";
                    string HexD = "0123456789ABCDEF";
                    string HexToBin = NumberTextBox.Text;
                    List<string> s = new List<string>() { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };

                    for (int i = 0; i < HexToBin.Length; i++)
                    {
                        char HexSym = HexToBin[i];
                        int Index = HexD.IndexOf(HexSym);
                        Bin += s[Index];
                    }

                    NumberTextBox.Text = Bin;
                }
                else if (dec == true)
                {
                    dec = false;
                    double DDecToBin = double.Parse(NumberTextBox.Text);
                    int IDecToBin = (int)DDecToBin;
                    string DecToBin;

                    DecToBin = Convert.ToString(IDecToBin, 2);

                    NumberTextBox.Text = DecToBin;
                }
                else if (oct == true)
                {
                    oct = false;

                    string Bin = "";
                    string OctD = "01234567";
                    string OctToBin = NumberTextBox.Text;
                    List<string> s = new List<string>() { "000", "001", "010", "011", "100", "101", "110", "111" };

                    for (int i = 0; i < OctToBin.Length; i++)
                    {
                        char HexSym = OctToBin[i];
                        int Index = OctD.IndexOf(HexSym);
                        Bin += s[Index];
                    }

                    NumberTextBox.Text = Bin;
                }
            }
        }

        private void radioButtonOct_CheckedChanged(object sender, EventArgs e)
        {
            IfOperationMade = true;
            oct = true;

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = false;
            button9.Enabled = false;

            buttonA.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonD.Enabled = false;
            buttonE.Enabled = false;
            buttonF.Enabled = false;

            buttonNOT.Enabled = false;
            buttonOR.Enabled = false;
            buttonAND.Enabled = false;
            buttonPI.Enabled = false;
            buttonEDegX.Enabled = false;

            buttonDegree.Enabled = false;
            button1divx.Enabled = false;
            buttonFactorial.Enabled = false;
            buttonSIN.Enabled = false;
            buttonCOS.Enabled = false;
            buttonTAN.Enabled = false;
            buttonEilerN.Enabled = false;

            buttonSQR.Enabled = false;
            buttonSquare.Enabled = false;
            buttonDivide.Enabled = false;
            buttonMultiply.Enabled = false;
            buttonMinus.Enabled = false;
            buttonPlus.Enabled = false;
            buttonEqual.Enabled = false;
            buttonComa.Enabled = false;

            if (NumberTextBox.Text == "0" || NumberTextBox.Text == "∞" || NumberTextBox.Text == "-∞" || NumberTextBox.Text == "не число")
            {
                bin = false;
                dec = false;
                hex = false;
            }
            else
            {
                if (bin == true)
                {
                    bin = false;

                    string BinToOct = NumberTextBox.Text;
                    int IBinToOct = 0;
                    for (int i = 0; i < BinToOct.Length; i++)
                    {
                        IBinToOct += (int)Char.GetNumericValue(BinToOct[i]) * (int)Math.Pow(2, BinToOct.Length - i - 1);
                    }

                    NumberTextBox.Text = Convert.ToString(IBinToOct, 8);
                    
                }
                else if (dec == true)
                {
                    dec = false;

                    string DecToOct = NumberTextBox.Text;
                    int IDecToOct = (int)double.Parse(DecToOct);

                    NumberTextBox.Text = Convert.ToString(IDecToOct, 8);
                }
                else if (hex == true)
                {
                    hex = false;

                    string DHexToOct = "0123456789ABCDEF";
                    string HexToOct = NumberTextBox.Text;
                    int IHexToOct = 0;

                    for (int i = 0; i < HexToOct.Length; i++)
                    {
                        IHexToOct += DHexToOct.IndexOf(HexToOct[i]) * (int)Math.Pow(16, HexToOct.Length - i - 1);
                    }

                    NumberTextBox.Text = Convert.ToString(IHexToOct, 8);
                }
            }
        }

        private void radioButtonDec_CheckedChanged(object sender, EventArgs e)
        {
            IfOperationMade = true;
            dec = true;

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            buttonA.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonD.Enabled = false;
            buttonE.Enabled = false;
            buttonF.Enabled = false;

            buttonNOT.Enabled = false;
            buttonOR.Enabled = false;
            buttonAND.Enabled = false;
            buttonPI.Enabled = true;
            buttonEDegX.Enabled = true;

            buttonDegree.Enabled = true;
            button1divx.Enabled = true;
            buttonFactorial.Enabled = true;
            buttonSIN.Enabled = true;
            buttonCOS.Enabled = true;
            buttonTAN.Enabled = true;
            buttonEilerN.Enabled = true;

            buttonSQR.Enabled = true;
            buttonSquare.Enabled = true;
            buttonDivide.Enabled = true;
            buttonMultiply.Enabled = true;
            buttonMinus.Enabled = true;
            buttonPlus.Enabled = true;
            buttonEqual.Enabled = true;
            buttonComa.Enabled = true;

            if (NumberTextBox.Text == "0" || NumberTextBox.Text == "∞" || NumberTextBox.Text == "-∞" || NumberTextBox.Text == "не число")
            {
                bin = false;
                oct = false;
                hex = false;
            }
            else
            {
                if (bin == true)
                {
                    bin = false;

                    string BinToDec = NumberTextBox.Text;
                    int IBinToDec = 0;
                    for (int i = 0; i < BinToDec.Length; i++)
                    {
                        IBinToDec += (int)Char.GetNumericValue(BinToDec[i]) * (int)Math.Pow(2, BinToDec.Length - i - 1);
                    }

                    NumberTextBox.Text = IBinToDec.ToString();
                }
                else if (oct == true)
                {
                    oct = false;

                    string OctToDec = NumberTextBox.Text;
                    int IOctToDec = 0;

                    for (int i = 0; i < OctToDec.Length; i++)
                    {
                        IOctToDec += (int)Char.GetNumericValue(OctToDec[i]) * (int)Math.Pow(8, OctToDec.Length - i - 1);
                    }

                    NumberTextBox.Text = IOctToDec.ToString();
                }
                else if (hex == true)
                {
                    hex = false;

                    string DHexToDec = "0123456789ABCDEF";
                    string HexToDec = NumberTextBox.Text;
                    int IHexToDec = 0;

                    for (int i = 0; i < HexToDec.Length; i++)
                    {
                        IHexToDec += DHexToDec.IndexOf(HexToDec[i]) * (int)Math.Pow(16, HexToDec.Length - i - 1);
                    }

                    NumberTextBox.Text = IHexToDec.ToString();
                }
            }
        }

        private void radioButtonHex_CheckedChanged(object sender, EventArgs e)
        {
            IfOperationMade = true;
            hex = true;

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            buttonA.Enabled = true;
            buttonB.Enabled = true;
            buttonC.Enabled = true;
            buttonD.Enabled = true;
            buttonE.Enabled = true;
            buttonF.Enabled = true;

            buttonNOT.Enabled = false;
            buttonOR.Enabled = false;
            buttonAND.Enabled = false;
            buttonPI.Enabled = false;
            buttonEDegX.Enabled = false;

            buttonDegree.Enabled = false;
            button1divx.Enabled = false;
            buttonFactorial.Enabled = false;
            buttonSIN.Enabled = false;
            buttonCOS.Enabled = false;
            buttonTAN.Enabled = false;
            buttonEilerN.Enabled = false;

            buttonSQR.Enabled = false;
            buttonSquare.Enabled = false;
            buttonDivide.Enabled = false;
            buttonMultiply.Enabled = false;
            buttonMinus.Enabled = false;
            buttonPlus.Enabled = false;
            buttonEqual.Enabled = false;
            buttonComa.Enabled = false;

            if (NumberTextBox.Text == "0" || NumberTextBox.Text == "∞" || NumberTextBox.Text == "-∞" || NumberTextBox.Text == "не число")
            {
                bin = false;
                oct = false;
                dec = false;
            }
            else
            {
                if (bin == true)
                {
                    bin = false;

                    string BinToHex = NumberTextBox.Text;
                    int IBinToHex = 0;
                    for (int i = 0; i < BinToHex.Length; i++)
                    {
                        IBinToHex += (int)Char.GetNumericValue(BinToHex[i]) * (int)Math.Pow(2, BinToHex.Length - i - 1);
                    }

                    NumberTextBox.Text = Convert.ToString(IBinToHex, 16).ToUpper();
                }
                else if (dec == true)
                {
                    dec = false;

                    string DecToHex = NumberTextBox.Text;
                    int IDecToHex = (int)double.Parse(DecToHex);

                    NumberTextBox.Text = Convert.ToString(IDecToHex, 16).ToUpper();
                }
                else if (oct == true)
                {
                    oct = false;

                    string OctToHex = NumberTextBox.Text;
                    int IOctToHex = 0;

                    for (int i = 0; i < OctToHex.Length; i++)
                    {
                        IOctToHex += (int)Char.GetNumericValue(OctToHex[i]) * (int)Math.Pow(8, OctToHex.Length - i - 1);
                    }

                    NumberTextBox.Text = Convert.ToString(IOctToHex, 16).ToUpper();
                }
            }
        }
        //конец систем счисления
    }
}
