using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

namespace HomeWork_1
{
    class Calculon
    {
        //МЕТОД ВЫТЯГИВАНИЯ МАТЕМАТИЧЕСКОГО ВЫРАЖЕНИЯ ИЗ СТРОКИ, РЕШЕНИЕ(ФАЗА ДВА)

        string DealWithMath(string strExpression)
        {
            string workStr = strExpression; //присваиваем внутренней переменной значение выражения 

            List<string> listedExpression = new List<string>();//будущий лист с цифрами 

            foreach (char c in workStr) //перегоняем все символы в лист
            {
                listedExpression.Add(c.ToString());
            }

            for (int i = 0; i < listedExpression.Count - 1; i++) //отделяем числа от знаков 
            {
                if (char.IsDigit(listedExpression[i][0]) & char.IsDigit(listedExpression[i + 1][0]) || listedExpression[i + 1] == "," || listedExpression[i + 1] == ".")
                {
                    listedExpression[i] += listedExpression[i + 1];
                    listedExpression.RemoveAt(i + 1);
                    i--;
                }
            }

            for (int i = listedExpression.Count - 1; i > 0; i--)//вычисляем отрицательные числа по расположению знаков ОООООООООЧень долго вымучивал
            {

                if (!char.IsDigit(listedExpression[i][0]) & !char.IsDigit(listedExpression[i - 1][0]))
                {
                    listedExpression[i] += listedExpression[i + 1];
                    listedExpression.RemoveAt(i + 1);
                }
                if (i == 1 & !char.IsDigit(listedExpression[i - 1][0]))
                {
                    listedExpression[i - 1] += listedExpression[i];
                    listedExpression.RemoveAt(i);
                    break;
                }

            }

            //РЕШЕНИЕ ВЫРАЖЕНИЯ

            double result = 0;

            int tIndex;//индекс 

            while (listedExpression.Count > 1)//череда ифэлсоф с матманипуляциями пока в листе от выражения не останится только результат
            {
                try
                {
                    if (listedExpression.IndexOf("*") >= 0)
                    {
                        tIndex = listedExpression.IndexOf("*");
                        result = double.Parse(listedExpression[tIndex - 1]) * double.Parse(listedExpression[tIndex + 1]);
                        listedExpression.RemoveRange((tIndex - 1), 3);
                        listedExpression.Insert((tIndex - 1), result.ToString());
                    }
                    else
                    {
                        if (listedExpression.IndexOf("/") >= 0)
                        {

                            tIndex = listedExpression.IndexOf("/");

                            if (double.Parse(listedExpression[tIndex + 1]) == 0)
                            {
                                Console.WriteLine("To infinity... and beyond!!!!!");
                                result = 0;
                                break;
                            }
                            result = double.Parse(listedExpression[tIndex - 1]) / double.Parse(listedExpression[tIndex + 1]);
                            listedExpression.RemoveRange((tIndex - 1), 3);
                            listedExpression.Insert((tIndex - 1), result.ToString());
                        }
                        else
                        {
                            if (listedExpression.IndexOf("+") >= 0)
                            {
                                tIndex = listedExpression.IndexOf("+");
                                result = double.Parse(listedExpression[tIndex - 1]) + double.Parse(listedExpression[tIndex + 1]);
                                listedExpression.RemoveRange((tIndex - 1), 3);
                                listedExpression.Insert((tIndex - 1), result.ToString());
                            }
                            else
                            {
                                if (listedExpression.IndexOf("-") >= 0)
                                {
                                    tIndex = listedExpression.IndexOf("-");
                                    result = double.Parse(listedExpression[tIndex - 1]) - double.Parse(listedExpression[tIndex + 1]);
                                    listedExpression.RemoveRange((tIndex - 1), 3);
                                    listedExpression.Insert((tIndex - 1), result.ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("You probably have entered wrong sign somewhere.");
                    break;
                }

            }

            return result.ToString(); //возвращаем строку туда откуда запустился метод
        }

        //МЕТОД ОБРАБОТКИ СКОБОК(ПЕРВАЯ ФАЗА)

       public string bracketsFinder(string source)
        {
            double dSource;// тупо триггер 
            while (!double.TryParse(source, out dSource))//работает пока не пропарсится 
            {
                int inIndex = 0;//индекс первого вхождения скобки
                int outIndex = 0;//индекс первого вхождения обратной скобки, закрывающей
                string pieceOfExpression;

                for (int i = inIndex; i < source.Length; i++)//тут находим одно из самый внуттренних вложений
                {
                    if (source[i] == '(')
                    {
                        inIndex = i;
                    }
                    if (source[i] == ')')
                    {
                        outIndex = i;
                        //Console.WriteLine("Found Brackets!!!");
                        break;
                    }
                }

                if (outIndex > 0) //если скобки обнаружены, вытягиваем из них выражение и отправляем на решение, после чего на место скобок возвращаем результат 
                {
                    pieceOfExpression = source.Substring((inIndex + 1), ((outIndex - inIndex) - 1));
                    //Console.WriteLine(pieceOfExpression);
                    pieceOfExpression = DealWithMath(pieceOfExpression);
                    source = source.Remove(inIndex, ((outIndex - inIndex) + 1));
                    source = source.Insert(inIndex, pieceOfExpression);

                }
                else//если скибоньок нэма отправляем просто выражение на решение
                {
                    source = DealWithMath(source);
                }
            }

            return source;//возвращаем результат туда откуда запрашивали 
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculon calc = new Calculon();

            Console.InputEncoding = Encoding.Unicode;
            string sourceStr;
            string mETemplate = @"[0-9]+[\(\)\+\-\*\/\.\,]";//тестовая подборка для регулярок            

            //ПРИВЕТСТВИЕ 

            Console.WriteLine("CALCULATOR: Please press any Key\n");

            //КАК ГОВОРИЛ ЗОХАН: "ПОГНАЛИ"

            while (Console.ReadKey().Key != ConsoleKey.Escape) // Будет крутиться шарманка пока не будет нажата клавиша ЭCКАПЭ!!!!
            {
                Console.Clear();
                Console.WriteLine("Enter an expression. (It can be any expression. Even with brackets):\n");

                sourceStr = Console.ReadLine();//принимаем тексто
                sourceStr = sourceStr.Replace(" ", string.Empty); //чистим от пробелов 
                //Console.WriteLine(sourceStr);

                Regex matchFinder = new Regex(mETemplate);//тот самый класс
                                                          

                if (Regex.IsMatch(sourceStr, mETemplate))//проверяем на соответствие условию прохода, хз как назвать
                {
                    Console.WriteLine("\n{0}: {1}\n", "Your Result is", calc.bracketsFinder(sourceStr)); //ЗАПУСКАЕМ ВЕСЬ ПРОЦЕСС ЧЕРЕЗ КАЛЬКУЛОНА               
                }
                else
                {
                    Console.WriteLine("Bad expression!!");//ЧТО-то КТО-то наплужил 
                }
                Console.WriteLine("Press ESC for END!!!");

            }

        }
    }
}
