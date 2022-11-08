using APIhomework2.Models;
using System;
using System.IO;
using System.Collections.Generic;

namespace APIhomework2.HelperServices
{
    public class DictionaryHelperService : IDictionaryHelperService
    {
        private static Dictionary<int, Person> _db = new Dictionary<int, Person>();

        public static Dictionary<int, Person> Db { get { return _db; } set { _db = value; } }
    }
}

