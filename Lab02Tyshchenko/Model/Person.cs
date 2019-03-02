using System;

namespace Lab02Tyshchenko.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthdayDate { get; set; }

        public Person(string name, string surname, string email, DateTime birthdayDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthdayDate = birthdayDate;
        }
        public Person(string name, string surname, DateTime birthdayDate)
        {
            Name = name;
            Surname = surname;
            BirthdayDate = birthdayDate;
        }
        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public bool IsAdult
        {
            get
            {
                var age = DateTime.Today.Date.Year - BirthdayDate.Date.Year;
                if (BirthdayDate > DateTime.Today.AddYears(-age))
                    age--;

                if (age >= 18)
                    return true;
                return false;
            }
        }

        public string SunSign
        {
            get
            {
                return FindWestZodiac(BirthdayDate);
            }
        }

        public string ChineseSign
        {
            get
            {
                return FindCheneseZodiac(BirthdayDate.Year);
            }
        }

        public bool IsBirthday
        {
            get
            {
                return BirthdayDate.DayOfYear == DateTime.Today.DayOfYear;
            }
        }

        private string FindWestZodiac(DateTime date)
        {
            var day = date.Day;
            var month = date.Month;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
                return "Овен";
            if ((month == 4 && day >= 21) || (month == 5 && day <= 20))
                return "Тілець";
            if ((month == 5 && day >= 21) || (month == 6 && day <= 21))
                return "Близнюки";
            if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
                return "Рак";
            if ((month == 7 && day >= 23) || (month == 8 && day <= 23))
                return "Лев";
            if ((month == 8 && day >= 24) || (month == 9 && day <= 23))
                return "Діва";
            if ((month == 9 && day >= 24) || (month == 10 && day <= 22))
                return "Терези";
            if ((month == 10 && day >= 23) || (month == 11 && day <= 22))
                return "Скорпіон";
            if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
                return "Стрілець";
            if ((month == 12 && day >= 22) || (month == 1 && day <= 20))
                return "Козеріг";
            if ((month == 1 && day >= 21) || (month == 2 && day <= 19))
                return "Водолій";
            if ((month == 2 && day >= 20) || (month == 3 && day <= 20))
                return "Риби";
            return "Упсс, щось пішло не так!";
        }

        private string FindCheneseZodiac(int year)
        {
            var modY = year % 12;

            switch (modY)
            {
                case 0:
                    return "Мавпа";
                case 1:
                    return "Півень";
                case 2:
                    return "Собака";
                case 3:
                    return "Свиня";
                case 4:
                    return "Пацюк";
                case 5:
                    return "Бик";
                case 6:
                    return "Тигр";
                case 7:
                    return "Кролик";
                case 8:
                    return "Дракон";
                case 9:
                    return "Змія";
                case 10:
                    return "Кінь";
                case 11:
                    return "Вівця";
                default:
                    return "Упсс, щось пішло не так!";
            }
        }
    }
}
