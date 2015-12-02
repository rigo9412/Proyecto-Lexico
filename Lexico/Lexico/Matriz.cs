using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatas.Clases
{
   public class Matriz
    {
        private string columna;
        private string estado;
        private int p;
        //private List<string> titulosColumnas;

        public Matriz(string estado)//List<string> titulosColumnas)
        {
            this.estado = estado;
           // this.titulosColumnas = new List<string>(titulosColumnas);
            this.columna = "";
        }

        public string Estado { 
            get
            {
                return estado;
            }
             set
             {
                 this.estado = value;
             } 
        }
        public string Columna {
            get
            {
                return columna;
            }
            set
            {
                this.columna = value;
            }
        }
   

        public string ValidadCaracter(int codAcsii)//METODO PARA VALIDAR EL ESTADO DEL CARACTER
        {
            columna =  codAcsii.ToString();
            //if (codAcsii == 3)//" " espacio fin de cadena
            //{
            //    columna = "FDC";
            //}
            

            return columna;
        }

        public string ConsultarEstado(string columna,string estado, DataGridView x)//metodo para ver un estado
        {
            try
            {
                string respuesta = "OK";
                int rowIndex = -1;
                if (columna != "")
                {
                    // respuesta = Conexion.TraerEstadoDeBD(columna, estado); //va a a la base de datos y trae un estado

                    //BUSCAR ESTADO
                    DataGridViewRow row = x.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells["ESTADO"].Value.ToString().Equals(estado))
                        .First();

                    rowIndex = row.Index;
                    Conexion.estado = x.Rows[rowIndex].Cells[columna].Value.ToString();


                    if (columna == "3" && Conexion.estado != "ERROR")
                    {
                        respuesta = "ACEPTA";
                        Conexion.columna = "CAT";
                        estado = Conexion.estado;
                        this.estado = Conexion.estado;//Paso el estado al
                    }
                    else if (Conexion.estado == "ERROR")
                    {
                        respuesta = "ERROR";
                    }

                    else
                    {
                        estado = Conexion.estado;
                        this.estado = Conexion.estado;//Paso el estado al
                    }




                    return respuesta;
                }
                else//si entra aqui esque hay errores de conexion
                {
                    return respuesta = "Se encontro un caracter no valido en la cadena";
                }
            }
            catch(Exception es)
            {
                return es.Message;
            }
            
        }



    }
}
