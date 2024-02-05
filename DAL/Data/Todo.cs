using DAL.Interfaces;
using Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Todo : ITodo
    {
        private readonly ProjectContext _projectContext;
        public Todo(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            List<TodoItem> todos = await _projectContext.TodoItems.ToListAsync();
            return todos;
        }
        public async Task<bool> NewToDo(TodoItem todo)
        {
            await _projectContext.TodoItems.AddAsync(todo);
            var isOk=_projectContext.SaveChanges()>0;
            return isOk;
        }
        public async Task<bool> Delete(int id)
        {
            var todoId=_projectContext.TodoItems.FirstOrDefault(x => x.Id == id);
            _projectContext.TodoItems.Remove(todoId);
            var isOk=_projectContext.SaveChanges()>0;
            return isOk;
        }

        public async Task<bool> Update(int id,TodoItem todo)
        {
            var todoId=_projectContext.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoId == null)
                return false;
            todoId.Name = todo.Name;
            todoId.CreateDate = todo.CreateDate;
            todoId.Complated= todo.Complated;
            var isOk = _projectContext.SaveChanges() > 0;
            return isOk;
        }
    }
}
