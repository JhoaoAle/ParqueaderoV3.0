using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace WebApplication2
{



    public partial class _Default : Page
    {
        

        private int hora = 6;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                TextoHora.Text = hora.ToString();
                
            }
        }

        
        

        Carro car = new Carro();

        /*NO TOCAR NADA DE AQUÍ*/
        /*Conexión a la base de datos*/
        static string connection = "SERVER=127.0.0.1; PORT=3306;DATABASE=parqueadero;UID=root;PASSWORDS=;";
        MySqlConnection cn = new MySqlConnection(connection);
        /*Aumento de hora vía botón*/
        protected void AumentarHora_Click(object sender, EventArgs e)
        {
            cn.Open();
            if (ViewState["click"] != null)
            {
                hora = (int)ViewState["click"] + 1;
                if (hora > 21)
                    hora = 6;

            }
            TextoHora.Text = hora.ToString();
            ViewState["click"] = hora;
        }


        protected void btn_ingresar_Click1(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(casilla_in.Text, out n);
            int result = Int32.Parse(casilla_in.Text);

            if (placa_text.Text.Length != 7)
            {
                //TODO Mensaje de error relacionado con la placa
                
            }
            else if ((isNumeric == false) || result < 1 || result > 40)
            {
                //TODO Mensaje de error relacionado con el espacio a ocupar
                
            }
            else
            {
                cn.Open();
                MySqlCommand command = new MySqlCommand("SELECT `ocupado` FROM `parqueo` WHERE `casilla` ='"+result+"'", cn);
                int ocupado = System.Convert.ToInt32(command.ExecuteScalar());
                if (ocupado == 1)
                {
                    //TODO Mensaje de error relacionado con la disponibilidad de la casilla
                   
                }
                else
                {
                    //Este apartado realiza la consulta para ingresar
                    string query = "UPDATE `parqueo` SET `casilla`='" + result + "',`placa`='" + placa_text.Text + "',`hora_entrada`='" + TextoHora.Text + "',`hora_salida`=null,`ocupado`= '1' WHERE `casilla`= '" + result + "'";
                    MySqlCommand commandDatabase = cn.CreateCommand();
                    int hora = int.Parse(TextoHora.Text);
                    MySqlCommand command2 = new MySqlCommand(query, cn);
                    command2.ExecuteNonQuery();
                    cn.Close();
                    casilla_in.Text = "";
                    placa_text.Text = "";
                }
            }
            

        }

        protected void btn_retirar_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(casilla_out.Text, out n);
            int result = Int32.Parse(casilla_out.Text);

            if ((isNumeric == false) || result < 1 || result > 40)
            {
                //TODO Mensaje de error relacionado con el espacio a liberar
            }
            else
            {
                cn.Open();
                MySqlCommand command = new MySqlCommand("SELECT `hora_entrada` FROM `parqueo` WHERE `casilla` ='" + result + "'", cn);
                int hora_entra = System.Convert.ToInt32(command.ExecuteScalar());
                int hora_sale = int.Parse(TextoHora.Text);
                int tarifa = 3000;
                int cobro = (hora_sale - hora_entra) * tarifa;


                //Este apartado realiza la consulta para liberar un espacio
                string query = "UPDATE `parqueo` SET `casilla`='" + result + "',`placa`=null,`hora_entrada`=null,`hora_salida`=null,`ocupado`= '0' WHERE `casilla`= '" + result + "'";
                MySqlCommand command2 = new MySqlCommand(query, cn);
                command2.ExecuteNonQuery();
                cn.Close();
                casilla_out.Text = "";
                if (cobro <= 0)
                    cobro += 24*tarifa;
                string factura = "Debe pagar un total de $" + cobro +" por concepto de parqueadero. Favor acercarse al punto de pago más cercano. \n Tenga usted un buen día";
                //TODO: Mostrar esto al usuario de algún modo
            }
        }
    }

    /*Clase carro pedida en el planteamiento del problema*/

    public class Carro
    {
        public string placa;
        public int entrada;
        public int salida;

        /* Prueba de concepto
         */
        public Carro()
        {
            this.placa = "Unknown";
        }

        public Carro(string placa)
        {
            this.placa = placa;
        }

        public void Ingresar(int entrada)
        {
            this.entrada = entrada;
        }

        public void Retirar(int salida)
        {
            this.salida = salida;
        }

        public string getPlaca()
        {
            return this.placa;
        }

    }
}
