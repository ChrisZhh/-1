using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DQuestion
    {
        DbContext db = new TestOAEntities1();

        /// <summary>
        /// 得到问题列表
        /// </summary>
        /// <returns></returns>
        public List<Question> GetQuestions()
        {
            var query = db.Set<Question>().Select(p => p).ToList();
            return query;
        }

        /// <summary>
        /// 得到问题的总条数
        /// </summary>
        /// <returns></returns>
        public int GetQuestionCount()
        {
            var query = db.Set<Question>().Count();
            return query;
        }

        /// <summary>
        /// 进行分页展示
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页问题的数量</param>
        /// <returns></returns>
        public List<Question> GetPageList(int pageIndex,int pageSize)
        {
            var query = db.Set<Question>()
                        .OrderBy(p=>p.Id)
                        .Select(p => p)
                        .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                        .ToList();
            return query;
        }

        /// <summary>
        /// 得到总的页数
        /// </summary>
        /// <param name="pageSize">每页的问题数量</param>
        /// <returns></returns>
        public int GetPages(int pageSize)
        {
            var query = db.Set<Question>().Count();
            var pagecount= (int)Math.Ceiling(query / (double)pageSize);
            return pagecount;
        }

        /// <summary>
        /// 得到按日期进行分类的结果
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns></returns>
        public List<Question> GetPageByTime(string startTime,string endTime)
        {
            DateTime start = DateTime.ParseExact(startTime,"yyyy-MM-dd",System.Globalization.CultureInfo.InstalledUICulture);
            DateTime end = DateTime.ParseExact(endTime, "yyyy-MM-dd", System.Globalization.CultureInfo.InstalledUICulture);
            var query = db.Set<Question>()
                      .Where(p => p.Time > start && p.Time < end)
                      .Select(p => p)
                      .ToList();
            return query;
        }

        /// <summary>
        /// 进行筛选之后的一个分页展示
        /// </summary>
        /// <param name="questions">筛选之后的数据集合</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Question> GetPageAfterTime(List<Question> questions,int pageIndex, int pageSize)
        {
            var query = questions.OrderBy(p => p.Id)
                      .Select(p => p)
                      .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                      .ToList();
            return query;
        }

        /// <summary>
        /// 得到数据筛选之后的数据总记录条数
        /// </summary>
        /// <param name="questions">筛选之后的数据集合</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetCountAfterTime(List<Question> questions,int pageSize)
        {
            var query = questions.Count();
            var count= (int)Math.Ceiling(query / (double)pageSize);
            return count;
        }

        /// <summary>
        /// 增加问题
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public bool AddQuestion(Question question)
        {
            db.Set<Question>().Add(question);
            bool a;
            if(db.SaveChanges()>0)
            {
                a = true;
            }
            else
            {
                a = false;
            }
            return a;
        }

        /// <summary>
        /// 进行删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            int ids = Convert.ToInt32(id);
            var query = db.Set<Question>().Where(p => p.Id == ids).Select(p => p).SingleOrDefault();
            db.Set<Question>().Remove(query);
           if(db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteId(int id)
        {
            db.Set<Question>().Remove(db.Set<Question>().Where(p => p.Id == id).Select(p => p).SingleOrDefault());
           if(db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据ID得到数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Question Select(int id)
        {
            var query = db.Set<Question>().Where(p => p.Id == id).Select(p => p).SingleOrDefault();
            return query;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public bool Edit(Question question)
        {
            int id = question.Id;
            var query = db.Set<Question>().Where(p => p.Id == id).SingleOrDefault();
            query.Category = question.Category;  //分类
            query.Content = question.Content;    //内容
                 
            query.Time = question.Time;           //时间
            query.Ttile = question.Ttile;         //题目
            
           if(db.SaveChanges() >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
