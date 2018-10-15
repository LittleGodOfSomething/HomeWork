using System;
using System.Collections.Generic;
using System.Text;

namespace Abonent
{
    class Abon
    {
        //поля
        private string id;
        private string fio;
        private string adress;
        private string cardNum;
        private int debet;
        private int credit;
        private int talkTime;
        private int crossTownTime;
        

        private bool PassCheck(string ePass)
        {
            if (ePass == "*8werb34-+bdd/`3vs")//сюда можно втавить пароль из пассГенератора какого-нибудь
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Abon(string fio, string id, string adress, string cardNum, int debet, int credit, int talkTime, int crossTownTime, string AdminPass)//конструктор заполнения
        {
            if (PassCheck(AdminPass))
            {
                this.fio = fio;
                this.id = id;
                this.adress = adress;
                this.cardNum = cardNum;
                this.debet = debet;
                this.credit = credit;
                this.talkTime = talkTime;
                this.crossTownTime = crossTownTime;
            }
            else
            {
                ///Destroy(this);
                Console.WriteLine("Неверный пароль Администратора, бандит. :)");
                return;
            }
            
        }
               
        public string FIO {get { return fio; } }//гет ФИО
        public int GetTalkTime { get { return talkTime; } }//гет Время балака
        public int GetCrossTownTalkTime { get { return crossTownTime; } }//гет время междуТаун балака

        public void Info()//вывод информации об этом абоненте
        {
            Console.Write($"\nФИО: {fio}\nИНН: {id}\nАдрес: {adress}\nНомер карты: {cardNum}\nДебет: {debet}\nКредит: {credit}\nВремя разговоров по городу: {AdoptedTime(talkTime)}\nВремя междугородних: {AdoptedTime(crossTownTime)}\n");
        }

        private string AdoptedTime(int time)//конвертируем время из секунд в нормальное для удобства всприятия
        {
            int c = time % 60;
            int a = (int)((time / 60) / 60);
            int b = (int)((time / 60) % 60);

            return String.Format("{0}:{1}:{2}", a.ToString("00"), b.ToString("00"), c.ToString("00"));
        }
    }
}
