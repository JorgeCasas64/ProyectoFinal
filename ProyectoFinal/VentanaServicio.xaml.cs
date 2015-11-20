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
    /// Interaction logic for VentanaServicio.xaml
    /// </summary>
    public partial class VentanaServicio : Window
    {
        public VentanaServicio()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //instanciasr base de datos

            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtprecio.Text, @"^\d+$"))
            {
                ConexionBD db = new ConexionBD();
                Servicio serv = new Servicio();
                serv.NombreServicio = txtnombre.Text;
                serv.Precio = float.Parse(txtprecio.Text);
                db.servicio.Add(serv);
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
                var serv = db.servicio.SingleOrDefault(x => x.IdServicio == id);
                if (serv != null)
                {
                    db.servicio.Remove(serv);
                    db.SaveChanges();
                    MessageBox.Show("Se Elimino con exito!");
                }
            }
            else
            {
                MessageBox.Show("SOLO NUMEROS");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$"))
            {

                ConexionBD db = new ConexionBD();
                int id = int.Parse(txtid.Text);
                var serv = db.servicio.SingleOrDefault(x => x.IdServicio == id);
                if (serv != null)
                {
                    serv.NombreServicio = txtnombre.Text;
                    serv.Precio = float.Parse(txtprecio.Text);
                    db.SaveChanges();
                    MessageBox.Show("Los cambios Fueron Exitosos!");
                }
                else
                {
                    MessageBox.Show("INGRESE BIEN LOS DATOS");
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                ConexionBD db = new ConexionBD();
                int id = int.Parse(txtid.Text);
                var registros = from s in db.servicio
                                where s.IdServicio == id
                                select new
                                {
                                    s.NombreServicio,
                                    s.Precio
                                };
                dbgrid.ItemsSource = registros.ToList();
            }
            else
            {
                MessageBox.Show("Ingrese  ID del Servicio a consultar");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ConexionBD db = new ConexionBD();
            var registros = from s in db.servicio

                            select s;

            dbgrid.ItemsSource = registros.ToList();
        }
    }
}
