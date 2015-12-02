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
            columna =  codAcsii.ToString();//convierte el caracter leeido a un string 
            return columna;
        }

        public string ConsultarEstado(string columna,string estado, DataGridView x)//metodo para consultar el siguiente estado
        {
            try
            {
                string respuesta = "OK";
                int rowIndex = -1;
                if (columna != "")//si la columna no esta vacia entra a este if
                {
                    // respuesta = Conexion.TraerEstadoDeBD(columna, estado); //va a a la base de datos y trae un estado

                    //Busca el estado en el datagrid ya previamente llenado 
                    DataGridViewRow row = x.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells["ESTADO"].Value.ToString().Equals(estado))
                        .First();

                    rowIndex = row.Index;//obtiene el index en donde se encuentra el estado en la tabla
                    Conexion.estado = x.Rows[rowIndex].Cells[columna].Value.ToString();//saca el estado siguiente


                    if (columna == "3" && Conexion.estado != "ERROR") // si la columna es un FDC=3 y el estado regreso algo distinto de error entra aqui
                    {
                        respuesta = "ACEPTA";//regreso una respuesta acepta para ir por el token a la tabla
                        Conexion.columna = "CAT";//posiciono la columna en la columna CAT
                        estado = Conexion.estado; // Paso el estado actual
                        this.estado = Conexion.estado;//Paso el estado al
                    }
                    else if (Conexion.estado == "ERROR")
                    {
                        respuesta = "ERROR";
                    }

                    else // si entra aqui solo sigue el recorrido hasta encontrar un FDC
                    {
                        estado = Conexion.estado;
                        this.estado = Conexion.estado;//Paso el estado al
                    }


                    return respuesta;
                }
                else//si entra aqui no encontro la columna que buscaba
                {
                    return respuesta = "Se encontro un caracter no valido en la cadena";
                }
            }
            catch(Exception es)// capturo cualquier error
            {
                return es.Message;
            }
            
        }



    }
}
