using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

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
        static string connection = "SERVER=127.0.0.1; PORT=3306;DATABASE=parqueadero;UID=root;PASSWORDS=";
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

        protected void btn_Ingresar_Click(object sender, EventArgs e)
        {

        }

        protected void placa_a_retirar_TextChanged(object sender, EventArgs e)
        {

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
