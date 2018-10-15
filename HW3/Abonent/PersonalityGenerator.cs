using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Abonent
{
    class PersonalityGenerator
    {
        private string names;
        private string cities;
        private string streets;
        private string[] sortedNames;
        private string[] sortedCities;
        private string[] sortedStreets;
        private Random random;

        public PersonalityGenerator()
        {
            random = new Random();
            names = File.ReadAllText(@"source\names.dll");
            cities = File.ReadAllText(@"source\cities.dll");
            streets = File.ReadAllText(@"source\streetsSorted.dll");
            sortedNames = names.Split('+', StringSplitOptions.RemoveEmptyEntries);
            sortedCities = cities.Split('+', StringSplitOptions.RemoveEmptyEntries);
            sortedStreets = streets.Split('+', StringSplitOptions.RemoveEmptyEntries);
        }

        public string GetName()
        {
            return sortedNames[random.Next(0, (sortedNames.Length - 1))];
        }

        public string GetCity()
        {
            return sortedCities[random.Next(0, (sortedCities.Length - 1))];
        }

        public string GetStreet()
        {
            return sortedStreets[random.Next(0, (sortedStreets.Length - 1))];
        }

        public string GetHomeNumber()
        {
            return (random.Next(0, 200)).ToString();
        }

        public string GetAppartmentNumber()
        {
            return (random.Next(0, 1000)).ToString();
        }

        public string GetCardNumber()
        {
            return String.Format("{0}-{1}-{2}-{3}", random.Next(4012, 4301).ToString("0000"), random.Next(0, 9999).ToString("0000"), random.Next(0, 9999).ToString("0000"), random.Next(0, 9999).ToString("0000"));
        }

        public int GetDebit()
        {
            return random.Next(0, 5000);
        }
        public int GetCredit()
        {
            return random.Next(0, 5000);
        }

        public int GetTimeSec()
        {
            return random.Next(0, 36001);
        }

        public string GetINN()
        {
            return String.Format("{0}{1}{2}", random.Next(1000, 10000).ToString("0000"), random.Next(0, 10000).ToString("0000"), random.Next(0, 10000).ToString("0000"));
        }


    }
}
