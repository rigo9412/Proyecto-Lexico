using Automatas;
using Automatas.Clases;
using System;
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
        String Stringconnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Rigoberto\\Documents\\GitHub\\Proyecto-Lexico\\AUTOMATAS.accdb;Persist Security Info=True";
        public Form1()
        {
           
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.DefaultExt = "*.txt";
                openFileDialog1.Filter = "TXT Files|*.txt";
                Conexion.conexionString = Stringconnection;
                Conexion.nombreTabla = "Lexico";
               

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
            Stream myStream;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                if ((myStream = openFileDialog1.OpenFile())!=null)
                {
                    string strfilename = openFileDialog1.FileName;
                    string fileText = File.ReadAllText(strfilename);
                    richTextBox1.Text = fileText;
                } 
            }
        }
   

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            Matriz MT = new Matriz("1");//Inicializo mi matriz de transicion en el estado 1 que es mi estado inicial
            int codAcsii = 0;//inicializo mis variables en 0
            byte[] array;
            string respuesta = "";

          
                string cadena = richTextBox1.Text + "\u0003";//HAY QUE BUSCAR COMO MANEJAR LOS SALTOS DE LINEA
               // cadena = cadena.Replace(' ', '\u0003');
                cadena=PreparaCadena(cadena);
                for (int i = 0; i < cadena.Length; i++)
                {
                    //MessageBox.Show(MT.Estado);
                    
                    array = Encoding.ASCII.GetBytes(cadena[i].ToString());//Se obtiene el codigo ACSII
                    codAcsii = int.Parse(array[0].ToString());
                      // MessageBox.Show(codAcsii.ToString());
                   
                        respuesta = MT.ConsultarEstado(MT.ValidadCaracter(codAcsii), MT.Estado);
                        if (respuesta != "OK")
                        {
                            if (respuesta == "ACEPTA")
                            {
                                MT.ConsultarEstado(Conexion.columna, MT.Estado);
                                // MessageBox.Show(MT.Estado);
                                richTextBox2.Text = richTextBox2.Text + MT.Estado+" " ;
                                MT.Estado = "1";
                            }
                            else
                            {
                                MessageBox.Show("Error " + MT.Estado +" "+codAcsii);
                                break;
                            }
                        }
                   
                }
               
           
            
        }

        private string PreparaCadena(string cadena)
        {
            StringBuilder sb = new StringBuilder(cadena);
            for (int i = 0; i < sb.Length; i++)
            {
                if (cadena[i]=='"')
                {
                    for (int j = i; j < sb.Length; j++)
                    {
                        if (cadena[j] == '\"' && j > i)
                        {

                            i = j;
                            break;
                        }

                    }
                }
                else if (cadena[i]==' ')
                {
                    sb.Replace(' ','\u0003',i,1);
                }

            }
            return sb.ToString();
        }  

   
    }
}
