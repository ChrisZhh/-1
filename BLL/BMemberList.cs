using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
  public  class BMemberList
    {
        DbContext db = new TestOAEntities1();
        DMemberList dMemberList = new DMemberList();

        /// <summary>
        /// 得到用户数据集合
        /// </summary>
        /// <returns></returns>
        public List<User> GetAdministrators()
        {
            return dMemberList.GetAdministrators();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return dMemberList.Delete(id);
        }

        /// <summary>
        /// 删除单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteId(int id)
        {
            return dMemberList.DeleteId(id);
        }

        /// <summary>
        /// 根据ID进行查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return dMemberList.GetById(id);
        }
    }
}
