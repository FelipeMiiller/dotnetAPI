
using Api.Modules.TaskModule.Domain.Entities;

namespace Api.Modules.UserModule.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<TaskEntity> Tasks { get; } = new List<TaskEntity>();
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public User(string? Name, string Email)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name ?? string.Empty;
            this.Email = Email;
        }

        public User(Guid Id, string Name, string Email)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
        }

    }
}