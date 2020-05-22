using csharp_sample_app.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_sample_app.Application.DTO
{
    public class GetUserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public static GetUserDTO FromEntity(User user) =>
             new GetUserDTO() { Name = user.Name, Surname = user.Surname, Id = user.Id, Age = user.Age };

    }
}
