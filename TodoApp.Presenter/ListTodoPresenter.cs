using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TodoApp.Presenter
{
    public class ListTodoPresenter : UseCase.IListTodoPresenter, INotifyPropertyChanged
    {
        public List<DomainModel.TodoObject> TodoList
        {
            get => this.todoList;
            set
            {
                if (!Equals(value, this.todoList))
                {
                    this.todoList = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TodoList)));
                }
            }
        }
        private List<DomainModel.TodoObject> todoList = new List<DomainModel.TodoObject>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
