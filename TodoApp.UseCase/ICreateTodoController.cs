using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.UseCase
{
    public interface ICreateTodoController
    {
        string Todo { get; }
        event EventHandler CreateRequest;
    }
}
