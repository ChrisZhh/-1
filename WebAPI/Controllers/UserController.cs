using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Models;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        DbContext db = new TestOAEntities1();

        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return db.Set<User>().Select(p => p);
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string Update(int id)
        {
            var query = db.Set<User>().Where(p => p.Id == id).SingleOrDefault();
            if (query.State == true)
            {
                query.State = false;
                db.SaveChanges();
                return "已停用";
            }
            else
            {
                query.State = true;
                db.SaveChanges();
                return "已起用";
            }


        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="city"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        [HttpGet]
        public string UpdateInfo
            ([FromUri]int id, string name,string sex,string email,string city,string sign)
        {

            var query = db.Set<User>().Where(p => p.Id == id).SingleOrDefault();
            query.Name = name;
            query.Sex = sex;
            query.Email = email;
            query.Address = city;
            query.Autograph = sign;
           if(db.SaveChanges() > 0)
            {
                return "OK";
            }
            else
            {
                return "NO";
            }           
        }

        #region 判断原密码对不对
        [HttpGet]
        public string CheckOldpass(int id ,string oldpass)
        {
            var query = db.Set<User>().Where(p => p.Id == id).SingleOrDefault();
            if (query.Pwd == oldpass)
            {
                return "OK";
            }
            else
            {
                return "NO";
            }
        }
        #endregion

        #region 修改原密码
        [HttpGet]
        public string UpdatePassword(int id ,string newpass)
        {
            var query = db.Set<User>().Where(p => p.Id == id).SingleOrDefault();
            query.Pwd = newpass;
            if (db.SaveChanges() > 0)
            {
                return "OK";
            }
            else
            {
                return "NO";
            }
        }
        #endregion

        #region 新增用户
        [HttpGet]
        public string UserAdd(string email,string name,string pwd)
        {
            var query = db.Set<User>().Where(p => p.Email == email).SingleOrDefault();
            if (query == null)
            {
                Models.User user = new User
                {
                    Email = email,
                    Name = name,
                    Pwd = pwd,
                    Time = Convert.ToDateTime(DateTime.Now.ToString())
                };

                db.Set<User>().Add(user);
                if (db.SaveChanges() > 0)
                {
                    return "OK";
                }
                else
                {
                    return "NO";
                }
            }
            else
            {
                return "邮箱地址重复";
            }
        }
        #endregion
    }

}

