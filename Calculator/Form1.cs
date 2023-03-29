using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "(";
            }
            else
            {
                textBox1.Text = textBox1.Text + "(";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = ")";
            }
            else
            {
                textBox1.Text = textBox1.Text + ")";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "";
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "/";
            }
            else
            {
                textBox1.Text = textBox1.Text + "/";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "*";
            }
            else
            {
                textBox1.Text = textBox1.Text + "*";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "-";
            }
            else
            {
                textBox1.Text = textBox1.Text + "-";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "+";
            }
            else
            {
                textBox1.Text = textBox1.Text + "+";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = ".";
            }
            else
            {
                textBox1.Text = textBox1.Text + ".";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text = textBox1.Text + "0";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = textBox1.Text + "1";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text = textBox1.Text + "2";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text = textBox1.Text + "3";
            }
        }
        static String from4To10(String string_value)
        {
            if (!string_value.Contains('.'))
            {
                string_value += ".0";
            }
            int dotIndex = -1;
            Double res = 0.0;
            for (int i = 0; i < string_value.Length; i++)
            {
                if (string_value[i] == '.')
                {
                    dotIndex = i;
                }
            }
            try
            {
                for (int k = 0; k < dotIndex; k++)
                {
                    res += Int32.Parse(string_value[k].ToString()) * Math.Pow(4, dotIndex - 1 - k);
                }
                Int32 counter = -1;
                for (int k = dotIndex + 1; k < string_value.Length; k++)
                {
                    res += (Int32.Parse(string_value[k].ToString()) * Math.Pow(4, counter));
                    counter--;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return res.ToString().Replace(",", ".");
        }
        static String from10To4(String string_value)
        {

            if (!string_value.Contains('.'))
            {
                string_value += ".0";
            }
            Boolean flag = true;
            if (string_value[0] == '-')
            {
                string_value = string_value.Remove(0, 1);
                flag = false;
            }
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = ".";
            String[] strMas = string_value.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            Double whole = Convert.ToDouble(strMas[0], provider);
            String strWhole = "";
            Double frac = Convert.ToDouble(strMas[1], provider);
            String strFrac = "";
            while (whole >= 4)
            {
                strWhole += (whole - Math.Truncate(whole / 4) * 4).ToString();
                whole = Math.Truncate(whole / 4);
            }
            strWhole += (whole - Math.Truncate(whole / 4) * 4).ToString();
            char[] chars = strWhole.ToCharArray();
            Array.Reverse(chars);
            strWhole = new String(chars);
            if (!flag)
            {
                strWhole = "-" + strWhole;
            }
            for (int i = 0; i < 10; i++)
            {
                strFrac += (Math.Truncate((frac * 4) / Math.Pow(10, strMas[1].Length))).ToString();
                frac = (frac * 4) % (Math.Pow(10, strMas[1].Length));
            }
            strWhole += ("." + strFrac);
            return strWhole;
        }
        static String[] Change_numbers(String string_with_values)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = ".";
            String[] values = new String[string_with_values.Length];
            String[] strMas = string_with_values.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < strMas.Length; i++)
            {
                values[i] = from4To10(strMas[i]);
            }
            return values;
        }
        static String Build_string_back(String initial_str, String[] values, String string_with_values)
        {
            String res = "";
            Int32 counter = 0;
            String[] strMas = string_with_values.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < initial_str.Length; i++)
            {
                switch (initial_str[i])
                {
                    case '*':
                        { res += "*"; }
                        break;
                    case '(':
                        { res += "("; }
                        break;
                    case ')':
                        { res += ")"; }
                        break;
                    case '+':
                        { res += "+"; }
                        break;
                    case '/':
                        { res += "/"; }
                        break;
                    case '-':
                        { res += "-"; }
                        break;
                    default:
                        {
                            res = res + values[counter];
                            i = i + strMas[counter].Length - 1;
                            counter++;
                        }
                        break;
                }
            }
            return res.Replace(",", ".");
        }

        private void button6_Click(object sender, EventArgs e)
        { 
            String str = textBox1.Text;
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = ".";
            String[] values = new String[str.Length];
            String string_with_values = "";
            Int32 counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '*':
                        string_with_values += ' ';
                        break;
                    case '(':
                        string_with_values += ' ';
                        break;
                    case ')':
                        string_with_values += ' ';
                        break;
                    case '+':
                        string_with_values += ' ';
                        break;
                    case '/':
                        string_with_values += ' ';
                        break;
                    case '-':
                        string_with_values += ' ';
                        break;
                    default:
                        {
                            string_with_values += str[i];
                            break;
                        }
                }
            }
            String string_with_values_trimmed = "";
            for (int k = 0; k < string_with_values.Length; k++)
            {
                if (string_with_values[k] != ' ')
                {
                    counter = 0;
                    string_with_values_trimmed += string_with_values[k];
                }
                else
                {
                    counter++;
                    if (counter == 1)
                    {
                        string_with_values_trimmed += " ";
                    }
                }
            }
            values = Change_numbers(string_with_values_trimmed);
            string_with_values_trimmed = Build_string_back(str, values, string_with_values_trimmed);
            DataTable dt = new DataTable();
            try
            {
                var v = dt.Compute(string_with_values_trimmed, "");
                String string_res = v.ToString();
                textBox1.Text = from10To4(string_res.Replace(",", ".")).ToString();
            } catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
           
         
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
