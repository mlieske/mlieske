using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data
{
    public class TestTaxRepository : ITaxRepository
    {
        TaxesByState testState = new TaxesByState
        {
            StateAbbreviation = "MN",
            StateName = "Minnesota",
            TaxRate = 3.5M
        };

        List<TaxesByState> taxes = new List<TaxesByState>();
        LoadTaxFileResponse response = new LoadTaxFileResponse();

        public LoadTaxFileResponse LoadTaxes()
        {
            taxes.Add(testState);
            response.Success = true;
            response.TaxList = taxes;
            return response;

        }
    }
}
