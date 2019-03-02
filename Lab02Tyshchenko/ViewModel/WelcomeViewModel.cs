using Lab02Tyshchenko.Model;
using Lab02Tyshchenko.Tools;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Lab02Tyshchenko.ViewModel
{
    class WelcomeViewModel : INotifyPropertyChanged
    {
        private WelcomeModel _welcomeModel;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _date;

        private ICommand _proceedCommand;

        public WelcomeViewModel(Storage storage)
        {
            _welcomeModel = new WelcomeModel(storage);
            _date = DateTime.Today.Date;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    InvokePropertyChanged(nameof(Name));
                }
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    InvokePropertyChanged(nameof(Surname));
                }
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    InvokePropertyChanged(nameof(Email));
                }
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    InvokePropertyChanged(nameof(Date));
                }
            }
        }
        public ICommand ProceedCommand
        {
            get
            {
                if (_proceedCommand == null)
                {
                    _proceedCommand = new RelayCommand<object>(ProceedExecute, ProceedCanExecute);
                }
                return _proceedCommand;
            }
            set
            {
                _proceedCommand = value;
                InvokePropertyChanged(nameof(ProceedCommand));
            }
        }

        private bool ProceedCanExecute(object obj)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(Email))
                return false;

            return true;
        }

        private void ProceedExecute(object obj)
        {
            var age = _welcomeModel.CalcAge(_date);

            if (age < 0)
                MessageBox.Show("Ви ще не народилися :)", "Помилка");
            else if (age >= 135)
                MessageBox.Show("Невже хтось так довго живе? :)", "Помилка");
            else
                _welcomeModel.Login(Name,Surname,Email,Date);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
        }

    }
}
