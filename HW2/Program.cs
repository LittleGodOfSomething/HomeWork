using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
namespace HW2
{
    //КЛАССЫ
    class Order
    {
        public string payer;
        public string getter;
        public double rate;
    }

    class Worker
    {
        public string fio; //fio
        public string position;// position
        public int yoe;// the year of staring employment

    }

    class Price
    {
        public string productName; 
        public string storeName;
        public double price;
    }

    class Books
    {
        string title;
        string autor;
        int cost;

        public Books(string t, string a, int c)//конструктор по умолчанию
        {
            title = t;
            autor = a;
            cost = c;
        }

       public void ShowAtributs()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(autor);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(cost);
        }
    }

    class Rec
    {
        private double side1;
        private double side2;

        public double Side1 { get; }
        public double Side2 { get; }

        public Rec(double s1, double s2)
        {
            side1 = s1;
            side2 = s2;
        }

        public double AreaCalculator()
        {
            double c;
            c = side1 * side2;
            return c; ;
        }

        public double PerimeterCalculator()
        {
            double c;
            c = (side1 + side2) * 2;
            return c;
        }
    }

    class Point
    {
        private int a;
        private int b;
        private string name;

        public Point(int x, int y, string marker)
        {
            a = x;
            b = y;
            name = marker;
        }

        public int A { get => a; }
        
        public int B { get => b; }
        
        public string Name { get => name; }
        
    }

    class Figure
    {

        public double sideLength(Point a, Point b)
        {
            double result = Math.Sqrt(Math.Pow((b.A - a.A), 2) + Math.Pow((b.B - a.B), 2)); // расстояние между двумя точками с координатами X и Y в двухмерном пространстве.
            return result;
        }


        public double FigurePerimeter(Point a, Point b, Point c)
        {
            double x = sideLength(a, b) + sideLength(b, c) + sideLength(c, a);
            return x;
        }
        public double FigurePerimeter(Point a, Point b, Point c, Point d)
        {
            double x = sideLength(a, b) + sideLength(b, c) + sideLength(c, d) + sideLength(d, a);
            return x;
        }
        public double FigurePerimeter(Point a, Point b, Point c, Point d, Point e)
        {
            double x = sideLength(a, b) + sideLength(b, c) + sideLength(c, d) + sideLength(d, e) + sideLength(e, a);
            return x;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            
            string orderPattern = @"\b\d{4}-\d{5}-\d{5}\b";
            string workerNamePattern = @"[a-z]|[A-Z]";
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            List<Order> q = new List<Order>();
            List<Worker> w = new List<Worker>();
            List<Price> p = new List<Price>();
            List<Books> b = new List<Books>();
            List<Point> pp = new List<Point>();

            //ПРОВЕРЯЕМ ВВЕДЕННЫЕ ДАННЫЕ НА СООТВЕТСТВИЕ

            bool CheckInput(string inputStr, string patt)
            {
                if (Regex.IsMatch(inputStr, patt))
                {
                    return true;
                }
                else
                {

                    switch (patt)
                    {
                        case @"\b\d{4}-\d{5}-\d{5}\b":
                            Console.WriteLine("Wrong input! Must be 14 digits. Not letters or spetial symbols.\nMust accord to the next pattern: ****-*****-*****");
                            break;
                        case @"[a-z]|[A-Z]":
                            Console.WriteLine("Wrong input!! Must be only a letters");
                            break;
                    }

                    return false;
                }

            }

            //ПОИСК И ВЫВОД СОВПАДЕНИЯ ПО УСЛОВИЮ

            void FindMatchesOrders()
            {
                Console.WriteLine("Enter an amount: ");
                double d = double.Parse(Console.ReadLine());

                if (d > 0)
                {
                    Console.WriteLine("\nFound matches in:\n");

                    for (int i = 0; i < q.Count; i++)
                    {
                        if (q[i].rate >= d)
                        {
                            Console.WriteLine(q[i].payer);
                            Console.WriteLine(q[i].getter);
                            Console.WriteLine(q[i].rate.ToString() + "\n");
                        }
                    }
                }
            }
            void FindMatchesWorkers()
            {
                Console.WriteLine("Enter an amount: ");
                int d = int.Parse(Console.ReadLine());

                if (d > 0)
                {
                    Console.WriteLine("\nFound matches in:\n");

                    for (int i = 0; i < w.Count; i++)
                    {
                        if (w[i].yoe >= d)
                        {
                            Console.WriteLine(w[i].fio);
                            Console.WriteLine(w[i].position);
                            Console.WriteLine(w[i].yoe.ToString() + "\n");
                        }
                    }
                }
            }
            void FindMatchesPrices()
            {
                Console.WriteLine("Enter an amount: ");
                double d = double.Parse(Console.ReadLine());

                if (d > 0)
                {
                    Console.WriteLine("\nFound matches in:\n");

                    for (int i = 0; i < p.Count; i++)
                    {
                        if (p[i].price >= d)
                        {
                            Console.WriteLine(p[i].productName);
                            Console.WriteLine(p[i].storeName);
                            Console.WriteLine(p[i].price.ToString() + "\n");
                        }
                    }
                }
            }

            //ЗАПОЛНЕНИЕ ИНФОРМАЦИИ 

            void FillOrders()
            {

                string tempstring;
                double tempDouble;
                int numOFFullOrders = 0;

                do
                {
                    q.Add(new Order());

                    Console.Clear();
                    Console.WriteLine("\nNumber of full orders is: {0}\n", numOFFullOrders.ToString());
                    while (true)
                    {
                        Console.WriteLine("\nEnter the payer payment account:");
                        tempstring = Console.ReadLine();
                        if (CheckInput(tempstring, orderPattern))
                        {
                            q[q.Count - 1].payer = tempstring;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You probably entered something wrong");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("\nEnter the getter payment account:");
                        tempstring = Console.ReadLine();

                        if (CheckInput(tempstring, orderPattern))
                        {
                            q[q.Count - 1].getter = tempstring;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You probably entered something wrong");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("\nEnter Amount of payment:");
                        tempDouble = double.Parse(Console.ReadLine());

                        if (tempDouble != 0)
                        {
                            q[q.Count - 1].rate = tempDouble;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You probably entered something wrong");
                        }
                    }
                    numOFFullOrders++;
                    Console.WriteLine("\nESCAPE for exit\n");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);

                Sort(1);
                FindMatchesOrders();
            }          

            void FillWorkers()
            {
                string tempstring;
                int tempInt;
                int numOFWorkers = 0;

                do
                {
                    w.Add(new Worker());

                    Console.Clear();
                    Console.WriteLine("\nNumber of workers is: {0}\n", numOFWorkers.ToString());
                    while (true)
                    {
                        Console.WriteLine("\nEnter worker FIO:");
                        tempstring = Console.ReadLine();
                        if (CheckInput(tempstring, workerNamePattern))
                        {
                            w[w.Count - 1].fio = tempstring;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You probably entered something wrong");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("\nEnter the worker position:");
                        tempstring = Console.ReadLine();

                        if (CheckInput(tempstring, workerNamePattern))
                        {
                            w[w.Count - 1].position = tempstring;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You probably entered something wrong");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("\nEnter the year of starting employment:");
                        tempInt = int.Parse(Console.ReadLine());

                        if (tempInt != 0)
                        {
                            w[w.Count - 1].yoe = tempInt;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You probably entered something wrong");
                        }
                    }
                    numOFWorkers++;
                    Console.WriteLine("\nESCAPE for exit\n");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);

                Sort(2);
                FindMatchesWorkers();
            }

            void FillPrices()
            {
                string tempstring;
                double tempDouble;
                int numOFProducts = 0;

                do
                {
                    p.Add(new Price());

                    Console.Clear();
                    Console.WriteLine("\nNumber of products is: {0}\n", numOFProducts.ToString());
                    while (true)
                    {
                        Console.WriteLine("\nEnter a product name:");
                        tempstring = Console.ReadLine();
                        if (CheckInput(tempstring, workerNamePattern))
                        {
                            p[p.Count - 1].productName = tempstring;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You probably entered something wrong");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("\nEnter the product store:");
                        tempstring = Console.ReadLine();

                        if (CheckInput(tempstring, workerNamePattern))
                        {
                            p[p.Count - 1].storeName = tempstring;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You probably entered something wrong");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("\nEnter the product price:");
                        tempDouble = double.Parse(Console.ReadLine());

                        if (tempDouble != 0)
                        {
                            p[p.Count - 1].price = tempDouble;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You probably entered something wrong");
                        }
                    }
                    numOFProducts++;
                    Console.WriteLine("\nESCAPE for exit\n");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);

                Sort(2);
                FindMatchesPrices();
            }

            void FillBooks()
            {
                do
                {
                    Console.WriteLine("Введите введите название, автора и цену книги через Enter");

                    b.Add(new Books(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine())));

                    Console.WriteLine("Wanna enter more? ESC - No");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);

                    if (b.Count > 0)
                {
                    Console.WriteLine("Перечень книг:\n");

                    foreach (Books a in b)
                    {
                        a.ShowAtributs();
                        Console.Write("\n");
                    }
                }
                else
                {
                    Console.WriteLine("Вы ничего не ввели");
                }
            }

            void FillRectangle()
            {
                Console.Clear();
                Console.WriteLine("Необходимо ввести динну двух сторон прямоугольника, разделяя ввод нажатем клавиши Enter:\n");

                Rec rectangle = new Rec(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));

                double temp = rectangle.AreaCalculator();

                Console.WriteLine("Area equals to: {0}", temp.ToString());

                temp = rectangle.PerimeterCalculator();

                Console.WriteLine("Perimeter equals to: {0}", temp.ToString());
            }

            void FillPoints()
            {
                
                do
                {
                    Console.Clear();

                    Console.WriteLine("Необходимо ввести координаты минимум трех точек для вычисления фигуры и ее периметра...\n");

                    Console.WriteLine("Введите координаты Х, У и название точки {0}, разделяя ввод клавишей Enter", (pp.Count + 1));

                    pp.Add(new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), Console.ReadLine()));

                    Console.WriteLine("Прекратить ввод - ESCAPE");

                } while (Console.ReadKey().Key != ConsoleKey.Escape);

                Figure figure = new Figure();

                switch (pp.Count)
                {
                    case 3 :
                        Console.Clear();
                        Console.WriteLine("Это скорее всего треугольник с периметром {0}", figure.FigurePerimeter(pp[0],pp[1],pp[2]).ToString());
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Это скорее всего какой-то квад с периметром {0}", figure.FigurePerimeter(pp[0], pp[1], pp[2], pp[3]).ToString());
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("УУУууууУ. Пятиугольник с периметром {0}", figure.FigurePerimeter(pp[0], pp[1], pp[2], pp[3], pp[4]).ToString());
                        break;
                }
            }

            //МЕТОД СОРТИРОВКИ 

            void Sort(int index)
            {

                switch (index)
                {
                    case 1:
                        OrdersSort();
                        break;
                    case 2:
                        WorkersSort();
                        break;
                }


                void OrdersSort()
                {
                    for (int i = 0; i < q.Count; i++)
                    {
                        for (int j = i + 1; j < q.Count; j++)
                        {
                            Order tempOrder;

                            if (q[i].rate <= q[j].rate)
                            {

                                tempOrder = q[i];
                                q[i] = q[j];
                                q[j] = tempOrder;

                            }
                        }
                    }
                }
                void WorkersSort()
                {
                    for (int i = 0; i < w.Count; i++)
                    {
                        for (int j = i + 1; j < w.Count; j++)
                        {
                            Worker tempWorker;

                            if (w[i].fio.ToUpper()[0] >= w[j].fio.ToUpper()[0])
                            {

                                tempWorker = w[i];
                                w[i] = w[j];
                                w[j] = tempWorker;

                            }
                        }
                    }
                    for (int i = 0; i < w.Count; i++)
                    {
                        Console.Write(" " + w[i].fio);
                    }

                }

            }

            //СПРАШИВАЕМ НОМЕР ЗАДАЧИ

            Console.WriteLine("Укажите номер задачи[1-6]:");

            switch (Console.ReadKey().Key)
            {

                case ConsoleKey.D1:
                    FillOrders();
                    break;
                case ConsoleKey.D2:
                    FillWorkers();
                    break;
                case ConsoleKey.D3:
                    FillPrices();
                    break;
                case ConsoleKey.D4:
                    FillRectangle();
                    break;
                case ConsoleKey.D5:
                    FillBooks();                    
                    break;
                case ConsoleKey.D6:
                    FillPoints();
                    break;
                default:
                    break;
            }

            

            Console.ReadLine();
        }
    }
}
