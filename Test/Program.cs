using HtmlAgilityPack;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDoc = await htmlWeb
                .LoadFromWebAsync("https://www.micm.gob.do/direcciones/combustibles");
            var regs = htmlDoc.DocumentNode
                .SelectSingleNode(@"(//table[@class='art-data-table art-data-table-condensed'])[last()]");

            var listaPreciosCombustibles = regs.InnerText
              .Replace("CombustiblesPreciosGasolina PremiumRD$ ", "")
              .Replace("Gasolina RegularRD$ ", ";")
              .Replace("Gasoil ÓptimoRD$ ", ";")
              .Replace("Gasoil RegularRD$ ", ";")
              .Replace("KeroseneRD$ ", ";")
              .Replace("Gas Licuado de Petróleo (GLP)RD$ ", ";")
              .Replace("Gas Natural Vehicular (GNV)RD$ ", ";").Split(";");

            Console.ReadLine();
        }

    }
}
