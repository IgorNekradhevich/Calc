using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Calculator
    {
        private List<double> num = new List<double>();
        private List<char> sym = new List<char>();
        private double sum;
        public Calculator(string str)
        {
            int len = str.Length;
            string buffer = "";
            for (int i = 0; i < len; i++)
            {
                if (str[i] == '-')
                {
                    if (i == 0 || str[i - 1] == '+' ||
                        str[i - 1] == '-' || str[i - 1] == '*'
                        || str[i - 1] == '/')
                    {
                        buffer += '-';
                    }
                    else
                    {
                        sym.Add(str[i]);
                        num.Add(Convert.ToDouble(buffer));
                        buffer = "";
                    }
                }
                if (str[i] == '+' || str[i] == '*' || str[i] == '/')
                {
                    sym.Add(str[i]);
                    num.Add(Convert.ToDouble(buffer));
                    buffer = "";
                }
                else if (str[i]!='-')//547+15*
                {
                    buffer += str[i];
                }
            }
            num.Add(Convert.ToDouble(buffer));
        }

        void FirstEvent()// 3*3*3*3 -->9 9
        {

            while (sym.Contains('*') || sym.Contains('/'))
            {
                for (int i = 0; i < sym.Count; i++)
                {
                    if (sym[i] == '*')
                    {
                        num[i] *= num[i + 1];
                        num.RemoveAt(i + 1);
                        sym.RemoveAt(i);
                        break;
                    }

                    if (sym[i] == '/')
                    {
                        num[i] /= num[i + 1];
                        num.RemoveAt(i + 1);
                        sym.RemoveAt(i);
                        break;
                    }
                }
            }

            foreach (var numbers in num)
            {
              Console.WriteLine(numbers.ToString());  
            }

            foreach (var symbols in sym)
            {
                Console.WriteLine(symbols.ToString());
            }
        }

        void SecondEvent()
        {
            sum = num[0];
            for (int i = 0; i<sym.Count; i++)
            {
                if (sym[i] == '+')
                    sum += num[i + 1];
                if (sym[i] == '-')
                    sum -= num[i + 1];
            }
        }

        public double Result()
        {
            FirstEvent();
            SecondEvent();
            return sum;
        }
    }
}
