using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core.DTOs
{
    public class TaskDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string startDate { get; set; }
        public string deadline { get; set; }
        public int categorie { get; set; }
        public int user { get; set; }
        public bool End_task { get; set; }
    }
}
