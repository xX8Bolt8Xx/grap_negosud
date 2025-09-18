using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_pc_portable_graphique_true
{
    class Article
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public float PrixHT { get; set; }
        public float PrixTTC { get; set; }
        public float TauxTVA { get; set; }

        public List<Menu> Menus { get; set; }
        public List<Commande> Commandes { get; set; }
    }
}
