using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using MiDominicanaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiDominicanaApi.Services
{
    public class FuelsService : IFuelsService
    {
        private readonly SectionUrlPage _sectionUrlPage;

        public FuelsService(IOptions<SectionUrlPage> sectionUrlPage)
        {
            this._sectionUrlPage = sectionUrlPage.Value;
        }

        public async Task<Fuels> GetFuels()
        {
            Fuels fuel = new Fuels();
            var fuelPriceList = await RequestPage();
            fuel.GasolinaPremium = fuelPriceList[(int)EnumFuel.GasolinaPremium];
            fuel.GasolinaRegular = fuelPriceList[(int)EnumFuel.GasolinaRegular];
            fuel.GasoilOptimo = fuelPriceList[(int)EnumFuel.GasoilOptimo];
            fuel.GasoilRegular = fuelPriceList[(int)EnumFuel.GasoilRegular];
            fuel.Kerosene = fuelPriceList[(int)EnumFuel.Kerosene];
            fuel.GasLicuadoPetroleoGLP = fuelPriceList[(int)EnumFuel.GasLicuadoPetroleoGLP];
            fuel.GasNaturalVehicularGNV = fuelPriceList[(int)EnumFuel.GasNaturalVehicularGNV];
            return fuel;
        }


        private async Task<string[]> RequestPage()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument htmlDoc = htmlWeb
                .Load(this._sectionUrlPage.Micm);
            var regs = htmlDoc.DocumentNode
                .SelectSingleNode(@"(//table[@class='art-data-table art-data-table-condensed'])[last()]");

            var fuelList = regs.InnerText
              .Replace("CombustiblesPreciosGasolina PremiumRD$ ", "")
              .Replace("Gasolina RegularRD$ ", ";")
              .Replace("Gasoil ÓptimoRD$ ", ";")
              .Replace("Gasoil RegularRD$ ", ";")
              .Replace("KeroseneRD$ ", ";")
              .Replace("Gas Licuado de Petróleo (GLP)RD$ ", ";")
              .Replace("Gas Natural Vehicular (GNV)RD$ ", ";").Split(";");

            return fuelList;

        }
    }

    public enum EnumFuel
    {
        GasolinaPremium,
        GasolinaRegular,
        GasoilOptimo,
        GasoilRegular,
        Kerosene,
        GasLicuadoPetroleoGLP,
        GasNaturalVehicularGNV
    }
}
