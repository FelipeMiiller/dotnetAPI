using Microsoft.EntityFrameworkCore;
using Api.Common.Infra.DataBase;
using Api.Modules.UserModule.Domain.Repository.Dtos;
using Api.Modules.UserModule.Domain.Entities;
using Api.Util.Error;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Data.Sqlite;
using System.Net;

namespace Api.Modules.UserModule.Domain.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(CreateUserDto user)
        {
            try
            {
                if (!await ExistFoEmail(user.Email))
                {
                    var newUser = new User(user.Name, user.Email);
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();
                }
                throw new Exception("User Already Found");

            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(SqliteException))
                {
                    var error = new
                    {
                        Code = (int)HttpStatusCode.UnprocessableEntity,
                        Title = "DB Error",
                        Message = "Erro inesperado."
                    };
                    throw new AppExceptionDB((int)HttpStatusCode.UnprocessableEntity, e.Message);
                }

                throw new AppExceptionDB((int)HttpStatusCode.NotFound, e.Message);
            }
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
                var update = new User
                (
                 userDto.Id,
                 userDto.Name ?? user.Name,
                 userDto.Email ?? user.Email
                );

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