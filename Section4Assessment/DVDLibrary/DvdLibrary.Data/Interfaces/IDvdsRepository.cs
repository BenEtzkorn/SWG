using DvdLibrary.Models.Queries;
using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Interfaces
{
    public interface IDvdsRepository
    {
        Dvds GetDvdId(int dvdId);
        List<Dvds> GetDvds();
        List<Dvds> GetDvdsDirector(string director);
        List<Dvds> GetDvdsRating(string rating);
        List<Dvds> GetDvdsTitle(string title);
        List<Dvds> GetDvdsYear(string releaseYear);
        void PostDvd(Dvds dvd);
        void DeleteDvdId(int dvdId);
        void UpdateDvdId(Dvds dvd);
    }
}
