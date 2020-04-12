using System;

namespace TodoApp.DomainModel
{
    public class TodoObject
    {
        public string Todo { get; set; }
        public bool Completed { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
