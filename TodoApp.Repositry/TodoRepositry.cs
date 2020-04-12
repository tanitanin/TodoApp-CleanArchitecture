using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp.Repositry
{
    public class TodoRepositry : UseCase.ITodoRepositry
    {
        private LiteDB.ConnectionString connectionString;

        public TodoRepositry(LiteDB.ConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddTodo(DomainModel.TodoObject todo)
        {
            using (var db = new LiteDB.LiteDatabase(this.connectionString))
            {
                var collection = db.GetCollection<DomainModel.TodoObject>();
                collection.Insert(todo);
            }
        }

        List<DomainModel.TodoObject> UseCase.ITodoRepositry.ListAll()
        {
            using (var db = new LiteDB.LiteDatabase(this.connectionString))
            {
                var collection = db.GetCollection<DomainModel.TodoObject>();
                return collection.FindAll().ToList();
            }
        }
    }
}
