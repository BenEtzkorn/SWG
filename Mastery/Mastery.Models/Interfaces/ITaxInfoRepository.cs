using System.Collections.Generic;

namespace Mastery.Models.Interfaces
{
    public interface ITaxInfoRepository
    {
        List<TaxInfo> GetAll();

        decimal GetTaxRate(string State);

        string GetStateList();

        bool CheckState(string State);
    }
}
