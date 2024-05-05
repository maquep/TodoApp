using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Data;
using TodoApp.Domain;

namespace TodoApp.Service
{
    public class TodoService : ITodoService
    {
        private TodoContext _todoContext;
        public TodoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        public async Task<TodoItem> CreateAsync(TodoItem item)
        {
            await _todoContext.Items.AddAsync(item);
            var created  = await _todoContext.SaveChangesAsync();

            return created > 0 ? item : null;
        }
        public async Task<TodoItem> GetAsync(Guid id)
        {
            return await _todoContext.Items.SingleOrDefaultAsync<TodoItem>(x => x.Id == id);
        }
        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _todoContext.Items.ToListAsync<TodoItem>();
        }
        public async Task<bool> UpdateAsync(TodoItem item)
        {
            _todoContext.Items.Update(item);
            var update = await _todoContext.SaveChangesAsync();
            return update > 0;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = GetAsync(id);
            if (item != null)
            {
                _todoContext.Items.Remove(item.Result);
                var deleted  = await _todoContext.SaveChangesAsync();
                return deleted > 0;
            }

            return false;
        }
    }
}
