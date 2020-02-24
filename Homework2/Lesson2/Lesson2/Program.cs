using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            first();
            second();
            third();
        }
        static void third()
        {
            //用“埃氏筛法”求2~ 100以内的素数
            Console.WriteLine("用“埃氏筛法”求2~ 100以内的素数");
            int[] array = new int[101];
            int tmp = 2;
            for(int j=2;j<array.Length;++j)
            {
                for (int i = 2; i < array.Length; i++)
                {
                    if (i % tmp == 0 && i != tmp)
                        array[i] = 1;
                }
                for (int i = 2; i < array.Length; i++)
                {
                    if (i > tmp && array[i] == 0)
                    {
                        tmp = i;
                        break;
                    }
                }
            }
            for(int i=2;i<array.Length;i++)
            {
                if (array[i] == 0)
                    Console.WriteLine(i);
            }

        }
        static void second()
        {
            //求一个整数数组的最大值、最小值、平均值和所有数组元素的和。
            double[] array;
            int n;
            double max=double.MinValue, min=double.MaxValue, average, sum=0;
            Console.WriteLine("Q:求一个整数数组的最大值、最小值、平均值和所有数组元素的和\r\n数组长度:");
            if(!int.TryParse(Console.ReadLine(),out n))
            {
                Console.WriteLine("数据错误");
                return;
            }
            array = new double[n];
            for(int i=0;i<n;i++)
            {
                if (!double.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("数据错误");
                    return;
                }
                sum = sum + array[i];
                if (array[i] > max)
                    max = array[i];
                if (array[i] < min)
                    min = array[i];
            }
            //max = array.Max();
            //min = array.Min();
            //average = array.Average();
            //sum = array.Sum();
            average = sum / n;
            Console.WriteLine("max\tmin\taverage\tsum");
            Console.WriteLine(max + "\t"+min + "\t" + average + "\t" + sum);


        }
        static void first()
        {
            //编写程序输出用户指定数据的所有素数因子
            int n;
            List<int> list = new List<int>();
            Console.WriteLine("Q:编写程序输出用户指定数据的所有素数因子\r\n请输入：");
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("数据形式错误");
                return;
            }
            for (int i = 2; i*i <= n; i++)
            {
                while (n % i == 0 && n != i)
                {
                    //Console.WriteLine(i);
                    list.Add(i);
                    n /= i;
                }
            }
            list.Add(n);
            //Console.WriteLine("最终结果：");
            foreach (var j in list)
            {
                Console.WriteLine(j);
            }
        }
    }
}
