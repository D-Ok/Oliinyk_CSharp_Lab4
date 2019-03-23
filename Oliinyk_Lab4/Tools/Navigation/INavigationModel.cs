using Oliinyk_Lab4.Models;

namespace Oliinyk_Lab4.Tools.Navigation
{
    internal enum ViewType
    {
        EnterData,
        EditInformation,
        PersonList
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType, Person person);
    }
}