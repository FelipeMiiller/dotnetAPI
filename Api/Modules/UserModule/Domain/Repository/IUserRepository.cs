
using Api.Modules.UserModule.Domain.Entities;
using Api.Modules.UserModule.Domain.Repository.Dtos;

namespace Api.Modules.UserModule.Domain.Repository
{
    public interface IUserRepository
    {
        Task<string> Create(CreateUserDto user);
        Task<User?> FindById(Guid Id);
        Task<User?> FindByEmail(string email);
        Task<string> Update(UpdateUserDto user);
        Task<IList<User>> FindAll();
        Task<string> Delete(Guid Id);
        Task<string> DeleteAll();


    }
}
