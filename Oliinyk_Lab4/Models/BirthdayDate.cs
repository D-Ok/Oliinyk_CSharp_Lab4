using System;

namespace Oliinyk_Lab4.Models
{
    internal static class BirthdayDate
    {

        internal static string[] ChineseHoroscope = {"Monkey",  "Rooster", "Dog",  "Pig",
            "Rat", "Bul", "Tiger", "Rabbit","Dragon", "Snake","Horse",  "Sheep"   };

        internal static string[] WestHoroscope =
        {
            "Aquarius", "Pisces",  "Aries", "Taurus" ,"Gemini" , "Cancer" ,
            "Leo" ,"Virgo" , "Libra","Scorpio" ,"Sagittarius" , "Capricorn"
        };

        private static int[] WestBeginDates = { 21, 21, 21, 21, 21, 22, 23, 24, 24, 24, 23, 22 };
        
        //обрахування знаку китайського гороскопу
        internal static string ChineseSign(DateTime birthday)
        {
            return ChineseHoroscope[birthday.Year % 12];
        }

        //обрахування знаку західного гороскопу
        internal static string SunSign(DateTime birthday)
        {
            if (birthday.Day < WestBeginDates[birthday.Month - 1])
            {
                if (birthday.Month == 1)
                    return WestHoroscope[11];
                else return WestHoroscope[birthday.Month - 2];
            }
            else return WestHoroscope[birthday.Month - 1];
        }

        //перевірка, чи введена дата народження правильна
        internal static bool IsCorrectDateOfBirthday(DateTime birthday)
        {
            return !IsFutureBirthday(birthday) && !IsPastBirthday(birthday);
        }
        //обрахування віку
        internal static int CalculateAge(DateTime birthday)
        {
            DateTime currentDate = DateTime.Now;
            if (currentDate.Month > birthday.Month) return currentDate.Year - birthday.Year;
            else if (currentDate.Month == birthday.Month && currentDate.Day >= birthday.Day) return currentDate.Year - birthday.Year;
            else return currentDate.Year - birthday.Year - 1;
        }
        //перевірка, чи введена дата народження в майбутньому
        internal static bool IsFutureBirthday(DateTime birthday)
        {
            return DateTime.Now < birthday;
        }
        //перевірка, чи введена дата народження в минулому дуже далеко
        internal static bool IsPastBirthday(DateTime birthday)
        {
            return CalculateAge(birthday) > 135;
        }
        //перевірка, чи день народження сьогодні
        internal static bool IsBirthday(DateTime birthday)
        {
            DateTime currentDate = DateTime.Now;
            return (currentDate.Month == birthday.Month && currentDate.Day == birthday.Day);
        }

        internal static bool IsAdult(DateTime birthday)
        {
            return (CalculateAge(birthday) >= 18);
        }
    }
}
