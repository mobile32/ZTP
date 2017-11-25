using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Implementations
{
    public class GusAnalyzer : IGusAnalyzer
    {
        private readonly ITERCAnalyzer _tercAnalyzer;
        private readonly ISIMCAnalyzer _simcAnalyzer;
        private readonly IULICAnalyzer _ulicAnalyzer;

        public GusAnalyzer(ITERCAnalyzer tercAnalyzer, ISIMCAnalyzer simcAnalyzer, IULICAnalyzer ulicAnalyzer)
        {
            _tercAnalyzer = tercAnalyzer;
            _simcAnalyzer = simcAnalyzer;
            _ulicAnalyzer = ulicAnalyzer;
        }

        public GUSData GetData(string tercPath, string simcPath, string ulicPath)
        {
            var data = new GUSData();
            var terc = _tercAnalyzer.GetData(tercPath);
            data.Locations = GetLocations(simcPath);
            data.Boroughs = terc.Boroughs.ToList();
            data.Townships = terc.Townships.ToList();
            data.Voivodeships = terc.Voivodeships.ToList();
            return data;
        }

        public ICollection<Location> GetLocations(string simcPath)
        {
            return _simcAnalyzer.GetLocations(simcPath).ToList();
        }

        public ICollection<Borough> GetBoroughs(string tercPath)
        {
            return _tercAnalyzer.GetBoroughs(tercPath).ToList();
        }

        public ICollection<Township> GetTownships(string tercPath)
        {
            return _tercAnalyzer.GetTownships(tercPath).ToList();
        }

        public ICollection<Voivodeship> GetVoivodeships(string tercPath)
        {
            return _tercAnalyzer.GetVoivodeships(tercPath).ToList();
        }
    }
}