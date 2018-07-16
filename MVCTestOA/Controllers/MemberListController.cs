using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVCTestOA.Controllers
{
    public class MemberListController : Controller
    {
        // GET: MemberList
        BMemberList bMemberList = new BMemberList();

        #region 页面加载
        public ActionResult Index()
        {
            List<User> user = bMemberList.GetAdministrators();
            ViewData["list"] = user;
            ViewData["count"] = user.Count();

            return View();
        }
        #endregion

        #region 批量删除
        public ActionResult DeleteList(string id)
        {
            string[] ids = id.Split('*');
            int a = 1;

            for (int i = 0; i < ids.Length - 1; i++)
            {
                string x = ids[i];
                if (bMemberList.Delete(x))
                {
                    a += 1;
                }
                else
                {
                    a += 0;
                }
            }
            if (a == 1 * (ids.Length))
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }
        }
        #endregion

        #region 单个删除
        public ActionResult DeleteId(int id)
        {
            if (bMemberList.DeleteId(id) == true)
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }
        }
        #endregion

        #region 用户页面显示
        public ActionResult MemberShow(int id)
        {
            User user = new User();
            user = bMemberList.GetById(id);
            ViewData["user"] = user;
            return View();
        }
        #endregion

        #region 编辑页面
        public ActionResult MemberEdit(int id)
        {
            User user = new User();
            user = bMemberList.GetById(id);
            ViewData["user"] = user;
            return View();
        }
        #endregion

        #region 修改密码
        public ActionResult MemberPassword(int id)
        {
            User user = new User();
            user = bMemberList.GetById(id);
            ViewData["user"] = user;
            return View();
        }
        #endregion

        #region 新增用户界面
        public ActionResult MemberAdd()
        {
            return View();
        }
        #endregion
    }
}