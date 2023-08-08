
using Api.Modules.UserModule.Domain.Entities;

namespace Api.Modules.TaskModule.Domain.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EnumStatusTask Status { get; set; }
        public DateTime Data { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public Task( string Title, string Description, EnumStatusTask? Status, DateTime? Data, Guid UserId)
        {
            this.Id = Guid.NewGuid();
            this.Title = Title ;
            this.Description = Description;
            this.Status = Status ?? EnumStatusTask.Pending;
            this.Data = Data ?? DateTime.Now;
            this.UserId = UserId;

        }
        public Task(Guid Id, string? Name, string? Email, EnumStatusTask Status, Guid UserId)
        {
            this.Id = Id;
            this.Title = Name ?? string.Empty;
            this.Description = Email ?? string.Empty;
            this.Status = Status;
            this.UserId = UserId;
        }

    }
}