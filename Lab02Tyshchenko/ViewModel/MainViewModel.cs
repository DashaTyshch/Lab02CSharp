using Lab02Tyshchenko.Model;
using Lab02Tyshchenko.Tools;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Lab02Tyshchenko.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private MainModel _mainModel;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        private string _isAdult;
        private string _westernZodiac;
        private string _chineseZodiac;
        private string _isBirthdayToday;

        private Visibility _birthdayVisibility;

        private ICommand _backCommand;

        public MainViewModel(Storage storage)
        {
            _mainModel = new MainModel(storage);
            _mainModel.UIPersonChanged += UIOnPersonChanged;
        }

        private void UIOnPersonChanged(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            BirthDate = person.BirthdayDate;
            IsAdult = person.IsAdult ? "Так" : "Ні";
            WesternZodiac = person.SunSign;
            ChineseZodiac = person.ChineseSign;
            IsBirthdayToday = person.IsBirthday ? "Так" : "Ні";
            BirthdayVisibility = person.IsBirthday ? Visibility.Visible : Visibility.Collapsed;
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

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    InvokePropertyChanged(nameof(BirthDate));
                }
            }
        }

        public string IsAdult
        {
            get { return _isAdult; }
            set
            {
                if (_isAdult != value)
                {
                    _isAdult = value;
                    InvokePropertyChanged(nameof(IsAdult));
                }
            }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set
            {
                if (_westernZodiac != value)
                {
                    _westernZodiac = value;
                    InvokePropertyChanged(nameof(WesternZodiac));
                }
            }
        }
        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                if (_chineseZodiac != value)
                {
                    _chineseZodiac = value;
                    InvokePropertyChanged(nameof(ChineseZodiac));
                }
            }
        }
        public string IsBirthdayToday
        {
            get { return _isBirthdayToday; }
            set
            {
                if (_isBirthdayToday != value)
                {
                    _isBirthdayToday = value;
                    InvokePropertyChanged(nameof(IsBirthdayToday));
                }
            }
        }
        public Visibility BirthdayVisibility
        {
            get { return _birthdayVisibility; }
            set
            {
                if (_birthdayVisibility != value)
                {
                    _birthdayVisibility = value;
                    InvokePropertyChanged(nameof(BirthdayVisibility));
                }
            }
        }

        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new RelayCommand<object>(BackExecute, BackCanExecute);
                }
                return _backCommand;
            }
            set
            {
                _backCommand = value;
                InvokePropertyChanged(nameof(BackCommand));
            }
        }
        private void BackExecute(object obj)
        {
            _mainModel.ShowWelcome();
        }

        private bool BackCanExecute(object obj)
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
        }
    }
}
