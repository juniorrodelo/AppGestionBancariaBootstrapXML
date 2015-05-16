using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Modelo;
using App.Datos;

namespace App.Web
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            double balance = double.Parse(txtbalance.Text);
            float limitesDeCreditos = float.Parse(txtlimitesDeCreditos.Text);
            
            float tasaint = float.Parse(txttasadeinteresh.Text);

            string shipping_type = type.SelectedItem.Value;

            if (shipping_type == "corrientes")
            {
                float tasaInteres = float.Parse(txttasaInteres.Text);
                Corrientes c = new Corrientes(
                                            txtcliente.Text,
                                            txtId.Text,
                                            txtIdCliente.Text,
                                            balance,
                                            limitesDeCreditos,
                                            tasaInteres


                                           );



                CorrientesRepositories data = new CorrientesRepositories();

                data.add(c);
            }

            if (shipping_type == "cheques")
            {

                Cheques c = new Cheques(
                                            txtcliente.Text,
                                            txtId.Text,
                                            txtIdCliente.Text,
                                            balance,
                                            idtalonario.Text


                                           );



                ChequesRepositories meta = new ChequesRepositories();

                meta.add(c);
            }

            if (shipping_type == "ahorros")
            {

                Ahorros c = new Ahorros(
                                            txtcliente.Text,
                                            txtId.Text,
                                            txtIdCliente.Text,
                                            balance,
                                           tasaint


                                           );



                AhorrosRepositories lugar = new AhorrosRepositories();

                lugar.add(c);
            }
        }
    }
}