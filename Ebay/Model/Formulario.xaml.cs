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

namespace Ebay.Model
{
    /// <summary>
    /// Lógica de interacción para Formulario.xaml
    /// </summary>
    public partial class Formulario : Page
    {
        public int IdProducto { get; set; }
        public Formulario(int IdProducto = 0)
        {
            InitializeComponent();

            this.IdProducto = IdProducto;

            if (this.IdProducto != 0)
            {
                using (Model.MiBaseEntities1 db = new Model.MiBaseEntities1())
                {
                    var oProducto = db.Producto.Find(this.IdProducto);

                    txtArticulo.Text = oProducto.Articulo;
                    txtCompañia.Text = oProducto.Compañia;
                    txtMarca.Text = oProducto.Marca;
                    txtModelo.Text = oProducto.Modelo;
                    txtDescripciónVenta.Text = oProducto.DescripciónVenta;

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IdProducto == 0)
            {
                using (Model.MiBaseEntities1 db = new Model.MiBaseEntities1())
                {
                    var oProducto = new Model.Producto();
                    oProducto.Articulo = txtArticulo.Text;
                    oProducto.Compañia = txtCompañia.Text;
                    oProducto.Marca = txtMarca.Text;
                    oProducto.Modelo = txtModelo.Text;
                    oProducto.DescripciónVenta = txtDescripciónVenta.Text;

                    db.Producto.Add(oProducto);
                    db.SaveChanges();

                    MainWindow.StaticMainFrame.Content = new MenuLista();
                }
            }
            else
            {
                using (Model.MiBaseEntities1 db = new Model.MiBaseEntities1())
                {
                    var oProducto = db.Producto.Find(IdProducto);
                    oProducto.Articulo = txtArticulo.Text;
                    oProducto.Compañia = txtCompañia.Text;
                    oProducto.Marca = txtMarca.Text;
                    oProducto.Modelo = txtModelo.Text;
                    oProducto.DescripciónVenta = txtDescripciónVenta.Text;

                    db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    MainWindow.StaticMainFrame.Content = new MenuLista();
                }

            }
        }
    }
}
