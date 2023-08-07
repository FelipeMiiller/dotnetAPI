

using Api.Modules.UserModule.Domain.Repository.Dtos;

namespace Api.Modules.UserModule.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public User(string? Name, string Email)
        {
            this.Name = Name ?? string.Empty;
            this.Email = Email;
        }

        public User(Guid Id, string? Name, string? Email)
        {
            this.Id = Id;
            this.Name = Name ?? string.Empty;
            this.Email = Email ?? string.Empty;

        }

    }

}