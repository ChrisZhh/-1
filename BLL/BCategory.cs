using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
   public  class BCategory
    {
        DCategory dCategory = new DCategory();

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Category> GetCategoriesList(int id)
        {
            return dCategory.GetCategoriesList(id);
        }

        /// <summary>
        /// 得到总记录数
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return dCategory.GetCount();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            return dCategory.Delete(id);
        }

        /// <summary>
        /// 删除单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteId(int id)
        {
            return dCategory.DeleteId(id);
        }

        /// <summary>
        /// 根据ID查数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetById(int id)
        {
            return dCategory.GetById(id);
        }

        /// <summary>
        /// 新增分类
        /// </summary>
        /// <param name="text"></param>
        /// <param name="mytext"></param>
        /// <returns></returns>
        public bool AddCate(string text, string mytext)
        {
            return dCategory.AddCate(text, mytext);
        }

        /// <summary>
        /// 修改分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="mytext"></param>
        /// <returns></returns>
        public bool UpdateCate(int id, string text, string mytext)
        {
            return dCategory.UpdateCate(id, text, mytext);
        }
    }
}
