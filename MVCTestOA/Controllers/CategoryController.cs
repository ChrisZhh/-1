using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using BLL;

namespace MVCTestOA.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DbContext db = new TestOAEntities1();
        BCategory bCategory = new BCategory();

        #region 首页
        public ActionResult Index()
        {
            Common.DropdownList dropdown = new DropdownList();
            List<SelectListItem> ss = new List<SelectListItem>();
            ss.Add(new SelectListItem { Text = "顶级分类", Value = "顶级分类" });
            List<SelectListItem>    s =dropdown.Get_nav(0);
            ss.AddRange(s);
            ViewData["list"] = ss;

            List<Category> list= bCategory.GetCategoriesList(0);
            ViewData["dtable"] = list;
            ViewData["count"] = bCategory.GetCount();
            return View();
        }
        #endregion

        #region 删除单个数据
        public ActionResult DeleteId(int id)
        {
            string text = bCategory.Delete(id);
            return Content(text);
        }
        #endregion

        #region 编辑界面
        public ActionResult CateEdit(string id)
        {
            int ids = id == null ? 0 : int.Parse(id);
            Common.DropdownList drop = new DropdownList();
            List<SelectListItem> ss = new List<SelectListItem>();
            ss.Add(new SelectListItem { Text = "顶级分类", Value = "顶级分类" });
            List<SelectListItem> s = drop.Get_nav(0);
            ss.AddRange(s);
            ViewData["selectlist"] = ss;

            Category a=  bCategory.GetById(ids);
            ViewData["CateE"] = a;

            return View();
        }
        #endregion

        #region 新增分类
        public ActionResult AddCategory(string text,string mytext)
        {
            bool a = bCategory.AddCate(text, mytext);
            if (a == true)
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }
            
        }
        #endregion

        public ActionResult Update(int id,string text,string mytext)
        {
            bool a = bCategory.UpdateCate(id, text, mytext);
            if (a == true)
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }
        }
    }
}