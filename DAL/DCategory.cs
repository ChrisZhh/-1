using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Common;
using System.Web.Mvc;

namespace DAL
{
   public   class DCategory
    {
        DbContext db = new TestOAEntities1();

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Category> GetCategoriesList(int id)
        {
            Common.CateList cateList = new CateList();
            List<Category> query=new List<Category>();
           
            query=  cateList.Get_nav(id);

            return query;
        }

        /// <summary>
        /// 得到总记录数目
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int count = db.Set<Category>().Count();
            return count;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int  id)
        {
            
            var query = db.Set<Category>().Where(p => p.Id == id).Select(p => p).SingleOrDefault();
            var querySon = db.Set<Category>().Where(p => p.Pid == query.Id).FirstOrDefault();
            if (querySon != null)
            {
                return "该类下面有子类，不允许删除";
            }
            else
            {
                db.Set<Category>().Remove(query);
                if (db.SaveChanges() > 0)
                {
                    return "删除成功";
                }
                else
                {
                    return "删除失败";
                }
            }
           
        }

        /// <summary>
        /// 删除单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteId(int id)
        {
            db.Set<Category>().Remove(db.Set<Category>().Where(p => p.Id == id).Select(p => p).SingleOrDefault());
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
        /// 根据Id找到数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetById(int id)
        {
            var query = db.Set<Category>().Where(p => p.Id == id).Select(p => p).SingleOrDefault();
            return query;
        }

        /// <summary>
        /// 新增分类
        /// </summary>
        /// <param name="text">选中的下拉框的值</param>
        /// <param name="mytext">填写的值</param>
        /// <returns></returns>
        public bool AddCate(string text,string mytext)
        {
            if (text == "顶级分类")
            {
                Category category = new Category
                {
                    Pid = 0,
                    CategoryName = mytext,
                    Code = 1
                };
                db.Set<Category>().Add(category);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else {
                var parent = db.Set<Category>().Where(p => p.CategoryName == text).SingleOrDefault();
                string Pcode = parent.Code.ToString();

                Category category = new Category
                {
                    CategoryName = mytext,
                    Pid = parent.Id,
                    Code = Convert.ToInt32(Pcode.Insert(Pcode.Length, "1"))
                };
                db.Set<Category>().Add(category);
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

        /// <summary>
        /// 修改指定ID的分类
        /// </summary>
        /// <param name="id">指定ID</param>
        /// <param name="text">修改后的类名</param>
        /// <param name="mytext">目标类</param>
        /// <returns></returns>
        public bool UpdateCate(int id,string text,string mytext)
        {
            var query = db.Set<Category>().Where(p => p.Id == id).Select(p => p).FirstOrDefault();
            var Target = db.Set<Category>().Where(p => p.CategoryName == mytext).FirstOrDefault();
            string Pcode = Target.Code.ToString();
            query.Pid = Target.Id;
            query.Code = Convert.ToInt32(Pcode.Insert(Pcode.Length, "1"));
            query.CategoryName = text;
           
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
