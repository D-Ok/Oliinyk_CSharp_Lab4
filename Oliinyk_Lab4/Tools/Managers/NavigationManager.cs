using System.Windows;
using Oliinyk_Lab4.Models;
using Oliinyk_Lab4.Tools.Navigation;

namespace Oliinyk_Lab4.Tools.Managers
{
    internal class NavigationManager
    {
        private static readonly object Locker = new object();
        private static NavigationManager _instance;

        internal static NavigationManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new NavigationManager());
                }
            }
        }

        private INavigationModel _navigationModel;

        private NavigationManager()
        {

        }

        internal void Initialize(INavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        internal void Navigate(ViewType viewType, Person person)
        {
            if (_navigationModel == null) MessageBox.Show(" " + _navigationModel);
            _navigationModel.Navigate(viewType, person);
        }

    }
}