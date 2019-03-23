using System;
using Oliinyk_Lab4.Models;
using EnterDataView = Oliinyk_Lab4.Views.EnterDataView;
using EditInformationView = Oliinyk_Lab4.Views.EditInformationView;
using PersonListView = Oliinyk_Lab4.Views.PersonListView;

namespace Oliinyk_Lab4.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType, Person person)
        {
            if (ViewsDictionary.ContainsKey(viewType)) ViewsDictionary.Remove(viewType);
            switch (viewType)
            {
                case ViewType.EnterData:
                    ViewsDictionary.Add(viewType, new EnterDataView());
                    break;
                case ViewType.EditInformation:
                    ViewsDictionary.Add(viewType, new EditInformationView(person));
                    break;
                case ViewType.PersonList:
                    ViewsDictionary.Add(viewType, new PersonListView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}