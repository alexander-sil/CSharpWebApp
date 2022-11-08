using APIhomework2.Models;
using System;
using Microsoft.AspNetCore.Mvc;

namespace APIhomework2.Repos
{
    public interface IRepository
    {
        public Person GetById(int id);

        public Person[] GetByName(string name);

        public Person[] GetPaging(int skip, int take);

        public void CreateNew(Person newPerson);

        public void UpdateExisting(int id, Person newPerson);

        public void DeleteExisting(int id);

    }
}

