using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.RegistroClient cliente = new ServiceReference1.RegistroClient())
            {
                try
                {
                    cliente.guardar(Int32.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, Int32.Parse(textBox5.Text), textBox6.Text, (textBox7.Text),  textBox8.Text);
                MessageBox.Show("Datos guardados!");
                }

                catch
                {
                    MessageBox.Show("No hay datos para guardar!");
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            using (ServiceReference1.RegistroClient cliente = new ServiceReference1.RegistroClient())
            {
                try
                {

                    if (cliente.borrar(Int32.Parse(textBox1.Text)))
                {
                    MessageBox.Show("Elemento Eliminado!");
                }
                else
                {
                    MessageBox.Show("Elemento No Encontrado!");
                }
                }
                catch
                {
                    MessageBox.Show("No hay datos que eliminar!");
                }


            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.RegistroClient cliente = new ServiceReference1.RegistroClient())
            {
                try
                {
                    if (cliente.editar(Int32.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, Int32.Parse(textBox5.Text), textBox6.Text, textBox7.Text, textBox8.Text))
                {
                    MessageBox.Show("Elemento editado!");
                }
                else
                {
                    MessageBox.Show("Elemento No editado!");
                }
                }
                catch
                {
                    MessageBox.Show("No hay datos que modificar!");
                }

            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] vector = new string[7];
            using (ServiceReference1.RegistroClient cliente = new ServiceReference1.RegistroClient())
            {
                try
                {
                    vector = cliente.buscar(Convert.ToInt32(textBox1.Text));
                if (vector[0] == null)
                {
                    MessageBox.Show("No hay datos!");
                }
                else
                {
                    
                    textBox2.Text = vector[1];
                    textBox3.Text = vector[2];
                    textBox4.Text = vector[3];
                    textBox5.Text = vector[4];
                    textBox6.Text = vector[5];
                    textBox7.Text = vector[6];
                    textBox8.Text = vector[7];
                }
                }
                catch
                {
                    MessageBox.Show("No hay datos que buscar!");
                }



            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lista;
            using (ServiceReference1.RegistroClient cliente = new ServiceReference1.RegistroClient())
            {  
                try
                {

                    lista = cliente.mostrar();
                for (int i = 0; i < lista.Count<string>(); i = i + 8)
                {
                    listBox1.Items.Add(lista[i].ToString() + " " + lista[i + 1].ToString() + " " + lista[i + 2].ToString() + " " + lista[i + 3].ToString() + " " + lista[i + 4].ToString() + " " + lista[i + 5].ToString() +" " + lista[i + 6].ToString() + " " + lista[i + 7].ToString());
                }
                }
                catch
                {
                    MessageBox.Show("No hay datos que  mostrar!");
                }


            }

        }

    }
}
