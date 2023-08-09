
using Api.Modules.TaskModule.Domain.Entities;

namespace Api.Modules.UserModule.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<TaskEntity> Tasks { get; } = new List<TaskEntity>();
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

       

    }

}