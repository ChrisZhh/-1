using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Newtonsoft;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class TheSecondController : ApiController
    {
        DbContext db = new TestOAEntities1();
        private List<Answer> answers = new List<Answer>();
        public IEnumerable<Answer> GetAll()
        {
            return  db.Set<Answer>().Select(p=>p);
        }

        public IEnumerable<Answer>  GetById(int id)
        {
            var a = db.Set<Answer>().Where(p => p.Id == id).Select(p => p);
            return a;
        }

       
       


      
    }
}
