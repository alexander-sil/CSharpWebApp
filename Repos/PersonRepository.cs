using APIhomework2.Models;
using APIhomework2.HelperServices;
using System;

namespace APIhomework2.Repos
{
    public class PersonRepository : IRepository
    {
        private static Dictionary<int, Person> _dictSingletonInstance;

        public PersonRepository()
        {
            _dictSingletonInstance = DictionaryHelperService.Db;
        }

        public Person GetById(int id)
        {
            if (_dictSingletonInstance.ContainsKey(id))
            {
                return _dictSingletonInstance[id];
            }
            else
            {
                return new Person(-1, "ERROR", "ERROR", "ERROR", "ERROR", -1);
            }

        }

        public Person[] GetByName(string name)
        {
            KeyValuePair<int, Person>[] temp = _dictSingletonInstance.Where(f => (f.Value.FirstName == name)).ToArray();
            List<Person> persons = new List<Person>();

            foreach (KeyValuePair<int, Person> pair in temp)
            {
                persons.Add(pair.Value);
            }

            return persons.ToArray();
        }

        public Person[] GetPaging(int skip, int take)
        {
            List<Person> temp = _dictSingletonInstance.Values.ToList();

            return temp.Skip(skip).Take(take).ToArray();
        }

        public void CreateNew(Person newPerson)
        {
            if (!_dictSingletonInstance.ContainsKey(newPerson.Id))
            {
                _dictSingletonInstance.Add(newPerson.Id, newPerson);
            }
        }

        public void UpdateExisting(int id, Person newPerson)
        {
            if (_dictSingletonInstance.ContainsKey(id) && (newPerson.Id == id))
            {
                _dictSingletonInstance[id] = newPerson;
            }
        }

        public void DeleteExisting(int id)
        {
            if (_dictSingletonInstance.ContainsKey(id))
            {
                _dictSingletonInstance.Remove(id);
            }
        }
    }
}