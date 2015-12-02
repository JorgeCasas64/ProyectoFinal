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
using System.Windows.Shapes;

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for VentanaFactura.xaml
    /// </summary>
    public partial class VentanaFactura : Window
    {
        private Servicio tempServicio = null;
        private List<Servicio> AgregarAlGrid;
        public VentanaFactura()
        {

            AgregarAlGrid = new List<Servicio>();
            InitializeComponent();
        }

        private void g_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ConexionBD db = new ConexionBD();

            cbprov.ItemsSource = db.Proveedor.ToList();
            cbprov.DisplayMemberPath = "NombreProveedor";
            cbprov.SelectedValuePath = "IdProveedor";
            cbprov.SelectedIndex = 0;
            cbasist.ItemsSource = db.Asistente.ToList();
            cbasist.DisplayMemberPath = "Nombre";
            cbasist.SelectedValuePath = "IdAsistente";
            cbasist.SelectedIndex = 0;
            //var registro = from s in db.Servicios
            //               select s;
            cbser.ItemsSource = db.servicio.ToList();
            cbser.DisplayMemberPath = "IdServicio";
            cbser.SelectedValuePath = "IdServicio";
            cbser.SelectedIndex = 0;
        }
        private void actualizaGrid()
        {

            var registros = from s in AgregarAlGrid
                            select new
                            {
                                s.IdServicio,
                                s.NombreServicio,
                                s.Precio,
                                s.ProveedorIdProveedor,



                            };
            gridfat.ItemsSource = null;
            gridfat.ItemsSource = registros;


            total.Content = string.Format("Total: {0} ", AgregarAlGrid.Sum(x => x.Precio).ToString("C"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbprov.SelectedIndex > -1 && cbser.SelectedIndex > -1)
            {
                ConexionBD db = new ConexionBD();

                int id = int.Parse(cbser.Text);
                Servicio p = db.servicio.SingleOrDefault(x => x.IdServicio == id);

                if (p != null)
                {
                    tempServicio = p;

                }

                AgregarAlGrid.Add(new Servicio()
                {
                    IdServicio = tempServicio.IdServicio,
                    NombreServicio = tempServicio.NombreServicio,
                    Precio = tempServicio.Precio,
                    ProveedorIdProveedor = tempServicio.ProveedorIdProveedor,
                });

                actualizaGrid();
                tempServicio = null;

            }
            else
            {
                MessageBox.Show("Tiene que seleccionar al menos un opcion en cada campo", "precaucion", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void guardafac_Click(object sender, RoutedEventArgs e)
        {
            ConexionBD db = new ConexionBD();
            Factura fac = new Factura();

            fac.ServicioIdServicio = (int)cbser.SelectedValue;
            fac.Fecha = DateTime.Now;
            fac.AsistenteId = (Int32)cbasist.SelectedValue;
            fac.ProveedorId = (Int32)cbprov.SelectedValue;

            actualizaGrid();
            db.Factura.Add(fac);
            db.SaveChanges();





            MessageBox.Show("Se Guardaron los datos");


            
            
        }

       
    }
}
