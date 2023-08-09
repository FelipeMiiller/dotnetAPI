
using Api.Modules.UserModule.Domain.Entities;

namespace Api.Modules.TaskModule.Domain.Entities
{
    public class TaskEntity 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EnumStatusTask Status { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime? CreateAt { get; set; } 
        public DateTime? UpdateAt { get; set; }



    }
}