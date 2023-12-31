

using Api.Modules.UserModule.Domain.Entities;

namespace Api.Modules.UserModule.Domain.Repository.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public UserDto(Guid Id, string Name, string Email, DateTime CreateAt, DateTime? UpdateAt)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.CreateAt = CreateAt;
            this.UpdateAt = UpdateAt;
        }
    }
    public record CreateUserDto(string? Name, string Email) { }


    public record UpdateUserDto(Guid Id, string? Name, string? Email) { }
}