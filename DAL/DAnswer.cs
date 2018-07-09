using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
  public   class DAnswer
    {
        DbContext db = new TestOAEntities1();

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <returns></returns>
        public List<Answer> GetAnswers()
        {
            var query = (from a in db.Set<Answer>()
                         select a)
                        .ToList();
            return query;
        }

        /// <summary>
        /// 进行删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            int ids = Convert.ToInt32(id);
            var query = db.Set<Answer>().Where(p => p.Id == ids).Select(p => p).SingleOrDefault();
            db.Set<Answer>().Remove(query);
            if (db.SaveChanges() > 0)
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
            db.Set<Answer>().Remove(db.Set<Answer>().Where(p => p.Id == id).Select(p => p).SingleOrDefault());
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 显示反馈列表的数据
        /// </summary>
        /// <returns></returns>
        public List<Feedback> GetFeedbacks()
        {
            var query = (from a in db.Set<Feedback>()
                         select a)
                        .ToList();
            return query;
        }

        
        /// <summary>
        /// 进行删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FeedDelete(string id)
        {
            int ids = Convert.ToInt32(id);
            var query = db.Set<Feedback>().Where(p => p.Id == ids).Select(p => p).SingleOrDefault();
            db.Set<Feedback>().Remove(query);
            if (db.SaveChanges() > 0)
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
        public bool FeedDeleteId(int id)
        {
            db.Set<Feedback>().Remove(db.Set<Feedback>().Where(p => p.Id == id).Select(p => p).SingleOrDefault());
            if (db.SaveChanges() > 0)
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
