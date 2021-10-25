using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class TodoItemController : ApiController

    {
        public IEnumerable<TodoItem> Get()
        {
            var db = new TodoContext();
            var listaItems = db.TodoItem.ToList();
            return listaItems;
        }
        public TodoItem Get (int id)
        {
            var db = new TodoContext();
            var item = db.TodoItem.Where(x => x.Id == id).FirstOrDefault();
            return item;
        }

        public HttpRequestMessage Post ([FromBody] TodoItem item)
        {
            var db = new TodoContext();
            db.TodoItem.Add(item);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK,tempitem,  Configuration.Formatters.JsonFormatter);
        }

        public HttpResponseMessage Put(int id, [FromBody] TodoItem item)
        {
            var db = new TodoContext();
            var tempItem = db.TodoItem.Where(x => x.Id == id).FirstOrDefault();
            if (tempItem != null)
            {
                tempItem.Tarea = item.Tarea;
                tempItem.Completa = item.Completa;
            }
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, tempItem, Configuration.Formatters.JsonFormatter);
        }

        public void Delete(int id)
        {
            var db = new TodoContext();
            var tempItem = db.TodoItem.Where(x => x.Id == id).FirstOrDefault();
            if (tempItem != null)
            {
                db.TodoItem.Remove(tempItem);
            }
            db.SaveChanges();
        }
    }
}
