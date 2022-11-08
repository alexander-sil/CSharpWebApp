
using APIhomework2.Models;
using System;

namespace APIhomework2.HelperServices
{
    public interface IDictionaryHelperService
    {
        private static Dictionary<int, Person> _db;

        public abstract static Dictionary<int, Person> Db { get; set; }
    }
}

