using System;

namespace APIhomework2.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Company { get; set; }
        public int Age { get; set; }

        public Person(int id, string firstName, string lastName, string email, string company, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Company = company;
            Age = age;
        }
    }
}