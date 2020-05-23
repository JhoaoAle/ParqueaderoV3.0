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
        private int hora=6;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextoHora.Text = hora.ToString();

            }
        }

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
}