using csharp_sample_app.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_sample_app.Application.DTO
{
    public class GetUserListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public static GetUserListDTO FromEntity(User user) => new GetUserListDTO() { Id = user.Id, Age = user.Age, Name = user.Name, Surname = user.Surname };
    }
}
