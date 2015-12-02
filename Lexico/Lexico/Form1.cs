using Automatas;
using Automatas.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lexico
{
    public partial class Form1 : Form
    {
        //la direccion de la base de datos
        String Stringconnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Rigoberto\\Documents\\GitHub\\Proyecto-Lexico\\AUTOMATAS.accdb;Persist Security Info=True";
       //contadores que utilizo
        int click = 0;
        int IDcontador = 0;
        int contadorCadena = 0, contadorCome = 0;
        int ContCome = 0, ContCade = 0, ContId = 0; //ContCN = 0, ContPR = 0;
        bool comentarioActivo = false;
       
        List<string> listaIDs = new List<string>();
        
        public Form1()
        {

            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Formato para codigo
                openFileDialog1.DefaultExt = "*.code";
                openFileDialog1.Filter = "CODE Files|*.code";
                saveFileDialog.DefaultExt = "*.code";
                saveFileDialog.Filter = "CODE Files|*.code";


                //formato para tokens
                openFileDialog2.DefaultExt = "*.token";
                openFileDialog2.Filter = "TOKEN Files|*.token";
                saveFileDialog1.DefaultExt = "*.token";
                saveFileDialog1.Filter = "TOKEN Files|*.token";
                Conexion.conexionString = Stringconnection;
                Conexion.nombreTabla = "Lexico";
               //prueba de fuego
               //richTextBox1.Text = "INICIO\nUBICAR ( 4 , 5 )\n\"HOLA MUNDO\"\n/*COMENTARIO GHG */\nFIN";
                //traego los datos a la datagrid
                dataGridView1.DataSource = Conexion.TraerTodosDatosDeBD();
                
             
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void MenuAbrir_Click(object sender, EventArgs e)
        {
            
        }


        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            Matriz MT = new Matriz("1");//Inicializo mi matriz de transicion en el estado 1 que es mi estado inicial
            int codAcsii = 0;//inicializo mis variables en 0
            byte[] array;
            string respuesta = "";
            string palabra = "", cadena2 = "";
            string cadena = "";
            
            contadorCadena = 0;
            contadorCome = 0;
            IDcontador = 0;
            ContCome = 0; 
            ContCade = 0;
            ContId = 0;
            listaIDs.Clear();
            ///Termina de inicializar valores
            cadena2 = richTextBox1.Text+" "; //guardo una cadena sin modificar
            cadena = richTextBox1.Text + "\u0003";       
            cadena = cadena.Replace(' ', '\u0003');//convierto los espacios en blanco en mi caracter FDC
            cadena = cadena.Replace('\n', '\u0003');//convierto los saltos de linea en mi caracter FDC
            //  cadena=PreparaCadena(cadena);
            for (int i = 0; i < cadena.Length; i++)
            {
                array = Encoding.ASCII.GetBytes(cadena[i].ToString());//Se obtiene el codigo ACSII
                codAcsii = int.Parse(array[0].ToString());
               
                if (codAcsii == '"' && contadorCadena == 0 && contadorCome==0)//si entra aqui es que puede ser una cadena 
                {
                   cadena= PreparaCadena(cadena, i); //checa si la cadena tiene fin si es asi reemplaza los FDC previamente puestos por espacios en blanco
                }
                else if (codAcsii=='/' && contadorCadena == 0 && contadorCome ==0 )//si entra aqui puede ser un comentario
                {
                    contadorCome++;

                }
                else if (codAcsii=='*' && contadorCadena == 0 && contadorCome == 1)//si detecta un * puede ser un inicio de comentario
                {
                    contadorCome++; 
                }

                if (contadorCome == 2)//si el contador es igual a dos detecto un inicio de comentario
                {
                    cadena=prepararComentario(cadena,i);//busca el fin de comentario para quitar los fin de cadena por espacio en blanco
                    contadorCome = 0;//pongo el contador en 0
                }

           
                    respuesta = MT.ConsultarEstado(MT.ValidadCaracter(codAcsii), MT.Estado,dataGridView1);//ejecunto el metodo de la clase matriz

                    if (respuesta != "OK")//si la respuesta es diferente de ok entra

                    {
                        if (respuesta == "ACEPTA")//si es acepta va por el token a la matriz
                        {
                            MT.ConsultarEstado(Conexion.columna, MT.Estado,dataGridView1);
                            // MessageBox.Show(MT.Estado);                           
                            DeterminarToken(MT.Estado, palabra,cadena2[i]);
                            MT.Estado = "1";//me regreso al estado 1 y limpio todo
                            palabra = "";
                            contadorCome = 0;
                            contadorCadena = 0;
                        }
                        else
                        {
                            
                            MessageBox.Show("Error en el estado:" + MT.Estado + " Caracter donde Inicio Error: " + Convert.ToChar(codAcsii) + "  Total de errores: " + ((cadena.Count()) - i));//muestra toda la informacion del error ocurrido
                            break;
                        }
                    }
               
                    palabra = palabra + Convert.ToChar(codAcsii).ToString();//sigue la secuencia hasta encontrar una respuesta diferente de OK
                
            }

        }




        private void DeterminarToken(string token, string palabra,char salto)//metodo para determinnar las categorias en la tabla de tokens
        {
            
            palabra =palabra.Replace('\u0003', ' ');
            palabra = palabra.Trim();
             if (token.Contains("OPREL"))
            {
                //OPERADOR RELACIONAL
                //richTextBox2.Text = richTextBox2.Text + "\t " + token + "\t\tOPERADOR RELACIONAL\n";
                DgTabla.Rows.Add(token, "OPERADOR RELACIONAL", "--");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }
            else if (token.Contains("PR"))
            {
                //Palabra reservada
               
                DgTabla.Rows.Add(token, "PLABRA RESERVADA", "--");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }
            else if (token.Contains("CN"))
            {
                //Constante numerica
                //richTextBox2.Text = richTextBox2.Text + "\t " + token + " \t\tCONSTANTE NUMERICA \t\t"+palabra+"\n";
                DgTabla.Rows.Add(token, "CONSTANTE NUMERICA", palabra);
                richTextBox2.Text = richTextBox2.Text + token+salto;
            }
            else if (token.Contains("CE"))
            {
                //CARACTER ESPECIAL
                //richTextBox2.Text = richTextBox2.Text + "\t " + token + "\t\tCARACTER ESPECIAL\n";
                DgTabla.Rows.Add(token, "CARACTER ESPECIAL", "--");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }
            else if (token.Contains("OPARI"))
            {
                //OPERADOR ARITMETICO
                //richTextBox2.Text = richTextBox2.Text + "\t" + token + "\t\tOPERADOR ARITMETICO\n";
                DgTabla.Rows.Add(token, "OPERADOR ARITMETICO", "--");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }
            else if (token.Contains("OPLOG"))
            {
                //OPERADOR LOGICO
                //richTextBox2.Text = richTextBox2.Text + "\t " + token + "\t\tOPERADOR LOGICO\n";
                DgTabla.Rows.Add(token, "OPERADOR LOGICO", "--");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }
          
            else if (token == "CADE")
            {
                //  CADENA
                ContCade++;
                DgTabla.Rows.Add(token+ContCade, "CADENA", palabra);
                richTextBox2.Text = richTextBox2.Text + token +ContCade+ salto;
                
            }
            //else if (token == "COM")
            //{
            //    // COMENTARIO    
                
            //    DgTabla.Rows.Add(token, "COMENTARIO", "--");
            //    richTextBox2.Text = richTextBox2.Text + token + salto;
                
            //}
            else if (token == "ID")
            {
                if (listaIDs.Count() > 0)//si la lista de ids es menor a cero entra aqui
                {

                    if (BuscarID(palabra) == "") // si es igual a vacio es que no existe ese id por lo tanto se da de alta 
                    {
                        IDcontador++;
                        // richTextBox2.Text = richTextBox2.Text + "\t " + token +" "+IDcontador +" \t\tIDENTIFICADOR \t\t          " + palabra + "\n";
                        DgTabla.Rows.Add(token + IDcontador, "IDENTIFICADOR", palabra);
                        listaIDs.Add(palabra + "," + token+IDcontador);
                        richTextBox2.Text = richTextBox2.Text + token + IDcontador + salto;
                       
                    }
                    else
                    {
                     //buscar en una lista de id y poneer todo
                        richTextBox2.Text = richTextBox2.Text + BuscarID(palabra) + salto;
                    }
                  
                }
                else
                {
                    //ID
                    IDcontador++;
                    // richTextBox2.Text = richTextBox2.Text + "\t " + token +" "+IDcontador +" \t\tIDENTIFICADOR \t\t          " + palabra + "\n";
                    DgTabla.Rows.Add(token + IDcontador, "IDENTIFICADOR", palabra);
                    listaIDs.Add(palabra+","+token+IDcontador);
                    richTextBox2.Text = richTextBox2.Text + token + IDcontador + salto;
                 
                }
            }
        }

        private string BuscarID(string id)//busca si el id leeido ya existia 
        {

            foreach (var item in listaIDs)
            {

                if (item.Substring(0, item.IndexOf(",")) == id)
                {
                    return item.Substring(item.IndexOf(",")+1);//regresa el id encotrado
                }
            }
            return "";//si no existe regresa una cadena vacia
        }

        private string PreparaCadena(string cadena, int posicion)
        {
            int posInicial = 0, avance = 0;
            bool bandera = false;
            StringBuilder sb = new StringBuilder(cadena);
            for (int i = posicion; i < sb.Length; i++)
            {
                if (cadena[i] == '"')//detecta la primera comilla
                {
                    for (int j = i; j < sb.Length; j++)
                    {
                        if (cadena[j] == '\"' && j > i)//busca la seguna comilla
                        {
                            //guardo todas las posiciones y detengo el ciclo
                            posInicial = i;
                            avance = j;
                            i = j;
                            bandera = true;
                            break;
                        }

                    }

                    if (bandera==true)
                    {
                        sb.Replace('\u0003',' ', posInicial,avance-posInicial);//cambio el FDC por espacio en blanco
                        contadorCadena++;
                        bandera = false;
                        break;
                    }
                }
               

            }
            return sb.ToString();
        }

        private string prepararComentario(string cadena, int posicion)//preparo el comentario
        {
            int posInicial = 0, avance = 0;
            bool bandera = false;
            StringBuilder sb = new StringBuilder(cadena);
            for (int i = posicion; i < sb.Length; i++)
            {
                char C = cadena[i];
                if ( C== '*')//hassta que encuentre un * entra aqui
                {
                    for (int j = i; j < sb.Length; j++)//busca la diagonal
                    {
                        char x = cadena[j];
                        if (x == '/' && j > i)//si la encuentra 
                        {
                            //guardo todas las coordenadas y detengo el ciclo
                            posInicial = i;
                            avance = j;
                            i = j;
                            bandera = true;
                            break;
                        }

                    }

                    if (bandera == true)
                    {
                        sb.Replace('\u0003', ' ', posInicial, avance - posInicial);//cambio el FDC por espacio en blanco
                        bandera = false;
                        
                        break;
                    }
                }


            }
            return sb.ToString();
        }

       
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
             

        }



        private void MenuGuardar_Click(object sender, EventArgs e)
        {

     



        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            DgTabla.Rows.Clear();
            

        }

        private void menuTabla_Click(object sender, EventArgs e)
        {
            if (click==0)
            {
              
                panel1.Height = this.Height;
                panel1.Width = this.Width;
                panel1.Visible = true;
                click++;
               
            }
            else
            {
                panel1.Visible = false;
             
                click = 0;
            }
          
        }

     //los metos de aqui para abajo son los metodos son para los archivos 
        private void abrirTokens_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog2.FileName.Length > 0)
            {
                if ((myStream = openFileDialog2.OpenFile()) != null)
                {
                    string strfilename = openFileDialog2.FileName;
                    string fileText = File.ReadAllText(strfilename);
                    richTextBox2.Text = fileText;
                }
            }
        }

        private void abrirCodigo_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string strfilename = openFileDialog1.FileName;
                    string fileText = File.ReadAllText(strfilename);
                    richTextBox1.Text = fileText;
                }
            }
        }

        private void guardarTokens_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {

                    sw.Write(richTextBox2.Text);
                   // richTextBox2.Clear();
                }

            }
        }

        private void guardarCodigo_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {

                    sw.Write(richTextBox1.Text);
                   // richTextBox1.Clear();
                }

            }
        }


    }
}
