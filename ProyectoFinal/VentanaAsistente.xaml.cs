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
    /// Interaction logic for VentanaAsistente.xaml
    /// </summary>
    public partial class VentanaAsistente : Window
    {
        public VentanaAsistente()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //instanciasr base de datos

            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtape.Text, @"^[a-zA-Z]+$"))
            {
                ConexionBD db = new ConexionBD();
                Asistente asis = new Asistente();
                asis.Nombre = txtnombre.Text;
                asis.Apellido = txtape.Text;
                asis.Telefono = txttel.Text;
                db.Asistente.Add(asis);
                db.SaveChanges();
                MessageBox.Show("Se ingresaron los datos Con Exito!");
                var registros = from s in db.Asistente

                                select s;

                dbgrid.ItemsSource = registros.ToList();
                txtnombre.Clear();
                txtape.Clear();
                txttel.Clear();
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
                var asis = db.Asistente.SingleOrDefault(x => x.IdAsistente == id);
                if (asis != null)
                {
                    db.Asistente.Remove(asis);
                    db.SaveChanges();
                    MessageBox.Show("Se Elimino con exito!");
                    var registros = from s in db.Asistente

                                    select s;

                    dbgrid.ItemsSource = registros.ToList();
                    txtid.Clear();
                    
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
                var asis = db.Asistente.SingleOrDefault(x => x.IdAsistente == id);
                if (asis != null)
                {
                    asis.Nombre = txtnombre.Text;
                    asis.Apellido = txtape.Text;
                    asis.Telefono = txttel.Text;
                    db.SaveChanges();
                    MessageBox.Show("Los cambios Fueron Exitosos!");
                    var registros = from s in db.Asistente

                                    select s;

                    dbgrid.ItemsSource = registros.ToList();
                    txtid.Clear();
                    txtnombre.Clear();
                    txtape.Clear();
                    txttel.Clear();
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
                var registros = from s in db.Asistente
                                where s.IdAsistente == id
                                select new
                                {
                                    s.Nombre,
                                    s.Apellido,
                                    s.Telefono
                                };
                dbgrid.ItemsSource = registros.ToList();
            }
            else
            {
                MessageBox.Show("Ingrese  ID del Proveedor a consultar");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ConexionBD db = new ConexionBD();
            var registros = from s in db.Asistente

                            select s;

            dbgrid.ItemsSource = registros.ToList();
        }
    }
}