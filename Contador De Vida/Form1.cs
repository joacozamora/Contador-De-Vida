using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contador_De_Vida
{
    public partial class Form1 : Form
    {

        
        






        public ListaCalculo ListaCalculo { get; set; } = new ListaCalculo();
        public Contadores Contadores { get; set; } = new Contadores();
        public Form1()
        {
            InitializeComponent();
            /*Bitmap img = new Bitmap(Application.StartupPath + @"\img\fondo.jpg");
            this.BackgroundImage = img;*/
            dataGridView1.DataSource = ListaCalculo.dt;


        }

        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            

            Contadores.Anio_Nacimiento = dateTimePicker1.Value.Year;
            Contadores.Mes_Nacimiento = dateTimePicker1.Value.Month;
            Contadores.Dia_Nacimiento = dateTimePicker1.Value.Day;



        }

        public void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            Contadores.Anio_Actual = dateTimePicker2.Value.Year;
            Contadores.Mes_Actual = dateTimePicker2.Value.Month;
            Contadores.Dia_Actual = dateTimePicker2.Value.Day;





        }

        public void button1_Click(object sender, EventArgs e)
        {

            int i = 0;

            while (i != 51)
            {



                string cadena = new string('|', i);
                lblCargando.Text = cadena;
                Thread.Sleep(5);
                this.Refresh();
                i = i + 1;

            }



            bool opcion0 = false;
            if (Contadores.Anio_Actual == 0)
            {
                MessageBox.Show("Debes remarcar aunque sea una vez la fecha actual o dara error en los numeros.");

                opcion0 = true;
            }

            if (opcion0 == true)
            {
                Contadores.Meses_Vividos = -1;
                Contadores.Dias_Vividos = -1;
                Contadores.Anios_Vividos = -1;

            }


            bool opcion1 = false;
            if (Contadores.Dia_Actual < Contadores.Dia_Nacimiento && Contadores.Mes_Actual < Contadores.Mes_Nacimiento &&
                opcion0 == false)
            {
                opcion1 = true;
            }

            bool opcion2 = false;
            if (Contadores.Dia_Actual < Contadores.Dia_Nacimiento && Contadores.Mes_Actual > Contadores.Mes_Nacimiento)
            {
                opcion2 = true;
            }
            bool opcion3 = false;
            if (Contadores.Dia_Actual > Contadores.Dia_Nacimiento && Contadores.Mes_Actual < Contadores.Mes_Nacimiento)
            {
                opcion3 = true;
            }
            bool opcion4 = false;
            if (Contadores.Dia_Actual >= Contadores.Dia_Nacimiento && Contadores.Mes_Actual >= Contadores.Mes_Nacimiento)
            {
                opcion4 = true;
            }



            if (opcion1 == true)
            {
                Contadores.Meses_Vividos = (12 - Contadores.Mes_Nacimiento) + Contadores.Mes_Actual - 1;
                Contadores.Dias_Vividos = (30 - Contadores.Dia_Nacimiento) + Contadores.Dia_Actual;
                Contadores.Anios_Vividos = Contadores.Anio_Actual - Contadores.Anio_Nacimiento - 1;
            }

            else if (opcion2 == true)
            {
                Contadores.Meses_Vividos = (Contadores.Mes_Actual - Contadores.Mes_Nacimiento) - 1;
                Contadores.Dias_Vividos = (30 - Contadores.Dia_Nacimiento) + Contadores.Dia_Actual;
                Contadores.Anios_Vividos = Contadores.Anio_Actual - Contadores.Anio_Nacimiento;


            }

            else if (opcion3 == true)
            {
                Contadores.Meses_Vividos = (12 - Contadores.Mes_Nacimiento) + Contadores.Mes_Actual;
                Contadores.Dias_Vividos = Contadores.Dia_Actual - Contadores.Dia_Nacimiento;
                Contadores.Anios_Vividos = Contadores.Anio_Actual - Contadores.Anio_Nacimiento - 1;
            }

            else if (opcion4 == true)
            {
                Contadores.Meses_Vividos = Contadores.Mes_Actual - Contadores.Mes_Nacimiento;
                Contadores.Dias_Vividos = Contadores.Dia_Actual - Contadores.Dia_Nacimiento;
                Contadores.Anios_Vividos = Contadores.Anio_Actual - Contadores.Anio_Nacimiento;
            }




            lblAnios.Text = System.Convert.ToString(Contadores.Anios_Vividos);
            lblMes.Text = System.Convert.ToString(Contadores.Meses_Vividos);
            lblDias.Text = System.Convert.ToString(Contadores.Dias_Vividos);

            ListaCalculo.Cargar(Contadores);
        }

        public void button2_Click(object sender, EventArgs e)
        {
            int Cantidad_Dias_Meses = Contadores.Meses_Vividos * 30;
            int Cantidad_Dias_Anios = Contadores.Anios_Vividos * 365;
            int Cantidad_Dias_Total = Contadores.Dias_Vividos + Cantidad_Dias_Anios + Cantidad_Dias_Meses;
            lblTotalDias.Text = System.Convert.ToString(Cantidad_Dias_Total);
            ListaCalculo.Cargar(Contadores);
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }
    }
}
