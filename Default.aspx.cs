using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        protected void AumentarHora_Click(object sender, EventArgs e)
        {

            if (ViewState["click"] != null)
            {
                hora = (int)ViewState["click"] + 1;
                if (hora > 21)
                    hora = 6;

            }
            TextoHora.Text = hora.ToString();
            ViewState["click"] = hora;

        }
    }


    public class Carro
    {
        public string placa;
        public int entrada;
        public int salida;


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
