using csharp_sample_app.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace csharp_sample_app.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserListDTO>> GetListAsync();
        Task<GetUserDTO> GetAsync(Guid id);
        Task AddAsync(PostUserDTO user);
        Task UpdateAsync(PutUserDTO user);
        Task DeleteAsync(Guid id);
    }
}
