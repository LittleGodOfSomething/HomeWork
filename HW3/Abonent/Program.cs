using System;
using System.Text;
using System.Collections.Generic;

namespace Abonent
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;//опять гемор с этой херью
            Console.InputEncoding = Encoding.UTF8;
            PersonalityGenerator gen = new PersonalityGenerator();

            List<Abon> listOfAbonents = new List<Abon>();//список абонентов 

            for (int i = 0; i < 100; i++)//заполняем абонента при помощи класса-генератора
            {
                listOfAbonents.Add(new Abon(gen.GetName(), gen.GetINN(), String.Format("г.{0} Ул.{1}, дом {2}, кв. {3}", gen.GetCity(), gen.GetStreet(), gen.GetHomeNumber(), gen.GetAppartmentNumber()),gen.GetCardNumber(),gen.GetDebit(),gen.GetCredit(),gen.GetTimeSec(),gen.GetTimeSec(), "*8werb34-+bdd/`3vs"));
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Чего хотите?:\n1 - Вывести профайлы абонентов что говорили по городу больше установленного времени.\n2 - Список абонентов что пользовались междугородкой.\n3 - список абонентов в алфавитном порядке.");

                switch (Console.ReadLine())
                {
                    case "1":
                        CheckTalk();
                        break;
                    case "2":
                        CheckCrossTownTalk();
                        break;
                    case "3":
                        AlphabetSorting();
                        break;
                    case "4":
                        CreateNewAbonent();
                        break;
                    default:
                        Console.WriteLine("Ой, что-то не то.");
                        break;
                }

                Console.ReadKey();

            }        

            void CheckTalk()//работа первого запроса
            {
                Console.WriteLine("Введите количество секунд:");
                int targetSec = int.Parse(Console.ReadLine());
                for (int i = 0; i < listOfAbonents.Count; i++)
                {
                    if (listOfAbonents[i].GetTalkTime >= targetSec)
                    {
                        Console.WriteLine($"\nАбонент №: {i}");
                        listOfAbonents[i].Info();
                    }
                }
            }

            void CheckCrossTownTalk()//работа второго запроса
            {
                Console.WriteLine("Введите количество секунд:");
                
                for (int i = 0; i < listOfAbonents.Count; i++)
                {
                    if (listOfAbonents[i].GetCrossTownTalkTime > 0)
                    {
                        Console.WriteLine($"\nАбонент №: {i}");
                        listOfAbonents[i].Info();
                    }
                }
            }

            void AlphabetSorting()//работа третьего запроса
            {
                for (int i = 0; i < listOfAbonents.Count; i++)
                {
                    for (int j = i + 1; j < listOfAbonents.Count; j++)
                    {
                        Abon tempAbonent;

                        if (listOfAbonents[i].FIO.ToUpper()[0] >= listOfAbonents[j].FIO.ToUpper()[0])//алфавитный пузырь
                        {

                            tempAbonent = listOfAbonents[i];
                            listOfAbonents[i] = listOfAbonents[j];
                            listOfAbonents[j] = tempAbonent;

                        }
                    }
                }

                for (int i = 0; i < listOfAbonents.Count; i++)//вывод абонентов
                {

                    listOfAbonents[i].Info();

                }
            }

            void CreateNewAbonent()
            {               
                Console.WriteLine("Введите данные(ФИО, ИНН, Адрес, Номер карты в формате ХХХХ-ХХХХ-ХХХХ-ХХХХ и пароль администратора).\nРазделяйте ввод нажатием клавиши ENTER");                
                listOfAbonents.Add(new Abon(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(),0,0,0,0, Console.ReadLine()));//:)                
                ClearEmpty();
            }
            void ClearEmpty()
            {
                listOfAbonents.RemoveAt(listOfAbonents.Count - 1);
            }
        }


    }
}
