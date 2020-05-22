using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_sample_app.Core.Entities
{
    public class User
    {
        public User(Guid id, string name, string surname, int age, string login, string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Login = login;
            Password = password;
        }

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public int Age { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
    }
}
