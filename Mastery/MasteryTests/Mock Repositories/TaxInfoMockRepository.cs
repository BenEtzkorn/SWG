using Mastery.Models;
using Mastery.Models.Interfaces;
using System.Collections.Generic;
using System;

namespace MasteryTests
{
    public class TaxInfoMockRepository: ITaxInfoRepository
    {
        public bool CheckState(string State)
        {
            string _state = State;

            if (_state == "DC"|| _state == "IN" || _state == "MI" || _state == "MN" || _state == "OH" || _state == "PA")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<TaxInfo> GetAll()
        {
            return new List<TaxInfo>()
            {
                new TaxInfo {StateAbbreviation="OH",StateName="Ohio", TaxRate=10.0M }
            };
        }

        public string GetStateList()
        {
            return "DC, IN, MI, MN, OH, PA";
        }

        public decimal GetTaxRate(string State)
        {
            if (State == "OH")
            {
                return 10;
            }

            else
            {
                return 0;
            }
        }
    }
}
