using csharp_sample_app.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace csharp_sample_app.Core.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetListAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
