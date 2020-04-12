using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoApp.UseCase
{
    public class ListTodoHandler
    {
        private ITodoRepositry repositry;
        private IListTodoPresenter presenter;


        public ListTodoHandler(ITodoRepositry repositry, IListTodoPresenter presenter)
        {
            this.repositry = repositry;
            this.presenter = presenter;
        }

        public void Handle()
        {
            var list = repositry.ListAll();
            presenter.TodoList = list.ToList();
        }
    }
}
