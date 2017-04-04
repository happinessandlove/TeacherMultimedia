using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private DbEntity db = new DbEntity();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
        
        [Route("All")]
        public IHttpActionResult GetAllBuilding()
        {
            /*User loginUser = db.Users.FirstOrDefault(s => s.Name == UserName);
            if (loginUser.Password != SecurityHelper.MD5Hash(PassWord)) return BadRequest("密码不正确");*/
            // List<Building> Buildings = db.Buildings.OrderBy(s=>s.Id).ToList();
            //var Buildings = db.Buildings.Select(s => new { Id = s.Id, Number = s.Number }).OrderBy(s => s.Id).ToList();
             return Json(db.Buildings.Select(s => new { Id = s.Id, Number = s.Number }).OrderBy(s => s.Id).ToList());
            //return Json<List<Building>>(Buildings);
        }

        // GET api/values/5
        //[Route("GetOne")]
        public IHttpActionResult GetOne(Guid Id)
        {   
            var building = db.Buildings.Where(s => s.Id==Id).ToList();
            return Json(building.Select(s=>new { Id = s.Id, Number = s.Number }).ToList());
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [Route("PutOne")]
        public IHttpActionResult PutOne(Building b)
        {
            Building s = db.Buildings.FirstOrDefault(t=>t.Id==b.Id);
            s.Number = b.Number;
            db.Entry(s).State = EntityState.Modified;
            try
            {
            db.SaveChanges();
            }
            catch
            {
                db.Entry(s).State = EntityState.Unchanged;
                return BadRequest("操作发生错误");
            }
            return Json("ok");
        }

        [Route("PostOne")]
        public IHttpActionResult PostOne(Building b)
        {
            try
            { 
            b.Id = Guid.NewGuid();
            db.Buildings.Add(b);
            db.Entry(b).State = EntityState.Added;
            db.SaveChanges();
            }

            catch
            {
                return BadRequest("提交错误！");
            }
            return Json("ok");
        }

        // DELETE api/values/5
        [Route("DeleteOne")]
        public IHttpActionResult Delete(Guid id)
        {
            Building b = db.Buildings.FirstOrDefault(s=>s.Id==id);
            if (b == null) return BadRequest("不存在！！");
            try
            { 
            db.Buildings.Remove(b);
                db.SaveChanges();
            }
            catch
            {
                return BadRequest("删除错误，请检查数据！！");
            }

            return Json("ok");
        }
    }
}
