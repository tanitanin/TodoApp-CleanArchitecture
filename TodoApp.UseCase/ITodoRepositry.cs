using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.UseCase
{
    public interface ITodoRepositry
    {
        void AddTodo(DomainModel.TodoObject todo);
        List<DomainModel.TodoObject> ListAll();
    }
}
