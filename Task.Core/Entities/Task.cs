using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Staart_Date { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime End_Date { get; set; }
        public int Categorie { get; set; }
        public int User { get; set; }
    }
}
