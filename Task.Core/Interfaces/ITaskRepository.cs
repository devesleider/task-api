using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DTOs;
using Task.Core.Entities;

namespace Task.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskE>> GetTasksByUser(int user, int categorie);
        Task<bool> Save(TaskDto task);
        Task<bool> Update(int id, bool end);
    }
}
