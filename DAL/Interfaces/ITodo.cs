using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.Interfaces
{
    public interface ITodo
    {
        Task<List<TodoItem>> GetAll();
        Task<bool> NewToDo(TodoItem todo);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, TodoItem todo);
    }
}
