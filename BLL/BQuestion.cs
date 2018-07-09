using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
  public   class BQuestion
    {
        DQuestion question = new DQuestion();

        /// <summary>
        /// 得到问题列表
        /// </summary>
        /// <returns></returns>
        public List<Question> GetQuestions()
        {
            return question.GetQuestions();
        }

        /// <summary>
        /// 得到问题的总条数
        /// </summary>
        /// <returns></returns>
        public int GetQuestionCount()
        {
            return question.GetQuestionCount();
        }

        /// <summary>
        /// 得到总的页码数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetPages(int pageSize)
        {
            return question.GetPages(pageSize);
        }

        /// <summary>
        /// 分页展示
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Question> GetPageList(int pageIndex, int pageSize)
        {
            return question.GetPageList(pageIndex, pageSize);
        }

        /// <summary>
        /// 按照日期进行筛选
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<Question> GetPageByTime(string startTime, string endTime)
        {
            return question.GetPageByTime(startTime, endTime);
        }

        /// <summary>
        /// 进行数据筛选之后的页码展示
        /// </summary>
        /// <param name="questions">筛选之后的数据集合</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Question> GetPageAfterTime(List<Question> questions, int pageIndex, int pageSize)
        {
            return question.GetPageAfterTime(questions, pageIndex, pageSize);
        }

        /// <summary>
        /// 得到筛选之后的数据的总记录条数
        /// </summary>
        /// <param name="questions">筛选之后的数据</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetCountAfterTime(List<Question> questions, int pageSize)
        {
            return question.GetCountAfterTime(questions, pageSize);
        }

        /// <summary>
        /// 增加问题
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public bool AddQuestion(Question questions)
        {
            return question.AddQuestion(questions);
        }

        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return question.Delete(id);
        }

        /// <summary>
        /// 删除单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteId(int id)
        {
            return question.DeleteId(id);
        }

        /// <summary>
        /// 根据ID找数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Question Select(int id)
        {
            return question.Select(id);
        }

        public bool Edit(Question questions)
        {
            return question.Edit(questions);
        }
    }
}
