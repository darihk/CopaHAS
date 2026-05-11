using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaHAS.Models
{
    public class Tecnico
    {
        public int Id {get; set;}
        public string Nome {get; set;} = string.Empty;
        public int SelecaoId {get; set;} // FK

        public Selecao SelecaoIdNavegacao {get; set;} // Navegacao
    }
}