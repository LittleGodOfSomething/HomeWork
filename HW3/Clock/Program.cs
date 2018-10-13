using System;
using System.Threading;

namespace HW3
{

    class Clock
    {
        public int option = 0;
        public int hour;
        public int minute;
        public int second;

        public Clock(int h, int m, int s)//пользовательский конструктор
        {
            hour = h;
            minute = m;
            second = s;
        }

        public void Tick()//метод тиканья 
        {
            second++;
            if (second >= 60)
            {
                minute++;
                second = 0;
            }

            if (minute >= 60)
            {
                hour++;
                minute = 0;
            }

            if (hour > 23)
            {
                hour = 0;
                minute = 0;
                second = 0;
            }

            DisplayTime();
        }

        public void DisplayTime() //отображение времени. И опций.
        {
            Console.Clear();
            Console.Write("\nВаше время: {0}:{1}:{2}\n", hour.ToString("00"), minute.ToString("00"), second.ToString("00"));
            Console.WriteLine("\nОпции:\nИзменить часы: F1\nИзменить минуты: F2\nИзменить секунды: F3\n");
            switch (option)//если выбор опции состоялся отображаем дополнительную строку. ну тип для удобства. 
            {
                case 1:
                    Console.WriteLine("Введите часы: ");
                    break;
                case 2:
                    Console.WriteLine("Введите минуты: ");
                    break;
                case 3:
                    Console.WriteLine("Введите секунды: ");
                    break;
                default:
                    break;
            }
        }
    }

    class Program
    {        
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Введите часы минуы и секунды, разделяя ввод клавишей Enter: ");
            Clock clock = new Clock(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));            

            Thread threadOne = new Thread(One); //первый поток отвечает за тиканье будильника, ну и там еще за отображение его и опций
            Thread threadTwo = new Thread(Two); //второй будет отвечать за выбор опции и ввод результата. 
            threadOne.Start();
            threadTwo.Start();

            void One()
            {
                while (true)
                {
                    clock.Tick();
                    Thread.Sleep(1000);
                }
            }
            void Two()
            {
                while (true)
                {

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.F1:
                            clock.option = 1;
                            clock.hour = int.Parse(Console.ReadLine());
                            clock.option = 0;
                            break;
                        case ConsoleKey.F2:
                            clock.option = 2;
                            clock.minute = int.Parse(Console.ReadLine());
                            clock.option = 0;
                            break;
                        case ConsoleKey.F3:
                            clock.option = 3;
                            clock.second = int.Parse(Console.ReadLine());
                            clock.option = 0;
                            break;
                        default:
                            Console.WriteLine("Не то ввели!!!");
                            break;
                    }
                }
            }            
        }
    }
}
