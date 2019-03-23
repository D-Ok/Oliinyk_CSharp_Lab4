using Oliinyk_Lab4.Tools;
using Oliinyk_Lab4.Models;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Threading;
using Oliinyk_Lab4.Tools.Managers;
using Oliinyk_Lab4.Tools.Navigation;

namespace Oliinyk_Lab4.ViewModels
{
    internal class EnterDataViewModel : BaseViewModel
    {
        private RelayCommand<object> _proceedCommand;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand =
                           new RelayCommand<object>(ProceedImplementation, CanProceedExecute));
            }
        }

        private bool CanProceedExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_name) && !String.IsNullOrWhiteSpace(_surname) && !String.IsNullOrWhiteSpace(_email);
        }

        private async void ProceedImplementation(object obj)
        {
            Person person = null;
            LoaderManeger.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                Thread.Sleep(2000);
                try
                {
                    person = new Person(Name, Surname, Email, Birthday);
                    StationManager.DataStorage.AddPerson(person);
                    StationManager.CurrentPerson = person;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                return true;
            });
            LoaderManeger.Instance.HideLoader();
            if (result && person != null) NavigationManager.Instance.Navigate(ViewType.PersonList, person);
        }

    }
}