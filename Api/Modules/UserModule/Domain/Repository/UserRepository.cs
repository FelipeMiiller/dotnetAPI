using Microsoft.EntityFrameworkCore;
using Api.Common.Infra.DataBase;
using Api.Modules.UserModule.Domain.Repository.Dtos;
using Api.Modules.UserModule.Domain.Entities;

namespace Api.Modules.UserModule.Domain.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<string> Create(CreateUserDto user)
        {

            if (!await ExistFoEmail(user.Email))
            {
                var newUser = new User()
                {
                    Name = user.Name ?? string.Empty,
                    Email = user.Email,
                    CreateAt = DateTime.Now
                };
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return "User Created";
            }
            return "User Not Found";

        }

        public async Task<User?> FindById(Guid Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<User?> FindByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<string> Update(UpdateUserDto userDto)
        {
            var user = await FindById(userDto.Id);


            if (user != null)
            {
                var update = new User()
                {
                    Id = userDto.Id,
                    Name = userDto.Name ?? user.Name,
                    Email = userDto.Email ?? user.Email,
                };
                _context.Users.Update(update);
                await _context.SaveChangesAsync();

                return "User Updated";
            }
            return "User Not Found";

        }

        public async Task<IList<User>> FindAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<string> Delete(Guid Id)
        {
            var user = await FindById(Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                return "User Deleted";
            }
            return "User Not Found";

        }

        public async Task<string> DeleteAll()
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Users");
            return "All Users Deleted";
        }

        private async Task<bool> ExistFoEmail(string Email)
        {
            return await _context.Users.AnyAsync(u => u.Email == Email);
        }

    }
}