
using  Api.Modules.TaskModule.Domain.Entities;
using Api.Modules.TaskModule.Domain.Repository.Dtos;

namespace Api.Modules.TaskModule.Domain.Repository
{
    public interface ITaskRepository
    {
        Task<string> Create(CreateTaskDto user);
        Task<TaskEntity?> FindById(Guid Id);
        Task<IList<TaskEntity>> FindByTitle(string title, Guid userId);
        Task<IList<TaskEntity>> FindByDate(DateTime date, Guid userId);
        Task<IList<TaskEntity>> FindByStatus(EnumStatusTask Status, Guid userId);
        Task<IList<TaskEntity>> FindByUser( Guid userId);
        Task<string> Update(UpdateTaskDto taskDto);
        Task<IList<TaskEntity>> FindAll();
        Task<string> Delete(Guid Id);
        Task<string> DeleteAll();


    }
}
