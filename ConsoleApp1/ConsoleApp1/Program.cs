using System;

namespace ConsoleApp1
{
    class Program
    {
        static double Cul(string s)
        {
            double a;
            if (s.Contains('-'))
                return Culculate(s, '-');
            else if (s.Contains('+'))
                return Culculate(s, '+');
            else if (s.Contains('*'))
                return Culculate(s, '*');
            else if (s.Contains('/'))
                return Culculate(s, '/');
            double.TryParse(s,out a);
            return (a);
        }
        static double Culculate(string s, char i)
        {
            string[] a = s.Split(i);
            //Console.WriteLine("dangqian"+s);
            double a1, a2;
            double.TryParse(a[0], out a1);
            double.TryParse(a[1], out a2);
            double result;
            switch (i)
            {
                case '+': result = a1 + a2; break;
                case '-': result = a1 - a2; break;
                case '*': result = a1 * a2; break;
                case '/': result = a1 / a2; break;
                default: result = 0; break;
            }
            return result;
        }
            static void Main(string[] args)
        {
            Console.WriteLine("Hello World! ");
            string s;
            string[] a;
            char[] b;
            int count,j;
            double result=0;
            while (true)
            {
                s = Console.ReadLine();//读取表达式
                //括号处理的部分只能支持含有一个括号的运算且每次运算只能调动两个操作数，如果写复杂点就要用栈了。。。
                //if (s.Contains('('))//括号处理
                //{
                //    a = s.Split(new Char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                //    count = a.Length;
                //    Console.WriteLine(count);
                //    double[] r = new double[count];

                //    for (int i = 0; i < count; i++)
                //    {
                //        if (a[i].Split(new Char[] { '-', '+', '*', '/' }, StringSplitOptions.RemoveEmptyEntries).Length == 2)
                //        {
                //            //去除括号后的，构成二元表达式的，计算
                //            r[i] = Cul(a[i]);
                //            Console.WriteLine(i + " " + r[i]);
                //            a[i] = r[i].ToString();
                //        }
                //    }

                //    for (int i = 1; i < count; i++)
                //    {
                //        a[0] += a[i];//新表达式
                //    }
                //    s = a[0];
                //    result = Cul(s);
                //}
                //else 
                result = Cul(s);
                Console.WriteLine(result);
            }
        }
        
    }
}
