using System;

namespace Abonent
{
    class Abonent
    {
        private string id;
        private string fio;
        private string adress;
        private string cardNum;
        private int debet;
        private int credit;
        private int talkTime;

        public Abonent(string id, string fio, string adress, string cardNum, int debet, int credit, int talkTime)
        {
            this.id = id;
            this.fio = fio;
            this.adress = adress;
            this.cardNum = cardNum;
            this.debet = debet;
            this.credit = credit;
            this.talkTime = talkTime;
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You asshole");
            Console.WriteLine("I'm kidding");
        }
    }
}
