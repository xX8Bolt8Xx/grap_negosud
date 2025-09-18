using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_pc_portable_graphique_true
{
    class Menu
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public float PrixHT { get; set; }
        public float PrixTTC { get; set; }
        public float TauxTva { get; set; }
        public List<Article> Articles { get; set; }
        public List<Commande> Commandes { get; set; }
    }
}
