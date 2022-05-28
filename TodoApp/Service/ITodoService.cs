using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain;

namespace TodoApp.Service
{
    public interface ITodoService
    {
        Task<TodoItem> CreateAsync(TodoItem item);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(TodoItem item);
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem> GetAsync(Guid id);
    }
}
