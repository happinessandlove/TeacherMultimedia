using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcHelper.Management.Controllers
{
    public class UseDeviceController : Controller
    {
        private DbEntity db = new DbEntity();
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
        // GET: UseDevice
        public ActionResult Index(OperationParam op)
        {
            #region 验证登录
            User loginUser = AccountHelper.LoginUser;
            if (loginUser == null) return RedirectToAction("Login", "Home", new { area = "" });
            ViewBag.LoginUser = loginUser;
            #endregion

            #region 验证权限
            string pageId = "Index_UseDevice"; //站点目录中的id属性值
            if (!Access.Validate(pageId)) return HttpNotFound();
            ViewBag.PageId = pageId;
            #endregion

            IQueryable<Building> datas = QueryHelper.ExecuteQuery(db.Buildings, op.OpQueryString); //执行前台查询条件（延迟）。若有附加条件，后续添加.Where()子句 
            if (string.IsNullOrEmpty(op.OpSortProperty)) { op.OpSortProperty = "Number"; op.OpSortDirection = SortDirection.Ascending; }
            IList<Building> devices = datas
                .Include(s => s.Classrooms)//Include所有需要的导航属性和导航集合（含多级导航），一次性查询数据库 <需修改>
                .Sort(op.OpSortProperty, op.OpSortDirection) //排序
                .ToList(); //执行查询
            return View(devices);
        }

        // GET: UseDevice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UseDevice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UseDevice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UseDevice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UseDevice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UseDevice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UseDevice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
