using csharp_sample_app.Application.DTO;
using csharp_sample_app.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_sample_app.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _repository;

        public UserService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public Task AddAsync(PostUserDTO user)
        {
            return _repository.AddAsync(user.AsEntity(Guid.NewGuid()));
        }

        public Task DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<GetUserDTO> GetAsync(Guid id)
        {
            var user = await _repository.GetAsync(id);

            if (user != null)
                return GetUserDTO.FromEntity(user);
            else return null;
        }

        public async Task<IEnumerable<GetUserListDTO>> GetListAsync()
        {
            var users = await _repository.GetListAsync();

            return users.Select(user => GetUserListDTO.FromEntity(user));
        }

        public Task UpdateAsync(PutUserDTO user)
        {
            return _repository.UpdateAsync(user.AsEntity());
        }
    }
}
