using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Modelo;
using System.Xml;
using System.Web.Hosting;
using System.IO;
using System.Xml.Linq;


namespace App.Datos
{
    public class ChequesRepositories
    {
        #region Cheques
        private static List<Cheques> meta = new List<Cheques>();


        public List<Cheques> getCheques()
        {
            // Creamos la lista genérica de Personas
            List<Cheques> lista = new List<Cheques>();

            // Obtenemos la ruta de archivo XML
            string ruta = HttpContext.Current.Server.MapPath("/Datos/CuentasCheques.xml");

            XDocument doc = XDocument.Load(ruta);

            var corrientec = from c in doc.Descendants("Cuentas") select c;

            foreach (XElement c in corrientec.Elements("cheques"))
            {
                Cheques cheque = new Cheques(

                                                  c.Element("Cliente").Value,
                                                  c.Element("Identificacion").Value,
                                                  c.Element("IDCliente").Value,
                                                  double.Parse(c.Element("Balance").Value),
                                                  c.Element("IdTalonario").Value





                                              );
                lista.Add(cheque);

            }




            return lista;
        }

        public void add(Cheques c)
        {
            meta.Add(c);
            WriteXML(meta);

        }


        private void WriteXML(List<Cheques> list)
        {
            XmlTextWriter xmlwriter = new XmlTextWriter(HttpContext.Current.Server.MapPath("/Datos/CuentasCheques.xml"), System.Text.Encoding.UTF8);

            //Inicio XML Documento
            xmlwriter.WriteStartDocument(true);
            xmlwriter.Formatting = Formatting.Indented;
            xmlwriter.Indentation = 2;

            //ROOT Element
            xmlwriter.WriteStartElement("Cuentas");
            //Call create nodes method
            foreach (Cheques c in list)
            {
                xmlwriter.WriteStartElement("cheques");
                xmlwriter.WriteElementString("Cliente", c.Cliente);
                xmlwriter.WriteElementString("IDCliente", c.Idcliente);
                xmlwriter.WriteElementString("Identificacion", c.Identificacion);
                xmlwriter.WriteElementString("Balance", c.Balance.ToString());
                xmlwriter.WriteElementString("IdTalonario", c.IdTalonario);

                xmlwriter.WriteEndElement();
            }

            xmlwriter.WriteEndElement();

            //End XML Document
            xmlwriter.WriteEndDocument();

            //Close Write
            xmlwriter.Close();
        }
        #endregion
    }
}