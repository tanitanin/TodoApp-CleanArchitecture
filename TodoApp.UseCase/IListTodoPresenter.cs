using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.UseCase
{
    public interface IListTodoPresenter
    {
        List<DomainModel.TodoObject> TodoList { set; }
    }
}
