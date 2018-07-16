using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DAL
{
  public   class DMemberList
    {
        DbContext db = new TestOAEntities1();

        /// <summary>
        /// 得到用户数据集合
        /// </summary>
        /// <returns></returns>
        public List<User> GetAdministrators()
        {
            return db.Set<User>().Select(p => p).ToList();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            int ids = Convert.ToInt32(id);
            var query = db.Set<User>().Where(p => p.Id == ids).Select(p => p).SingleOrDefault();
            db.Set<User>().Remove(query);
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
            db.Set<User>().Remove(db.Set<User>().Where(p => p.Id == id).Select(p => p).SingleOrDefault());
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
        /// 根据ID进行数据的查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return db.Set<User>().Where(p => p.Id == id).SingleOrDefault();
        }
    }
}
