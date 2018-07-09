using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace MVCTestOA.Controllers
{
    public class CommentListController : Controller
    {
        // GET: CommentList
        BAnswer bAnswer = new BAnswer();
        public ActionResult Index()
        {
           
            List<Answer> list= bAnswer.GetAnswers();
            ViewData["list"] = list;
            ViewData["count"] = list.Count();
            return View();
        }

        #region 删除多个操作
        public ActionResult DeleteList(string id)
        {
            string[] ids = id.Split('*');
            int a = 1;

            for (int i = 0; i < ids.Length - 1; i++)
            {
                string x = ids[i];
                if (bAnswer.Delete(x))
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
        public ActionResult Delete(int id)
        {
            if (bAnswer.DeleteId(id) == true)
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }
        }
        #endregion

        #region 意见反馈界面
        public ActionResult Feedback()
        {
            List<Feedback> list = bAnswer.GetFeedbacks();
            ViewData["list"] = list;
            ViewData["count"] = list.Count();
            return View();

            
        }
        #endregion

        public ActionResult FeedbackDeleteList(string id)
        {
            string[] ids = id.Split('*');
            int a = 1;

            for (int i = 0; i < ids.Length - 1; i++)
            {
                string x = ids[i];
                if (bAnswer.FeedDelete(x))
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

        
        #region 单个删除
        public ActionResult FeedDelete(int id)
        {
            if (bAnswer.FeedDeleteId(id) == true)
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }
        }
        #endregion
    }
}