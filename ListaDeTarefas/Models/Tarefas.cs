using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaDeTarefas.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Descrição { get; set; }
        public bool Completo { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}