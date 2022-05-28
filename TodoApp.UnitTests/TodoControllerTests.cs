using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using TodoApp.Contracts.V1.Requests;
using TodoApp.Controllers.v1;
using TodoApp.Data;
using TodoApp.Domain;
using TodoApp.Service;
using Xunit;

namespace TodoApp.UnitTests
{
    public class TodoControllerTests
    {
        private readonly Mock<ITodoService> _todoServiceMock;
        private readonly Mock<TodoContext> _todoContextMock;
        private readonly TodoController _todoController;

        public TodoControllerTests()
        {
            //initialise
            _todoServiceMock.SetupAllProperties();
        }

        [Fact]
        public void Create_Todo_Should_Create_Todo()
        {
            var todoRequest = new TodoItemRequest
            { 
                Name = "Add to do item"
            };

            var result = _todoController.Create(todoRequest).Result;
            var createdTodoItem = (TodoItem)result;

            Assert.Equal(createdTodoItem.Name, todoRequest.Name);
        }
    }
}
