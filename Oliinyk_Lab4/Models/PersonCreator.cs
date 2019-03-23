using System;

namespace Oliinyk_Lab4.Models
{
    internal static class PersonCreator
    {
        private static string[] Names = {
            "Emma", "Sofia", "Ella", "Madison", "Scarlett", "Victoria", "Aria", "Grace","Chloe", "Camila",
            "Penelope", "Riley","Layla","Lillian","Nora",   "Zoey",    "Mila",  "Aubrey", "Hannah", "Lily",
            "Addison","Eleanor", "Natalie","Luna","Savannah","Liam","Noah","William","James","Logan",
            "Benjamin", "Mason", "Elijah", "Oliver", "Jacob", "Lucas", "Michael", "Alexander", "Ethan", "Daniel",
            "Matthew", "Aiden", "Henry", "Joseph", "Jackson", "Samuel", "Sebastian", "David", "Carter", "Wyatt" };

        private static string[] Surnames =
        {
            "Smith", "Johnson", "Jones", "Williams", "Brown", "Davis", "Miller", "Wilson","Moore", "Taylor",
            "Anderson", "Thomas","Jackson","White","Harris",   "Martin",    "Thompson",  "Garcia", "Martinez", "Robinson",
            "Clark","Rodriguez", "Lewis","Lee","Walker","Hall","Allen","Young","Hernandez","King",
            "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Howard",
            "Mitchell", "Perez", "Roberts", "Turner", "Phillips", "Campbell", "Parker", "Evans", "Edwards", "Collins" };

        private static Random Rand = new Random();

        private static string GetRandomName()
        {
            return Names[Rand.Next(Names.Length)];
        }

        private static string GetRandomSurname()
        {
            return Surnames[Rand.Next(Surnames.Length)];
        }

        private static string GetRandomeEmail(string name, string surname)
        {
            return $"{name.ToLower()}{Rand.Next(999)}.{surname.ToLower()}{Rand.Next(999)}@gmail.com";
        }

        private static DateTime GetRandomeBirthday()
        {
            DateTime today = DateTime.Today;
            int year = Rand.Next(today.Year - 134, today.Year-1);
            int month = Rand.Next(1, 13);
            int date = Rand.Next(1, DateTime.DaysInMonth(year, month)+1);
            return new DateTime(year, month, date);
        }

        internal static Person CreateRandomePerson()
        {
            string name = GetRandomName();
            string surname = GetRandomSurname();
            return new Person(name, surname, GetRandomeEmail(name, surname), GetRandomeBirthday());
        }
    }
}
