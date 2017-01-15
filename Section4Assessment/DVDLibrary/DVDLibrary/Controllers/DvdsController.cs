using DvdLibrary.Data.ADO;
using DvdLibrary.Data.Interfaces;
using DvdLibrary.Data.Mock;
using DvdLibrary.Models.Tables;
using DvDLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvDLibrary.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdsController : ApiController
    {

       public IDvdsRepository GetMode()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            if(mode == "ADO")
            {
                ADORepository repo = new ADORepository();
                return repo;
            }

            else if (mode == "EF")
            {
                ADORepository repo = new ADORepository();
                return repo;
            }

            else
            {
                MockRepository repo = new MockRepository();
                return repo;
            }

        }
           
        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvds()
        {

            IDvdsRepository repo = GetMode();

            List<Dvds> List = repo.GetDvds();

            return Ok(List);
           
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdTitle(string title)
        {


            IDvdsRepository repo = GetMode();

            List<Dvds> List = repo.GetDvdsTitle(title);

            return Ok(List);
        }

        [Route("dvds/year/{Year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsearchYear(string Year)
        {
            IDvdsRepository repo = GetMode();

            List<Dvds> List = repo.GetDvdsYear(Year);

            return Ok(List);
        }

        [Route("dvds/director/{Director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdDirector(string Director)
        {
            IDvdsRepository repo = GetMode();

            List<Dvds> List = repo.GetDvdsDirector(Director);

            return Ok(List);
        }

        [Route("dvds/rating/{Rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdRating(string Rating)
        {
            IDvdsRepository repo = GetMode();

            List<Dvds> List = repo.GetDvdsRating(Rating);

            return Ok(List);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult deleteDVD(int dvdId)
        {
            IDvdsRepository repo = GetMode(); ;

            repo.DeleteDvdId(dvdId);

            return Ok();

        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult displayDVD(int dvdId)
        {
            IDvdsRepository repo = GetMode();

            Dvds dvd = repo.GetDvdId(dvdId);

            return Ok(dvd);

        }

        [Route("dvd/{dvd}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult editDVDId(Dvds dvd)
        {
            IDvdsRepository repo = GetMode();

            repo.UpdateDvdId(dvd);

            Dvds newdvd = repo.GetDvdId(dvd.dvdId);

            return Ok(newdvd);

        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult insertDVD(Dvds dvd)
        {
            IDvdsRepository repo = GetMode();

            repo.PostDvd(dvd);

            Dvds newdvd = repo.GetDvdId(dvd.dvdId);

            return Ok(newdvd);
        }
    }                       
}
