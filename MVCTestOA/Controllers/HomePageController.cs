using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace MVCTestOA.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage

        BQuestion bquestion = new BQuestion();

        #region 首页
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 分页显示数据
        //分页显示数据
        public ActionResult Question(string start, string end)
        {
            
            if ((start == null) || end == null)
            {
                int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageindex"]) : 1;
                int pageSize = 5; //每个页面两条数据
                int pagecount = bquestion.GetPages(pageSize);
                pageIndex = pageIndex < 1 ? 1 : pageIndex;
                pageIndex = pageIndex > pagecount ? pagecount : pageIndex;

                List<Question> list = bquestion.GetPageList(pageIndex, pageSize);  //获取分页数据

                ViewData["list"] = list;
                ViewData["pageIndex"] = pageIndex;
                ViewData["pageCount"] = pagecount;
                Session["time"] = 0;

                int count = bquestion.GetQuestionCount();//得到问题的个数    
                ViewData["count"] = count;
                return View();
            }
            else
            {
                List<Question> list = bquestion.GetPageByTime(start, end);
                //int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageindex"]) : 1;
                //int pageSize = 4; //每个页面两条数据
                //int pagecount = bquestion.GetCountAfterTime(list, pageSize);
                //pageIndex = pageIndex < 1 ? 1 : pageIndex;
                //pageIndex = pageIndex > pagecount ? pagecount : pageIndex;
                //List<Question> list2 = bquestion.GetPageAfterTime(list, pageIndex, pageSize);

                ViewData["list"] = list;
                ViewData["count"] = list.Count();
                ViewData["start"] = start;
                ViewData["end"] = end;
                Session["time"] = 1;
                return View();
            }
           
           
           
        }
        #endregion

        #region 新增问题界面
        public ActionResult AddQuestion()
        {
            return View();
        }
        #endregion

        #region 新增操作
        public ActionResult Add(string title, string content, string category)
        {
            Question newquestion = new Question
            {
                Ttile = title,
                Content = content,
                Category = category,
                Time = DateTime.Now.Date,
                Origin = "admin",
                VisitCount = 0
            };

          bool a=   bquestion.AddQuestion(newquestion);
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

        #region 删除多个操作
        public ActionResult DeleteList(string id)
        {
            string[] ids =id.Split('*');
            int a = 1;
            
            for (int i = 0; i < ids.Length-1; i++)
            {
                string x = ids[i];
                if(bquestion.Delete(x))
                {
                    a += 1;
                }
                else
                {
                    a+= 0;
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
            if (bquestion.DeleteId(id) == true)
            {
                return Content("OK");
            }
            else
            {
                return Content("NO");
            }
        }
        #endregion

        #region 编辑页面
        public ActionResult EditQuestion(string  id)
        {
            int ids =id==null?0: int.Parse( id);
            Question questions= bquestion.Select(ids);
            ViewData["list"] = questions;
            return View();
        }
        #endregion

        #region 更新数据
        public ActionResult Edit(int id,string title, string content, string category)
        {
            Question newquestion = new Question
            {
                Id = id,
                Ttile = title,
                Content = content,
                Category = category,
                Time = DateTime.Now.Date,                              
            };

            bool a = bquestion.Edit(newquestion);
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
    }
}