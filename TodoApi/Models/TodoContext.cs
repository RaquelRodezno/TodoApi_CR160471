using System;
using System.Data.Entity;
using System.Linq;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        
        public TodoContext()
            : base("name=TodoContext")
        {
        }

       public virtual DbSet<TodoItem> TodoItem { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}