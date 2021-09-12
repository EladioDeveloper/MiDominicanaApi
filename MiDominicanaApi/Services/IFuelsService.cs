using MiDominicanaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiDominicanaApi.Services
{
    public interface IFuelsService
    {
        Task<Fuels> GetFuels();
    }
}
