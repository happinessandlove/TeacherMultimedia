using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Models;

namespace WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private DbEntity db = new DbEntity();



        [Route("Login")]
        public IHttpActionResult PostLogin(string UserName, string PassWord)
        {
            User user = db.Users.FirstOrDefault(s=>s.LoginName==UserName);
            if (user == null) return BadRequest("账号不存在！");
            if (user.Password != SecurityHelper.MD5Hash(PassWord)) return BadRequest("密码不正确！");
            return Json("ok");
        }
        [Route("Open")]
        public IHttpActionResult GetOpen(string BuildingNumber, string ClassRoomNumber)
        {
            Building building = db.Buildings.FirstOrDefault(s => s.Number == BuildingNumber);
            if (building == null) return BadRequest("请检查教学楼信息！！");
            ClassRoom classroom = db.ClassRooms.FirstOrDefault(s => s.Number == ClassRoomNumber);
            if (classroom == null) return BadRequest("请检查教室信息！！");
            return Json("ok");

        }
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(Guid id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}