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
    public class AhorrosRepositories
    {
        #region Ahorros
        private static List<Ahorros> lugar = new List<Ahorros>();
        public List<Ahorros> getAhorros()
        {
            // Creamos la lista genérica de Personas
            List<Ahorros> lista = new List<Ahorros>();

            // Obtenemos la ruta de archivo XML
            string ruta = HttpContext.Current.Server.MapPath("/Datos/CuentasAhorros.xml");

            XDocument doc = XDocument.Load(ruta);

            var corrientec = from c in doc.Descendants("Cuentas") select c;

            foreach (XElement c in corrientec.Elements("Ahorros"))
            {
                Ahorros ahorro = new Ahorros(

                                                   c.Element("Cliente").Value,
                                                   c.Element("Identificacion").Value,
                                                   c.Element("IDCliente").Value,
                                                   double.Parse(c.Element("Balance").Value),
                                                   float.Parse(c.Element("tasadeinteres").Value)





                                               );
                lista.Add(ahorro);

            }


            return lista;
        }

        public void add(Ahorros c)
        {
            lugar.Add(c);
            WriteXML(lugar);

        }

        private void WriteXML(List<Ahorros> list)
        {
            XmlTextWriter xmlwriter = new XmlTextWriter(HttpContext.Current.Server.MapPath("/Datos/CuentasAhorros.xml"), System.Text.Encoding.UTF8);

            //Inicio XML Documento
            xmlwriter.WriteStartDocument(true);
            xmlwriter.Formatting = Formatting.Indented;
            xmlwriter.Indentation = 2;

            //ROOT Element
            xmlwriter.WriteStartElement("Cuentas");
            //Call create nodes method
            foreach (Ahorros c in list)
            {
                xmlwriter.WriteStartElement("Ahorros");
                xmlwriter.WriteElementString("Cliente", c.Cliente);
                xmlwriter.WriteElementString("IDCliente", c.Idcliente);
                xmlwriter.WriteElementString("Identificacion", c.Identificacion);
                xmlwriter.WriteElementString("Balance", c.Balance.ToString());
                xmlwriter.WriteElementString("tasadeinteres", c.Tasadeinteres.ToString());

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