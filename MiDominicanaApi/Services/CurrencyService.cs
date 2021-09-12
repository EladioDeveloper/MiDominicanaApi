using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using MiDominicanaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiDominicanaApi.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly SectionUrlPage _sectionUrlPage;
        public CurrencyService(IOptions<SectionUrlPage> sectionUrlPage)
        {
            _sectionUrlPage = sectionUrlPage.Value;
        }
      
        public async Task<ICollection<Currency>> GetCurrency()
        {
            var currencyList = await RequestPage();
            List<Currency> List = new List<Currency>();
            List.Add(new Currency("Dolar Estadounidense (USD)", decimal.Parse(currencyList[0].ToString()), decimal.Parse(currencyList[1].ToString())));
            List.Add(new Currency("Dolar Canadiense (CAD)", decimal.Parse(currencyList[4].ToString()), decimal.Parse(currencyList[5].ToString())));
            List.Add(new Currency("Euro (EUR)", decimal.Parse(currencyList[6].ToString()), decimal.Parse(currencyList[7].ToString())));
            return List;
        }

        private async Task<string[]> RequestPage()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDoc = await htmlWeb.LoadFromWebAsync(_sectionUrlPage.SkotiaBank);
            var regs = htmlDoc.DocumentNode.SelectSingleNode(@"(//table[@class='bns--table'])[last()]");
            var currencyList = regs.InnerText
                .Replace("Pais o Zona Monetaria", "")
                .Replace("Divisa", "")
                .Replace("Compra", "")
                .Replace("Venta", "")
                .Replace("Estados Unidos", "")
                .Replace("Canadá", "")
                .Replace("Europa", "")
                .Replace("Dólar (USD) Sucursales", "")
                .Replace("Dólar (USD) Canales Digitales*", "")
                .Replace("Dólar Canadiense (CAD)", "")
                .Replace("Euro (EUR)", "")
                .Replace("\n", ";")
                .Replace(";;;;;", ";")
                .Replace(";;;;", ";")
                .Replace(";;;", ";")
                .Replace(";;", "")
                .Split(";");

            return currencyList;
        }
    }
}
