using csharp_sample_app.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_sample_app.Application.DTO
{
    public class PutUserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public User AsEntity() => new User(this.Id, this.Name, this.Surname, this.Age, "", "");
    }
}
