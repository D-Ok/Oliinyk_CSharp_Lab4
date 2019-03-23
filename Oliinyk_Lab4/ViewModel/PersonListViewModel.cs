using System;
using Oliinyk_Lab4.Models;
using Oliinyk_Lab4.Tools.Managers;
using Oliinyk_Lab4.Tools;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Oliinyk_Lab4.Tools.Navigation;
using System.Collections.Generic;

namespace Oliinyk_Lab4.ViewModel
{
    class PersonListViewModel : INotifyPropertyChanged
    {

        private Person _selectedPerson;
        private string _currentPerson;
        private ObservableCollection<Person> _persons;
        private bool _isDescending;

        private ICommand _deletePersonCommand;
        private ICommand _editPersonCommand;
        private ICommand _sortCommand;
        private ICommand _filterCommand;
        private ICommand _resetCommand;
        private ICommand _addPersonCommand;
        private ICommand _closeCommand;

        private string _selectedProperty;

        private readonly string[] _propertiesList =
            {"Name", "Surname", "E-mail", "Birthday", "Is adult", "Is birthday", "Sun sign", "Chineese sign"};

        private readonly string[] _sunSignList = BirthdayDate.WestHoroscope;
        private readonly string[] _chineeseSignList = BirthdayDate.ChineseHoroscope;
        private readonly string[] _filterBool = {"True", "False"};

        private int _adultFilter=-1;
        private int _bitthdayFilter=-1;
        private int _sunSignFilter=-1;
        private int _chineeseSignFilter=-1;

        public int AdultFilter
        {
            get { return _adultFilter; }
            set
            {
                _adultFilter = value;
                OnPropertyChanged("AdultFilter");
            }
        }

        public int BirthdayFilter
        {
            get { return _bitthdayFilter; }
            set
            {
                _bitthdayFilter = value;
                OnPropertyChanged("BirthdayFilter");
            }
        }

        public int SunSignFilter
        {
            get { return _sunSignFilter; }
            set
            {
                _sunSignFilter = value;
                OnPropertyChanged("SunSignFilter");
            }
        }

        public int ChineeseSignFilter
        {
            get { return _chineeseSignFilter; }
            set
            {
                _chineeseSignFilter = value;
                OnPropertyChanged("ChineeseSignFilter");
            }
        }

        public string[] FilterBool
        {
            get { return _filterBool; }
        }

        public string[] PropertiesList
        {
            get { return _propertiesList; }
        }

        public string[] SunSignList
        {
            get { return _sunSignList; }
        }

        public string[] ChineeseSignList
        {
            get { return _chineeseSignList; }
        }

        public bool IsDescending
        {
            get { return _isDescending; }
            set
            {
                _isDescending = value;
                OnPropertyChanged("IsDescending");
            }
        }

        public string SelectedProperty
        {
            get { return _selectedProperty; }
            set
            {
                _selectedProperty = value;
                OnPropertyChanged("SelectedProperty");
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                StationManager.CurrentPerson = value;
                if(value!=null)CurrentPerson = $"Selected Person: {value}";
                OnPropertyChanged();
            }
        }


        public string CurrentPerson
        {
            get { return _currentPerson; }
            private set
            {
                _currentPerson = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeletePersonCommand
        {
            get
            {
                return _deletePersonCommand ?? (_deletePersonCommand =
                           new RelayCommand<object>(DeletePersonImplementation, CanEditListExecute));
            }
        }

        public ICommand EditPersonCommand
        {
            get
            {
                return _editPersonCommand ?? (_editPersonCommand =
                           new RelayCommand<object>(EditPersonImplementation, CanEditListExecute));
            }
        }

        public ICommand SortCommand
        {
            get
            {
                return _sortCommand ?? (_sortCommand = new RelayCommand<object>(SortImplementation, CanSortExecute));
            }
        }

        public ICommand FilterCommand
        {
            get
            {
                return _filterCommand ??
                       (_filterCommand = new RelayCommand<object>(FilterImplementation, CanFilterExecute));
            }
        }

        public ICommand ResetCommand
        {
            get { return _resetCommand ?? (_resetCommand = new RelayCommand<object>(ResetImplementation)); }
        }

        public ICommand AddPersonCommand
        {
            get { return _addPersonCommand ?? (_addPersonCommand = new RelayCommand<object>(AddPersonImplementation)); }
        }

        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation)); }
        }

        private bool CanEditListExecute(object obj)
        {
            return SelectedPerson != null;
        }

        private bool CanSortExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_selectedProperty);
        }

        private bool CanFilterExecute(object obj)
        {
            return (_adultFilter > -1 || _bitthdayFilter > -1 || _sunSignFilter > 1 || _chineeseSignFilter > 1);
        }

        internal PersonListViewModel()
        {
            Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
            SelectedPerson = StationManager.CurrentPerson;
        }

        private void DeletePersonImplementation(object obj)
        {
            if (SelectedPerson == null)
            {
                MessageBox.Show("Please, select person", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Are you sure that you want to delete person: {SelectedPerson}", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                StationManager.DataStorage.DeletePerson(SelectedPerson);
                NavigationManager.Instance.Navigate(ViewType.PersonList, null);
            }
        }

        private void EditPersonImplementation(object obj)
        {
            if (SelectedPerson == null)
                MessageBox.Show("Please, select person", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else NavigationManager.Instance.Navigate(ViewType.EditInformation, SelectedPerson);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        // [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void SortImplementation(object obj)
        {
            IEnumerable<Person> sorted = _persons.ToList();
            switch (SelectedProperty)
            {
                case "Name":
                    if (IsDescending) sorted = sorted.OrderByDescending(p => p.Name);
                    else sorted = sorted.OrderBy(p => p.Name);
                    break;
                case "Surname":
                    if (IsDescending) sorted = sorted.OrderByDescending(p => p.Surname);
                    else sorted = sorted.OrderBy(p => p.Surname);
                    break;
                case "E-mail":
                    if (IsDescending) sorted = sorted.OrderByDescending(p => p.Email);
                    else sorted = sorted.OrderBy(p => p.Email);
                    break;
                case "Birthday":
                    if (IsDescending) sorted = sorted.OrderByDescending(p => p.Birthday);
                    else sorted = sorted.OrderBy(p => p.Birthday);
                    break;
                case "Is adult":
                    if (IsDescending) sorted = sorted.OrderByDescending(p => p.IsAdult);
                    else sorted = sorted.OrderBy(p => p.IsAdult);
                    break;
                case "Is birthday":
                    if (IsDescending) sorted = sorted.OrderByDescending(p => p.IsBirthday);
                    else sorted = sorted.OrderBy(p => p.IsBirthday);
                    break;
                case "Sun sign":
                    if (IsDescending) sorted = sorted.OrderByDescending(p => p.SunSign);
                    else sorted = sorted.OrderBy(p => p.SunSign);
                    break;
                case "Chineese sign":
                    if (IsDescending) sorted = sorted.OrderByDescending(p => p.ChineseSign);
                    else sorted = sorted.OrderBy(p => p.ChineseSign);
                    break;
                default: break;
            }

            Persons = new ObservableCollection<Person>(sorted);
            // SelectedProperty= null;
            // IsDescending = false;

            //NavigationManager.Instance.Navigate(ViewType.Main, null);
        }

        private void FilterImplementation(object obj)
        {
            IEnumerable<Person> sorted = _persons.ToList();
            if (AdultFilter > -1)
            {
                if(AdultFilter==0) sorted.Where(p => p.IsAdult == true);
                else sorted = sorted.Where(p => p.IsAdult == false);  
            }

            if (BirthdayFilter > -1)
            {
                if(BirthdayFilter==0) sorted = sorted.Where(p => p.IsBirthday == true);
                else sorted = sorted.Where(p => p.IsBirthday == false);
            }

            if (SunSignFilter > -1) sorted = sorted.Where(p => p.SunSign == SunSignList[SunSignFilter]);
            if (ChineeseSignFilter > -1) sorted = sorted.Where(p => p.ChineseSign == ChineeseSignList[ChineeseSignFilter]);

            Persons = new ObservableCollection<Person>(sorted);
        }

        private void AddPersonImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.EnterData, null);
        }

        private void ResetImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.PersonList, null);
        }

        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }
    }
}
