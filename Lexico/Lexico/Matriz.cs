using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (codAcsii == 32)//" " espacio fin de cadena
            {
                columna = "FDC";
            }
            //else if (codAcsii == 10)//volver a empezar
            //{
            //   // DUDA columna = "CAT";
            //    //estado = "1";
            //    //Conexion.estado = "1";
            //}

            return columna;
        }

        public string ConsultarEstado(string columna,string estado)//metodo para ver un estado
        {
            string respuesta;

            if (columna != "")
            {
                respuesta = Conexion.TraerEstadoDeBD(columna, estado); //va a a la base de datos y trae un estado
                if (respuesta == "OK")// si regresa un OK es no ocurrio Errores de conexion
                {
                    if (Conexion.estado=="ERROR")
                    {
                        respuesta = "ERROR";
                    }
                    else if (columna=="FDC" && respuesta=="OK")
                    {
                        respuesta = "ACEPTA";
                        Conexion.columna = "CAT";
                        estado = Conexion.estado;
                        this.estado = Conexion.estado;//Paso el estado al
                    }
                    else
                    {
                        estado = Conexion.estado;
                        this.estado = Conexion.estado;//Paso el estado al
                    }
                    
                    
                   
                }
                return respuesta;
            }
            else//si entra aqui esque hay errores de conexion
            {
                return respuesta="Se encontro un caracter no valido en la cadena";
            }
            
        }



    }
}
