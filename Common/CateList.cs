using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models;


namespace Common
{
   public  class CateList
    {
        DbContext db = new TestOAEntities1();
        List<Category> list = new List<Category>();

        /// <summary>
        /// 递归按照一定的顺序显示出数据
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        public List<Category> Get_nav(int nid)
        {
            var parent = db.Set<Category>().Where(p => p.Pid == nid).ToList();

            if (parent != null)
            {
                foreach (var a in parent)
                {
                    string codes = a.Code.ToString();

                    Category listson = a;
                    
                    list.Add(a);
                    var oneson = db.Set<Category>().Where(p => p.Pid == a.Id).ToList();

                    if (oneson != null)
                    {
                        Get_nav(a.Id);
                    }
                }
            }
            return list;
        }
    }
}
