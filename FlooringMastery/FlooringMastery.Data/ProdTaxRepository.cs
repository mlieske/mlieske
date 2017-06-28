using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class ProdTaxRepository : ITaxRepository
    {
        List<TaxesByState> taxes = new List<TaxesByState>();
        LoadTaxFileResponse response = new LoadTaxFileResponse();
        string path = @"C:\sgbitbucket\michele-lieske-individual-work\flooringmastery\taxes.txt";

        public LoadTaxFileResponse LoadTaxes()
        {
            string[] rows = File.ReadAllLines(path);

            for (int i = 1; i < rows.Length; i++) //skips header row
            {
                string[] columns = rows[i].Split(',');
                TaxesByState t = new TaxesByState();

                t.StateAbbreviation = columns[0];
                t.StateName = columns[1];
                t.TaxRate = decimal.Parse(columns[2]);

                taxes.Add(t);
            }
            if (taxes.Count() != 0)
            {
                response.Success = true;
                response.TaxList = taxes;
            }
            else
            {
                response.Success = false;
                response.Message = "No tax information was loaded";
            }
            return response;
        }
    }
}
