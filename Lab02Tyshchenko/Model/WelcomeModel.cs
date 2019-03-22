using Lab02Tyshchenko.Exceptions;
using Lab02Tyshchenko.Navigation;
using System;

namespace Lab02Tyshchenko.Model
{
    class WelcomeModel
    {
        private Storage _storage;

        public WelcomeModel(Storage storage)
        {
            _storage = storage;
        }

        public void Login(string name, string surname, string email, DateTime date)
        {
            ValidateData(email, date);

            Person person = new Person(name, surname, email, date);
            _storage.ChangeInfo(person);

            NavigationManager.Instance.Navigate(ModesEnum.Main);
        }

        private void ValidateData(string email, DateTime date)
        {
            var age = CalculateAge(date);

            if (age < 0)
                throw new FutureBirthdayException(date);
            if (age >= 135)
                throw new DistantPastBirthdayException(date);

            try
            {
                var _ = new System.Net.Mail.MailAddress(email);
            }
            catch (FormatException)
            {
                throw new InvalidEmailException(email);
            }
        }

        private int CalculateAge(DateTime dateTime)
        {
            var age = DateTime.Today.Date.Year - dateTime.Date.Year;
            if (dateTime > DateTime.Today.AddYears(-age))
                age--;
            return age;
        }
    }
}
