using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace CopaHAS.Models
{
    public class Selecao
    {
        public int Id { get; set; }

        public string Pais { get; set; } = string.Empty;


        //1:N
        public List<Jogador> Jogadores { get; set; } =
            new List<Jogador>();

        //1:1 
        public Tecnico Tecnico { get; set; }

        //n:n
        public List<JogoSelecao> JogoSelecoes { get; set; }
            = new List<JogoSelecao>();
    }
}
