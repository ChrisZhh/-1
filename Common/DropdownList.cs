using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Web.Mvc;


namespace Common
{
    /// <summary>
    /// 生成下拉列表
    /// </summary>
   public  class DropdownList
    {
        #region 生成下拉列表
        DbContext db = new TestOAEntities1();
        List<SelectListItem> s = new List<SelectListItem>();
        string jgf = "";

        /// <summary>
        /// 生成下拉列表
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        public List<SelectListItem> Get_nav(int nid)
        {
            jgf = "";
            var parent = db.Set<Category>().Where(p => p.Pid == nid).ToList();

            if (parent != null)
            {
                foreach (var a in parent)
                {
                    string codes = a.Code.ToString();
                    for (int i = 1; i < codes.Length; i++)
                    {
                        jgf += "—";
                    }
                    var selectlistparent = new SelectListItem
                    {
                        Text = jgf + a.CategoryName,
                        Value = a.CategoryName
                    };
                    s.Add(selectlistparent);
                    var oneson = db.Set<Category>().Where(p => p.Pid == a.Id).ToList();

                    if (oneson != null)
                    {
                        Get_nav(a.Id);
                    }
                }
            }
            return s;
        }
        #endregion


    }
}
