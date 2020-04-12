using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static SimpleInjector.Container DIContainer { get; } = new SimpleInjector.Container();

        public App()
        {
            var connectionString = new LiteDB.ConnectionString();
            connectionString.Filename = "todo.db";

            // Container
            DIContainer.Options.DefaultLifestyle = SimpleInjector.Lifestyle.Singleton;

            // InterfaceAdapter
            DIContainer.Register<UseCase.ITodoRepositry>(() => new Repositry.TodoRepositry(connectionString));
            DIContainer.Register<UseCase.IListTodoPresenter, Presenter.ListTodoPresenter>();
            DIContainer.Register<UseCase.ICreateTodoController, Controller.CreateTodoController>();

            // UseCase
            DIContainer.Register<UseCase.ListTodoHandler>();
            DIContainer.Register<UseCase.CreateTodoHandler>();

            DIContainer.Verify();
        }
    }
}
