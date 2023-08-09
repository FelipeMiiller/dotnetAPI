using Microsoft.EntityFrameworkCore;
using Api.Common.Infra.DataBase;
using Api.Modules.TaskModule.Domain.Repository.Dtos;
using Api.Modules.TaskModule.Domain.Entities;

namespace Api.Modules.TaskModule.Domain.Repository
{

    public class TaskRepository : ITaskRepository
    {
        private readonly Context _context;
        public TaskRepository(Context context)
        {
            _context = context;
        }

        public async Task<string> Create(CreateTaskDto task)
        {

            if (!await ExistTitle(task.Title))
            {
                var newTask = new TaskEntity()
                {
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                    Date = task.Date,
                    UserId = task.UserId,
                    CreateAt = DateTime.Now

                };
                _context.Tasks.Add(newTask);
                await _context.SaveChangesAsync();


                return "Task Created";
            }
            return "User Not Found";

        }

        public async Task<TaskEntity?> FindById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IList<TaskEntity>> FindByTitle(string title, Guid userId)
        {
            return await _context.Tasks.Where(u => u.Title == title && u.UserId == userId).ToListAsync();
        }


        public async Task<IList<TaskEntity>> FindByDate(DateTime date, Guid userId)
        {
            var startDate = date.Date;
            var endDate = startDate.AddDays(1);
            return await _context.Tasks.Where(u => u.Date >= startDate && u.Date < endDate && u.UserId == userId).ToListAsync();
        }

        public async Task<IList<TaskEntity>> FindByStatus(EnumStatusTask Status, Guid userId)
        {
            return await _context.Tasks.Where(u => u.Status == Status && u.UserId == userId).ToListAsync();
        }

        public async Task<IList<TaskEntity>> FindByUser(Guid userId)
        {
            return await _context.Tasks.Where(u => u.UserId == userId).ToListAsync();
        }


        public async Task<string> Update(UpdateTaskDto taskDto)
        {
            var task = await FindById(taskDto.Id);


            if (task != null)
            {
                var update = new TaskEntity()
                {
                    Title = taskDto.Title ?? task.Title,
                    Description = taskDto.Description ?? task.Description,
                    Status = taskDto.Status != task.Status ? taskDto.Status : task.Status,
                    Date = taskDto.Date != task.Date ? taskDto.Date : task.Date,
                };
                _context.Tasks.Update(update);
                await _context.SaveChangesAsync();

                return "User Updated";
            }
            return "User Not Found";

        }

        public async Task<IList<TaskEntity>> FindAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<string> Delete(Guid Id)
        {
            var user = await FindById(Id);
            if (user != null)
            {
                _context.Tasks.Remove(user);
                return "Task Deleted";
            }
            return "Task Not Found";

        }

        public async Task<string> DeleteAll()
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Tasks");
            return "All Tasks Deleted";
        }

        private async Task<bool> ExistTitle(string Title)
        {
            return await _context.Tasks.AnyAsync(u => u.Title == Title);
        }

    }
}