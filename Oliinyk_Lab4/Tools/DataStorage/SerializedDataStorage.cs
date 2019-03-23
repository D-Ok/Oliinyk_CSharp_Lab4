using System.Collections.Generic;
using System.IO;
using System.Linq;
using Oliinyk_Lab4.Models;
using Oliinyk_Lab4.Tools.Managers;

namespace Oliinyk_Lab4.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _persons;

        internal SerializedDataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                List<Person> fifty = new List<Person>();
                for (int i = 0; i < 50; i++)
                {
                    fifty.Add(PersonCreator.CreateRandomePerson());
                }

                _persons = fifty;

            }
        }

        public void EditPerson(Person person)
        {
            SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _persons.Remove(person);
            SaveChanges();
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
            SaveChanges();
        }

        public List<Person> PersonsList
        {
            get { return _persons.ToList(); }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }

    }
}