using Mastery.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Mastery.Models;
using System.IO;

namespace Mastery.Data
{
    public class TaxFileRepository : ITaxInfoRepository
    {
        private string _State;
        private decimal _TaxRate;
        private string _StateList;

        public List<TaxInfo> GetAll()
        {
            List<TaxInfo> TaxData = new List<TaxInfo>();

            string[] lines = File.ReadAllLines(@"C:\Data\Mastery\Taxes.txt");

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');

                TaxData.Add(new TaxInfo()
                {
                    StateAbbreviation = columns[0],
                    StateName = columns[1],
                    TaxRate = decimal.Parse(columns[2])
                });
            }

            return TaxData;

        }//Load tax file into a list

        public decimal GetTaxRate(string State) //Get the tax rate for the state
        {
            _State = State;

            List<TaxInfo> TaxData = new List<TaxInfo>();

            List<TaxInfo> TempTax = GetAll();

            var StateList = TempTax.FirstOrDefault(t => t.StateAbbreviation == _State);

            _TaxRate = StateList.TaxRate;

            return _TaxRate;
        }

        public string GetStateList() //This gets a list of all states in the tax file
        {

            using (StreamReader sr = new StreamReader(Settings.TaxFilePath))
            {
                sr.ReadLine();

                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    string[] columns = line.Split(',');

                    string temp = columns[0];

                    _StateList = _StateList + temp + ", ";

                }

                _StateList = _StateList.Remove(_StateList.Length - 4);

                return _StateList;
            }

        }

        public bool CheckState(string _State) //This code checks the entered state against the tax file.
        {

            using (StreamReader sr = new StreamReader(Settings.TaxFilePath))
            {
                string contents = sr.ReadToEnd();
                if (contents.Contains(_State))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
