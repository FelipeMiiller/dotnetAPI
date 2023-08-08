
using TaskEntity = Api.Modules.TaskModule.Domain.Entities.Task;

namespace Api.Modules.UserModule.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<TaskEntity> Posts { get; } = new List<TaskEntity>();
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public User(string? Name, string Email)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name ?? string.Empty;
            this.Email = Email ?? string.Empty;

        }

        public User(Guid Id, string? Name, string? Email)
        {
            this.Id = Id;
            this.Name = Name ?? string.Empty;
            this.Email = Email ?? string.Empty;
        }

    }

}