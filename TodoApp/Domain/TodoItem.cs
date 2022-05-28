using System;

namespace TodoApp.Domain
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Completed { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
