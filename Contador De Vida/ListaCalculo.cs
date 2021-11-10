using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Contador_De_Vida
{
    public class ListaCalculo
    {
        public DataTable dt = new DataTable();
        public ListaCalculo()
        {
            dt.TableName = "DatosPasados";
            dt.Columns.Add("AnioNacimiento");
            dt.Columns.Add("MesNacimiento");
            dt.Columns.Add("DiaNacimiento");
            dt.Columns.Add("DiasVividos");

            Leerdt_Archivo();

        }
        public void Cargar(Contadores Contador)
        {
            dt.Rows.Add();
            int NumDeRegistro = dt.Rows.Count - 1;
            dt.Rows[NumDeRegistro]["AnioNacimiento"] = Contador.Anio_Nacimiento;
            dt.Rows[NumDeRegistro]["MesNacimiento"] = Contador.Mes_Nacimiento;
            dt.Rows[NumDeRegistro]["DiaNacimiento"] = Contador.Dia_Nacimiento;
            dt.Rows[NumDeRegistro]["DiasVividos"] = Contador.Dias_Vividos;

            dt.WriteXml("Contador.xml");
        }
        public void Leerdt_Archivo()
        {
            if (System.IO.File.Exists("Contador.xml"))
            {
                dt.Clear();
                dt.ReadXml("Contador.xml");

            }
        }
    }
}
