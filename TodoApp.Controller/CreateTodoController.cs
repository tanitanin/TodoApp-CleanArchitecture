using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TodoApp.Controller
{
    public class CreateTodoController : UseCase.ICreateTodoController, INotifyPropertyChanged
    {
        public string Todo
        {
            get => this.todo;
            set
            {
                if (!Equals(value, this.todo))
                {
                    this.todo = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Todo)));
                }
            }
        }
        private string todo = string.Empty;

        public System.Windows.Input.ICommand CreateCommand
        {
            get => createCommand ?? (createCommand = new CreateCommand(InvokeCreateRequest));
        }
        System.Windows.Input.ICommand createCommand;

        Action InvokeCreateRequest { get; set; }

        public event EventHandler CreateRequest;
        public event PropertyChangedEventHandler PropertyChanged;

        public CreateTodoController()
        {
            InvokeCreateRequest = () =>
            {
                CreateRequest?.Invoke(this, EventArgs.Empty);
            };
        }
    }

    public class CreateCommand : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action createAction = null;

        internal CreateCommand(Action createAction)
        {
            this.createAction = createAction;
        }

        public bool CanExecute(object parameter) => createAction != null;

        public void Execute(object parameter)
        {
            createAction.Invoke();
        }
    }
}
