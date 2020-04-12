using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoApp.UseCase
{
    public class CreateTodoHandler
    {
        private ITodoRepositry repositry;
        private ICreateTodoController controller;
        private IListTodoPresenter presenter;

        public CreateTodoHandler(ITodoRepositry repositry, ICreateTodoController controller, IListTodoPresenter presenter)
        {
            this.repositry = repositry;
            this.controller = controller;
            this.controller.CreateRequest += Controller_CreateRequest;
            this.presenter = presenter;
        }

        private void Controller_CreateRequest(object sender, EventArgs e)
        {
            Handle(this.controller.Todo);
        }

        public void Handle(string todo)
        {
            if (string.IsNullOrWhiteSpace(todo))
            {
                return;
            }

            var todoObj = new DomainModel.TodoObject();
            todoObj.Todo = todo;
            todoObj.Completed = false;
            todoObj.LastUpdated = todoObj.Created = DateTime.Now;
            repositry.AddTodo(todoObj);
            var list = repositry.ListAll().ToList();
            presenter.TodoList = list;
        }
    }
}
