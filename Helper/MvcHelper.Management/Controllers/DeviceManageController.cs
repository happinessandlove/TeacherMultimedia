﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Models;

namespace MvcHelper.Management.Controllers
{
    public class DeviceManageController : Controller
    {
        private DbEntity db = new DbEntity();
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }

        #region 列表
        public ActionResult Index(OperationParam op)
        {
            #region 验证登录
            User loginUser = AccountHelper.LoginUser;
            if (loginUser == null) return RedirectToAction("Login", "Home", new { area = "" });
            ViewBag.LoginUser = loginUser;
            #endregion

            #region 验证权限
            string pageId = "Index_Device"; //站点目录中的id属性值
            if (!Access.Validate(pageId)) return HttpNotFound();
            ViewBag.PageId = pageId;
            #endregion

            #region 翻页、查询、排序、显示全部、移动、删除
            ReturnValue returnValue = new ReturnValue();
            Device deleteData = null;
            switch (op.OpType)
            {
                case OperationType.Pager: break;
                case OperationType.Query: break;
                case OperationType.Sort: break;
                case OperationType.ShowAll: break;
                case OperationType.RankUp: break;
                case OperationType.Delete:
                    deleteData = db.Devices.Find(Guid.Parse(op.OpArgument));
                    if (deleteData == null)
                    {
                        returnValue.Type = ReturnType.DeleteFailure;
                        returnValue.Message = ResultMessage.DeleteFailure;
                    }
                    else
                    {
						try
						{
							db.Devices.Remove(deleteData);
							db.SaveChanges();
							returnValue.Type = ReturnType.DeleteSuccess;
							returnValue.Message = ResultMessage.DeleteSuccess;
						}
						catch
						{
                            db.Entry(deleteData).State = EntityState.Unchanged;
							returnValue.Type = ReturnType.DeleteFailure;
							returnValue.Message = ResultMessage.DeleteFailure;
						}
                    }
                    OperationParam.Reset(ModelState);
                    break;
                case OperationType.Deletes:
                    string[] ids = op.OpArgument.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
					bool success = true;
                    foreach (string id in ids)
                    {
                        deleteData = db.Devices.Find(Guid.Parse(id));
                        if (deleteData == null) continue;
                        else db.Devices.Remove(deleteData);
						try
						{
							db.SaveChanges();
						}
						catch
						{
							db.Entry(deleteData).State = EntityState.Unchanged;
							success = false;
						}
                    }
                    if (success)
                    {
                        returnValue.Type = ReturnType.DeletesSuccess;
                        returnValue.Message = ResultMessage.DeletesSuccess;
                    }
                    else
                    {
                        returnValue.Type = ReturnType.DeletesFailure;
                        returnValue.Message = ResultMessage.DeletesFailure;
                    }
                    OperationParam.Reset(ModelState);
                    break;
            }
            #endregion

            IQueryable<Device> datas = QueryHelper.ExecuteQuery(db.Devices, op.OpQueryString); //执行前台查询条件（延迟）。若有附加条件，后续添加.Where()子句
            Pager pager = new Pager(datas.Count(), op.OpPager, null); //页码相关对象
            ViewBag.Pager = pager;
            if (string.IsNullOrEmpty(op.OpSortProperty)) { op.OpSortProperty = "AddTime"; op.OpSortDirection = SortDirection.Descending; }//首次打开页面的初始排序依据及方向 <需修改>
            IList<Device> devices = datas
				.Include(s => s.ClassRoom) //Include所有需要的导航属性和导航集合（含多级导航），一次性查询数据库 <需修改>
				.Sort(op.OpSortProperty, op.OpSortDirection) //排序
				.GetPageData(pager) //选择当前页的数据
				.ToList(); //执行查询
            ViewBag.OperationParam = op;
            ViewBag.ReturnValue = returnValue.ToJson();
            return View(devices);
        }
        #endregion		

        #region 详情
        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            #region 验证登录
            User loginUser = AccountHelper.LoginUser;
            if (loginUser == null) return RedirectToAction("Login", "Home", new { area = "" });
            ViewBag.LoginUser = loginUser;
            #endregion

            #region 验证权限
            string pageId = "Details_Device"; //站点目录中的id属性值
            if (!Access.Validate(pageId)) return HttpNotFound();
            ViewBag.PageId = pageId;
            #endregion

			if(id == null) return HttpNotFound();
            Device device = db.Devices.Include(s => s.ClassRoom).FirstOrDefault(s => s.ClassRoomId == id); //Include所有需要的导航属性和导航集合（含多级导航），一次性查询数据库 <需修改>
            if (device == null) return HttpNotFound();
            return View(device);
        }
        #endregion

        #region 添加
        [HttpGet]
        public ActionResult Create()
        {
            #region 验证登录
            User loginUser = AccountHelper.LoginUser;
            if (loginUser == null) return RedirectToAction("Login", "Home", new { area = "" });
            ViewBag.LoginUser = loginUser;
            #endregion

            #region 验证权限
            string pageId = "Create_Device"; //站点目录中的id属性值
            if (!Access.Validate(pageId)) return HttpNotFound();
            ViewBag.PageId = pageId;
            #endregion

			#region 其余ViewBag数据绑定
			#endregion

            return View();
        }

		//防止“过多发布”攻击，启用指定绑定到特定属性的功能
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassRoomId,Number,AddTime,AddName,State,Remark")] Device device)
        {
            #region 验证登录
            User loginUser = AccountHelper.LoginUser;
            if (loginUser == null) return RedirectToAction("Login", "Home", new { area = "" });
            ViewBag.LoginUser = loginUser;
            #endregion

            #region 验证权限
            string pageId = "Create_Device"; //站点目录中的id属性值
            if (!Access.Validate(pageId)) return HttpNotFound();
            ViewBag.PageId = pageId;
            #endregion

			#region 无论添加是否成功，页面显示所需的其余ViewBag数据绑定
			#endregion

            #region 添加
            ReturnValue returnValue = new ReturnValue();
            if (ModelState.IsValid)
            {
                #region 特殊数据验证 <不需要验证则注释或删除>
              
                #endregion
                try
                {
                    device.ClassRoomId = Guid.NewGuid();
                    db.Devices.Add(device);
                    db.SaveChanges();
                    ModelState.Clear();
                    returnValue.Type = ReturnType.CreateSuccess;
                    returnValue.Message = ResultMessage.CreateSuccess;
                    ViewBag.ReturnValue = returnValue.ToJson();
                    return View();
                }
                catch
                {
                    returnValue.Type = ReturnType.CreateFailure;
                    returnValue.Message = ResultMessage.CreateFailure;
                    ViewBag.ReturnValue = returnValue.ToJson();
                    return View(device);
                }
            }
            #endregion

            ViewBag.ReturnValue = returnValue.ToJson();
            return View(device);
        }
        #endregion

        #region 编辑
        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            #region 验证登录
            User loginUser = AccountHelper.LoginUser;
            if (loginUser == null) return RedirectToAction("Login", "Home", new { area = "" });
            ViewBag.LoginUser = loginUser;
            #endregion

            #region 验证权限
            string pageId = "Edit_Device"; //站点目录中的id属性值
            if (!Access.Validate(pageId)) return HttpNotFound();
            ViewBag.PageId = pageId;
            #endregion
			
			#region 其余ViewBag数据绑定
			#endregion
			
			if(id == null) return HttpNotFound();
            Device device = db.Devices.Include(s => s.ClassRoom).FirstOrDefault(s => s.ClassRoomId == id); //Include所有需要的导航属性和导航集合（含多级导航），一次性查询数据库 <需修改>
            if (device == null) return HttpNotFound();
            return View(device);
        }
		
		//防止“过多发布”攻击，启用指定绑定到特定属性的功能
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassRoomId,Number,AddTime,AddName,State,Remark")] Device device)
        {
            #region 验证登录
            User loginUser = AccountHelper.LoginUser;
            if (loginUser == null) return RedirectToAction("Login", "Home", new { area = "" });
            ViewBag.LoginUser = loginUser;
            #endregion

            #region 验证权限
            string pageId = "Edit_Device"; //站点目录中的id属性值
            if (!Access.Validate(pageId)) return HttpNotFound();
            ViewBag.PageId = pageId;
            #endregion
			
			#region 无论编辑是否成功，页面显示所需的其余ViewBag数据绑定
			#endregion

            ReturnValue returnValue = new ReturnValue();
            #region 编辑
            if (ModelState.IsValid)
            {
                #region 特殊数据验证 <不需要验证则注释或删除>
                
                #endregion
                try
                {
                    db.Entry(device).State = EntityState.Modified;
                    db.SaveChanges();
                    returnValue.Type = ReturnType.EditSuccess;
                    returnValue.Message = ResultMessage.EditSuccess;
                }
                catch
                {
                    db.Entry(device).State = EntityState.Unchanged;
                    returnValue.Type = ReturnType.EditFailure;
                    returnValue.Message = ResultMessage.EditFailure;
                }
            }
            #endregion
			
            //针对需要显示导航属性的情形，重新查询数据库
            //device = db.Devices.Include(s => s.ClassRoom).FirstOrDefault(s => s.ClassRoomId == device.ClassRoomId); //Include所有需要的导航属性和导航集合（含多级导航），一次性查询数据库 <需修改>

            ViewBag.ReturnValue = returnValue.ToJson();
            return View(device);
        }
        #endregion

        #region ajax获取或验证某些数据
		//	[HttpGet]
		//	public JsonResult CheckXxxx(string value)
		//	{
		//		ReturnValue returnValue = new ReturnValue();
		//		int count = db.Devices.Where(s => s.Name == value).Count();
		//		if (count == 0)
		//		{
		//			returnValue.Type = ReturnType.Success;
		//			returnValue.Message = ResultMessage.EditSuccess;
		//		}
		//		else
		//		{
		//			returnValue.Type = ReturnType.Failure;
		//			returnValue.Message = "该xxxx已存在";
		//		}
		//		return Json(returnValue, JsonRequestBehavior.AllowGet);
		//	}
		//
		//	[HttpGet]
		//	public JsonResult GetXxxx(param)
		//	{
		//		var data = db.xxx.Where(s => s.xxx == param);
		//		return Json(data, JsonRequestBehavior.AllowGet);
		//	}
        #endregion
	}
}

