
using Api.Modules.TaskModule.Domain.Entities;
using Api.Modules.UserModule.Domain.Entities;

namespace Api.Modules.TaskModule.Domain.Repository.Dtos
{
    public class  TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EnumStatusTask Status { get; set; } = EnumStatusTask.Pending;
        public DateTime Date { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
    public record CreateTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EnumStatusTask Status { get; set; } = EnumStatusTask.Pending;
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }

    public record UpdateTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EnumStatusTask Status { get; set; } = EnumStatusTask.Pending;
        public DateTime Date { get; set; }
        


       
    }
}