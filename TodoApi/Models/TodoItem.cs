using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Tarea { get; set; }
        public bool Completa { get; set; }
    }
}