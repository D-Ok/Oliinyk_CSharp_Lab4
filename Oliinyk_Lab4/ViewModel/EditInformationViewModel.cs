using Oliinyk_Lab4.Tools;
using System;
using Oliinyk_Lab4.Models;
using Oliinyk_Lab4.Tools.Managers;
using Oliinyk_Lab4.Tools.Navigation;
using System.Windows;

namespace Oliinyk_Lab4.ViewModels
{
    internal class EditInformationViewModel : BaseViewModel
    {
        private RelayCommand<object> _editCommand;
        private Person _person;
        private string _editedName;
        private string _editedSurname;
        private string _editedEmail;
        private string _birthday;
        private string _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private string _isBirthday;

        public string EditedName
        {
            get { return _editedName; }
            set
            {
                _editedName = value;
                OnPropertyChanged("EditedName");
            }
        }

        public string EditedSurname
        {
            get { return _editedSurname; }
            set
            {
                _editedSurname = value;
                OnPropertyChanged("EditedSurname");
            }
        }

        public string EditedEmail
        {
            get { return _editedEmail; }
            set
            {
                _editedEmail = value;
                OnPropertyChanged("EditedEmain");
            }
        }

        public Person Person
        {
            get { return _person; }
            private set { _person = value; }
        }

        public string IsAdult
        {
            get { return _isAdult; }
            private set  {  _isAdult = value;}
        }

        public string SunSign
        {
            get { return _sunSign; }
            private set { _sunSign = value;}
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            private set {_chineseSign = value;}
        }

        public string IsBirthday
        {
            get { return _isBirthday; }
            private set  {  _isBirthday = value; }
        }
        

        public string Birthday
        {
            get { return _birthday; }
            private set
            {
                _birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        internal EditInformationViewModel(Person person)
        {
            InitializePerson(ref person);
        }

        internal void InitializePerson(ref Person person)
        {
            _person = person;
            _editedName = person.Name;
            _editedSurname = person.Surname;
            _editedEmail = person.Email;
            Birthday = person.Birthday.ToShortDateString();
            if (person.IsBirthday) IsBirthday = "Today is your Birthday";
            else IsBirthday = "Today isn`t your Birthday";
            if (person.IsAdult) IsAdult = "You are adult";
            else IsAdult = "You are child";
            ChineseSign = person.ChineseSign;
            SunSign = person.SunSign;
        }


        public RelayCommand<Object> EditCommand
        {
            get { return _editCommand ?? (_editCommand = new RelayCommand<object>(EditImplementation, CanEditExecute)); }
        }

        private bool CanEditExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(EditedEmail) && !String.IsNullOrWhiteSpace(EditedName) && !String.IsNullOrWhiteSpace(EditedSurname);
        }

        private void EditImplementation(object obj)
        {
            bool ok = true;
            
            try
            {
                _person.Name = EditedName;
                _person.Surname = EditedSurname;
                _person.Email = EditedEmail;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                ok = false;
            }

            if (ok)
            {
                StationManager.DataStorage.EditPerson(_person);
                NavigationManager.Instance.Navigate(ViewType.PersonList, null);
            }
        }

    }
}