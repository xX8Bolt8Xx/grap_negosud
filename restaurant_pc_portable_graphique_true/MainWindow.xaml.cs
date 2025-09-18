using System.Windows;
using System.Windows.Controls;

namespace restaurant_pc_portable_graphique_true
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RestaurantContext _db = new RestaurantContext();
        private List<Article> _allArticles = new List<Article>();
        private List<CheckBox> _checkboxArticles = new List<CheckBox>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedChoice = ((ComboBoxItem)Cbx_Choix.SelectedItem).Content.ToString();
            string nom = "";
            float prix_ttc = 0;
            float taux_tva = 0;
            float prix_ht = 0;
            string numero = "";
            float nbr = 0;
            if (selectedChoice == "Menu")
            {
                lbx_nom.Visibility = Visibility.Visible;
                lbx_ttc.Visibility = Visibility.Visible;
                lbx_tva.Visibility = Visibility.Visible;
                tbx_nom.Visibility = Visibility.Visible;
                tbx_ttc.Visibility = Visibility.Visible;
                tbx_tva.Visibility = Visibility.Visible;
                lbx_num.Visibility = Visibility.Collapsed;
                lbx_nbr.Visibility = Visibility.Collapsed;
                tbx_num.Visibility = Visibility.Collapsed;
                tbx_nbr.Visibility = Visibility.Collapsed;

                nom = tbx_nom.Text;
                prix_ttc = Convert.ToSingle(tbx_ttc.Text);
                taux_tva = Convert.ToSingle(tbx_tva.Text);
                prix_ht = (float)Math.Round(prix_ttc / (1 + (taux_tva / 100)), 2);
                List<Article> selectedArticles = new List<Article>();
                foreach (var checkbox in _checkboxArticles)
                {
                    if (checkbox.IsChecked == true)
                    {
                        selectedArticles.Add((Article)checkbox.Tag);
                    }
                }
                Menu menu = new Menu
                {
                    Nom = nom,
                    PrixTTC = prix_ttc,
                    PrixHT = prix_ht,
                    TauxTva = taux_tva,
                    Articles = selectedArticles
                };
                _db.Menus.Add(menu);
                _db.SaveChanges();
                MessageBox.Show("Votre menu a bien été ajouté !");

                tbx_nom.Text = "";
                tbx_ttc.Text = "";
                tbx_tva.Text = "";

            }
            if (selectedChoice == "Article")
            {
                lbx_nom.Visibility = Visibility.Visible;
                lbx_ttc.Visibility = Visibility.Visible;
                lbx_tva.Visibility = Visibility.Visible;
                tbx_nom.Visibility = Visibility.Visible;
                tbx_ttc.Visibility = Visibility.Visible;
                tbx_tva.Visibility = Visibility.Visible;
                lbx_num.Visibility = Visibility.Collapsed;
                lbx_nbr.Visibility = Visibility.Collapsed;
                tbx_num.Visibility = Visibility.Collapsed;
                tbx_nbr.Visibility = Visibility.Collapsed;

                nom = tbx_nom.Text;
                prix_ttc = Convert.ToSingle(tbx_ttc.Text);
                taux_tva = Convert.ToSingle(tbx_tva.Text);
                prix_ht = (float)Math.Round(prix_ttc / (1 + (taux_tva / 100)), 2);


                Article article = new Article { Nom = nom, PrixTTC = prix_ttc, PrixHT = prix_ht, TauxTVA = taux_tva };
                _db.Articles.Add(article);
                _db.SaveChanges();

                tbx_nom.Text = "";
                tbx_ttc.Text = "";
                tbx_tva.Text = "";
            }
            if (selectedChoice == "Table")
            {

                lbx_nom.Visibility = Visibility.Collapsed;
                lbx_ttc.Visibility = Visibility.Collapsed;
                lbx_tva.Visibility = Visibility.Collapsed;
                tbx_nom.Visibility = Visibility.Collapsed;
                tbx_ttc.Visibility = Visibility.Collapsed;
                tbx_tva.Visibility = Visibility.Collapsed;
                lbx_num.Visibility = Visibility.Visible;
                lbx_nbr.Visibility = Visibility.Visible;
                tbx_num.Visibility = Visibility.Visible;
                tbx_nbr.Visibility = Visibility.Visible;

                numero = tbx_num.Text;
                nbr = Convert.ToSingle(tbx_nbr.Text);
                Table table = new Table { Numero = numero, Places = (int)nbr };
                _db.Tables.Add(table);
                _db.SaveChanges();

                tbx_num.Text = "";
                tbx_nbr.Text = "";
            }
            if (selectedChoice == "Commande")
            {

                lbx_nom.Visibility = Visibility.Collapsed;
                lbx_ttc.Visibility = Visibility.Collapsed;
                lbx_tva.Visibility = Visibility.Collapsed;
                tbx_nom.Visibility = Visibility.Collapsed;
                tbx_ttc.Visibility = Visibility.Collapsed;
                tbx_tva.Visibility = Visibility.Collapsed;
                lbx_num.Visibility = Visibility.Visible;
                lbx_nbr.Visibility = Visibility.Collapsed;
                tbx_num.Visibility = Visibility.Visible;
                tbx_nbr.Visibility = Visibility.Collapsed;

                numero = tbx_num.Text;
                prix_ttc = Convert.ToSingle(tbx_ttc.Text);
                taux_tva = Convert.ToSingle(tbx_tva.Text);
                prix_ht = (float)Math.Round(prix_ttc / (1 + (taux_tva / 100)), 2);
                Commande commande = new Commande { Numero = numero, TotalTTC = prix_ttc, TotalHT = prix_ht };
                _db.Commandes.Add(commande);
                _db.SaveChanges();

                tbx_num.Text = "";
                tbx_ttc.Text = "";
                tbx_tva.Text = "";
            }
        }

        private void Cbx_Choix_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedChoice = ((ComboBoxItem)Cbx_Choix.SelectedItem)?.Content?.ToString();
            Lbx_Articles.Items.Clear();
            _allArticles = _db.Articles.ToList();

            foreach (var article in _allArticles)
            {
                var checkbox = new CheckBox
                {       
                    Content = article.Nom,
                    Tag = article,
                };
                _checkboxArticles.Add(checkbox);
                Lbx_Articles.Items.Add(checkbox);
            }
            switch (selectedChoice)
            {
                case "Menu":
                    lbx_nom.Visibility = Visibility.Visible;
                    lbx_ttc.Visibility = Visibility.Visible;
                    lbx_tva.Visibility = Visibility.Visible;
                    tbx_nom.Visibility = Visibility.Visible;
                    tbx_ttc.Visibility = Visibility.Visible;
                    tbx_tva.Visibility = Visibility.Visible;
                    lbx_num.Visibility = Visibility.Collapsed;
                    lbx_nbr.Visibility = Visibility.Collapsed;
                    tbx_num.Visibility = Visibility.Collapsed;
                    tbx_nbr.Visibility = Visibility.Collapsed;
                    Lbx_Articles.Visibility = Visibility.Visible;
                    break;
                case "Article":
                    lbx_nom.Visibility = Visibility.Visible;
                    lbx_ttc.Visibility = Visibility.Visible;
                    lbx_tva.Visibility = Visibility.Visible;
                    tbx_nom.Visibility = Visibility.Visible;
                    tbx_ttc.Visibility = Visibility.Visible;
                    tbx_tva.Visibility = Visibility.Visible;
                    lbx_num.Visibility = Visibility.Collapsed;
                    lbx_nbr.Visibility = Visibility.Collapsed;
                    tbx_num.Visibility = Visibility.Collapsed;
                    tbx_nbr.Visibility = Visibility.Collapsed;
                    Lbx_Articles.Visibility = Visibility.Collapsed;
                    break;
                case "Table":
                    lbx_nom.Visibility = Visibility.Collapsed;
                    lbx_ttc.Visibility = Visibility.Collapsed;
                    lbx_tva.Visibility = Visibility.Collapsed;
                    tbx_nom.Visibility = Visibility.Collapsed;
                    tbx_ttc.Visibility = Visibility.Collapsed;
                    tbx_tva.Visibility = Visibility.Collapsed;
                    lbx_num.Visibility = Visibility.Visible;
                    lbx_nbr.Visibility = Visibility.Visible;
                    tbx_num.Visibility = Visibility.Visible;
                    tbx_nbr.Visibility = Visibility.Visible;
                    break;
                case "Commande":
                    lbx_nom.Visibility = Visibility.Collapsed;
                    lbx_ttc.Visibility = Visibility.Collapsed;
                    lbx_tva.Visibility = Visibility.Collapsed;
                    tbx_nom.Visibility = Visibility.Collapsed;
                    tbx_ttc.Visibility = Visibility.Collapsed;
                    tbx_tva.Visibility = Visibility.Collapsed;
                    lbx_num.Visibility = Visibility.Visible;
                    lbx_nbr.Visibility = Visibility.Collapsed;
                    tbx_num.Visibility = Visibility.Visible;
                    tbx_nbr.Visibility = Visibility.Collapsed;
                    break;
            }
                
                if (selectedChoice == "Menu")
            {
                
            }
            if (selectedChoice == "Article")
            {
                Lbx_Articles.Visibility = Visibility.Collapsed;
            }
        }
    }
}