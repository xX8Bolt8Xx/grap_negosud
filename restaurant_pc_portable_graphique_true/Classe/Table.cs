using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_pc_portable_graphique_true
{
    class Table
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Places { get; set; }
        public List<Commande> Commandes { get; set; }
    }
}
