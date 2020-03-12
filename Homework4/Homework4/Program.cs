using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    //1、为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。
    //通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。

    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail==null)
            {
                head = tail = n;
            }else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void Foreach(Action<T> action)
        {
            for (Node<T> p = head; p != null; p = p.Next)
            {
                action(p.Data);
            }
        }
    }
    //2、使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。
    //在闹钟走时时或者响铃时，在控制台显示提示信息。
    public delegate void TickHanlder(object sender);
    public delegate void AlarmHanlder(object sender);
    class Clock_runtime
    {
        public event TickHanlder Tick;
        public event AlarmHanlder Alarm;
        public string alarm_aim;
        public void Time()
        {
            while(true)
            {
                
                if (DateTime.Now.ToShortTimeString().Equals(alarm_aim))
                {
                    Alarm(this);
                }
                else
                {
                    Tick(this);
                }
                System.Threading.Thread.Sleep(1000);
            }

        }
       
        
    }
    class Clock
    {
        Clock_runtime c = new Clock_runtime();
        public Clock(string alarm)
        {
            c.alarm_aim = alarm;
            c.Tick += ticking;
            c.Alarm += alarming;
            c.Time();
        }
        void ticking(object sender)
        {
            Console.WriteLine($"你的生命又过去一秒\tnow: {DateTime.Now.ToLongTimeString()}");
        }
        void alarming(object sender)
        {
            Console.WriteLine("bilibili\r\ntime~!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0, max = int.MinValue, min = int.MaxValue;
            Random rd=new Random();
            GenericList<int> list = new GenericList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(rd.Next());
            }
            list.Foreach(data =>  Console.WriteLine(data));
            list.Foreach(data =>  max = data > max ? data : max );
            list.Foreach(data => { min = data < min ? data : min; });
            list.Foreach(data => { sum += data; });
            Console.WriteLine($"max:{max},min:{min},sum:{sum}");

            Clock clock = new Clock("16:25");
            


        }
    }


}
