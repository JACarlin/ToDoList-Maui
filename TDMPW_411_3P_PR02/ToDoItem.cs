using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TDMPW_411_3P_PR02
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

    public ToDoItem(int id, string nombre, bool estado)
    {
        Id = id;
        Nombre = nombre;
        Estado = estado;
    }

    }
    
}
