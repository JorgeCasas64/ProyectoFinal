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
using System.Text.RegularExpressions;
namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for VentanaProvedor.xaml
    /// </summary>
    public partial class VentanaProvedor : Window
    {
        public VentanaProvedor()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //instanciasr base de datos

            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtdirecion.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtgiro.Text, @"^[a-zA-Z]+$"))
            {
                ConexionBD db = new ConexionBD();
                Proveedor prov = new Proveedor();
                prov.NombreProveedor = txtnombre.Text;
                prov.Direccion = txtdirecion.Text;
                prov.Giro = txtgiro.Text;
                db.Proveedor.Add(prov);
                db.SaveChanges();
                MessageBox.Show("Se ingresaron los datos Con Exito!");
            }
            else
            {
                MessageBox.Show("INGRESE BIEN LOS DATOS");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {

                ConexionBD db = new ConexionBD();
                int id = int.Parse(txtid.Text);
                var prov = db.Proveedor.SingleOrDefault(x => x.IdProveedor == id);
                if (prov != null)
                {
                    db.Proveedor.Remove(prov);
                    db.SaveChanges();
                    MessageBox.Show("Se Elimino con exito!");
                }
            }
            else
            {
                MessageBox.Show("SOLO NUMEROS");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ConexionBD db = new ConexionBD();
            var registros = from s in db.Proveedor

                            select s;

            dbgrid.ItemsSource = registros.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                ConexionBD db = new ConexionBD();
                int id = int.Parse(txtid.Text);
                var registros = from s in db.Proveedor
                                where s.IdProveedor == id
                                select new
                                {
                                    s.NombreProveedor,
                                    s.Direccion,
                                    s.Giro
                                };
                dbgrid.ItemsSource = registros.ToList();
            }
            else
            {
                MessageBox.Show("Ingrese  ID del Proveedor a consultar");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$"))
            {

                ConexionBD db = new ConexionBD();
                int id = int.Parse(txtid.Text);
                var prov = db.Proveedor.SingleOrDefault(x => x.IdProveedor == id);
                if (prov != null)
                {
                    prov.NombreProveedor = txtnombre.Text;
                    prov.Direccion = txtdirecion.Text;
                    prov.Giro = txtgiro.Text;
                    db.SaveChanges();
                    MessageBox.Show("Los cambios Fueron Exitosos!");
                }
                else
                {
                    MessageBox.Show("INGRESE BIEN LOS DATOS");
                }
            }
        }
    }
}
