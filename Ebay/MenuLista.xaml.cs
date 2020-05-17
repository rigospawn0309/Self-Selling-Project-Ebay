using Ebay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ebay
{
    /// <summary>
    /// Lógica de interacción para MenuLista.xaml
    /// </summary>
    public partial class MenuLista : Page
    {
        public MenuLista()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh() 
        {
            List<ProductViewModel> lst = new List<ProductViewModel>();
            using (Model.MiBaseEntities1 db = new Model.MiBaseEntities1())
            {
                lst = (from d in db.Producto
                       select new ProductViewModel
                       {
                           IdProducto = d.IdProducto,
                           Articulo = d.Articulo,
                           Compañia = d.Compañia,
                           Marca = d.Marca,
                           Modelo = d.Modelo,
                           DescripciónVenta = d.DescripciónVenta,
                       }).ToList();
            }
            DG.ItemsSource = lst;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame.Content = new Formulario();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int IdProducto = (int)((Button)sender).CommandParameter;
            using (Model.MiBaseEntities1 db = new Model.MiBaseEntities1())
            {
                var oProducto = db.Producto.Find(IdProducto);
                db.Producto.Remove(oProducto);
                db.SaveChanges();
            }
            Refresh();
        }

        private void Button_Editar(object sender, RoutedEventArgs e)
        {
            int IdProducto = (int)((Button)sender).CommandParameter;

            Formulario pFormulario = new Formulario(IdProducto);

            MainWindow.StaticMainFrame.Content = pFormulario; // Se asigna la pagina que se ha creado
        }
    }
    public class ProductViewModel
    { 
        public int IdProducto { get; set; }
        public string Articulo { get; set; }
        public string Compañia { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string DescripciónVenta { get; set; }




    }
}
