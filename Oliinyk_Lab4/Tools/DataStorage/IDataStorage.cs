using System.Collections.Generic;
using Oliinyk_Lab4.Models;

namespace Oliinyk_Lab4.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddPerson(Person person);
        void DeletePerson(Person person);
        void EditPerson(Person person);
        List<Person> PersonsList { get; }
    }
}