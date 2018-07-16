using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class AdminsatorController : ApiController
    {
        DbContext db = new TestOAEntities1();

        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns></returns>
        
       

        public IEnumerable<Administrator> GetAll()
        {
            return db.Set<Administrator>().Select(p => p);
        }

        [HttpGet]
        public string Update(int id)
        {
            var query = db.Set<Administrator>().Where(p => p.Id == id).SingleOrDefault();
            if (query.State == true)
            {
                query.State = false;
                db.SaveChanges();
                return "已停用";
            }
            else
            {
                query.State = true;
                db.SaveChanges();
                return "已起用";
            }

          
        }
    }
}
