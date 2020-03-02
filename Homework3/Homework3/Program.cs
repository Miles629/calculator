/*
作者:马草原
学号：2018302110150
日期：2020/03/02
班级：计算机学院2018级软工二班
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    //1. 编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 请尝试合理使用接口、属性来实现。
    public interface Shape
    {
        double get_area();
        bool is_legal();
        double Area { get; }
    }
    public class Rectangle:Shape
    {
        protected double _length;
        protected double _width;
        public Rectangle(double l,double w)
        {
            _length = l;
            _width = w;
        }
        public double Length{ 
            get
            { 
                return _length;
            }
            set
            {
                _length = value;
            }
        }
        public double Width { get=>_width; set=>_width=value; }
        public double Area
        {
            get { return get_area(); }
        }
        public double get_area()
        {
            return _length*_width;
        }
        public bool is_legal()
        {
            if (_length > 0 && _width > 0)
                return true;
            else
                return false;
        }
    }
    public class Square:Rectangle,Shape
    {
        public double Area
        {
            get { return get_area(); }
        }
        public Square(double s):base(s,s)
        {
        }
        public double Side
        {
            get
            {
                return _length;
            }
            set
            {
                _length = _width = value;
            }
        }
        public new bool is_legal()
        {
            if (_length == _width && _length > 0)
                return true;
            else
                return false;
        }
    }
    class Triangle:Shape
    {
        public double Area
        {
            get { return get_area(); }
        }
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        //public double Side1 { get=>_side1; set; }
        //public double Side2 { get; set; }
        //public double Side3 { get; set; }
        public Triangle(double a,double b,double c)
        {
            Side1 = a;
            Side2 = b;
            Side3 = c;
        }

        public double get_area()
        {
            double p = (Side1 + Side2 + Side3) / 2;
            double s=Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
            return s;
        }
        public bool is_legal()
        {
            if ((Side1 + Side2) > Side3 && (Side3 + Side2) > Side1 && (Side1 + Side3) > Side2&&Side1>0&&Side2>0&&Side3>0)
                return true;
            else
                return false;
        }
    }
    //2. 随机创建10个形状对象，计算这些对象的面积之和。 尝试使用简单工厂设计模式来创建对象。
    class Factory
    {
        //静态工厂方法  
        public static Shape getShape(String arg,double s1=0,double s2=0,double s3=0)
        {
            Shape product = null;
            if (arg.Equals("Rectangle"))
            {
                product = new Rectangle(s1,s2);
            }
            else if (arg.Equals("Square"))
            {
                product = new Square(s1);
            }
            else if (arg.Equals("Triangle"))
            {
                product = new Triangle(s1,s2,s3);
            }
            return product;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1编写面向对象程序实现长方形、正方形、三角形等形状的类。练习接口属性等
            Rectangle r = new Rectangle(4, 5);
            r.Length = 5; r.Width = 6;
            if (r.is_legal())
            {
                Console.WriteLine("r_get_area:" + r.Area);
                Console.WriteLine("r_is_legal:" + r.is_legal());
            }
            Square s = new Square(5);
            s.Side = 6;
            if(s.is_legal())
            {
                Console.WriteLine("s_get_area:" + s.Area);
                Console.WriteLine("s_is_legal:" + s.is_legal());
            }
            Triangle t = new Triangle(3, 4, 5);
            t.Side1 = 6;
            t.Side2 = 8;
            t.Side3 = 10;
            if(t.is_legal())
            {
                Console.WriteLine("t_get_area:" + t.Area);
                Console.WriteLine("t_is_legal:" + t.is_legal());
            }
            //2工厂方法test
            Shape shape = Factory.getShape("Square", 4);
            //随机通过工厂方法创建10个随机形状并计算面积和
            Random rd = new Random();
            double sum_area=0;
            int i = 0;
            int temp=0;
            while(i<10)
            {
                temp = rd.Next() % 3;
                if (temp == 0)
                {
                    shape= Factory.getShape("Square", rd.NextDouble()*10+1);
                    if (!shape.is_legal())
                        continue;
                    Console.WriteLine("第" + (i + 1) + "个图形Square，面积：" + shape.Area);
                }
                else if(temp == 1)
                {
                    shape = Factory.getShape("Rectangle", rd.NextDouble() * 10 + 1, rd.NextDouble() * 10 + 1);
                    if (!shape.is_legal())
                        continue;
                    Console.WriteLine("第" + (i + 1) + "个图形Rectangle，面积：" + shape.Area);
                }
                else if(temp == 2)
                {
                    shape = Factory.getShape("Triangle", rd.NextDouble() * 10 + 1, rd.NextDouble() * 10 + 1, rd.NextDouble() * 10 + 1);
                    if (!shape.is_legal())
                        continue;
                    Console.WriteLine("第" + (i + 1) + "个图形Triangle，面积：" + shape.Area);
                }
                sum_area += shape.Area;
                i = i + 1;
            }
            Console.WriteLine("10个随机图形面积和:" + sum_area);

        }
    }

}
