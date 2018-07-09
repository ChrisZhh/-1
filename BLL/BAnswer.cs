using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
  public  class BAnswer
    {
        DbContext db = new TestOAEntities1();
        DAnswer dAnswer = new DAnswer();

        /// <summary>
        /// 进行查询
        /// </summary>
        /// <returns></returns>
        public List<Answer> GetAnswers()
        {
            return dAnswer.GetAnswers();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return dAnswer.Delete(id);
        }

        /// <summary>
        /// 删除单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteId(int id)
        {
            return dAnswer.DeleteId(id);
        }

        /// <summary>
        /// 得到反馈列表的数据
        /// </summary>
        /// <returns></returns>
        public List<Feedback> GetFeedbacks()
        {
            return dAnswer.GetFeedbacks();
        }

        /// <summary>
        /// 进行反馈列表的批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FeedDelete(string id)
        {
            return dAnswer.FeedDelete(id);
        }

        /// <summary>
        /// 进行单个意见反馈的删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FeedDeleteId(int id)
        {
            return dAnswer.FeedDeleteId(id);
        }
    }
}
