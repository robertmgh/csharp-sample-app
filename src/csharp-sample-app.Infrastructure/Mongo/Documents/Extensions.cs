using csharp_sample_app.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_sample_app.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static User AsEntity(this UserDocument document)
            => document is null ? null : new User(
                document.Id,
                document.Name,
                document.Surname,
                document.Age,
                document.Login,
                document.Password);

        public static UserDocument AsDocument(this User entity)
            => new UserDocument
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Age = entity.Age,
                Login = entity.Login,
                Password = entity.Password
            };
    }
}
