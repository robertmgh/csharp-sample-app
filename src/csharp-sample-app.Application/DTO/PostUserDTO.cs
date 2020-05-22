using csharp_sample_app.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_sample_app.Application.DTO
{
    public class PostUserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public User AsEntity(Guid id)
        {
            return new User(id, this.Name, this.Surname, this.Age, "", "");
        }
    }
}
