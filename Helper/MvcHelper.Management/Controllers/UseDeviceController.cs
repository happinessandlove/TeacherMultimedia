﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcHelper.Management.Controllers
{
    public class UseDeviceController : Controller
    {
        private DbEntity db = new DbEntity();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        // GET: UseDevice
        public ActionResult Index()
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

            string data = "44532D4F4D50010201000400222.192.58.63";

            byte[] sendBytes = Encoding.UTF8.GetBytes(data);
            byte[] recvBytes = new byte[1024];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);// Stream
            try
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse("222.192.32.80"), 17001));
                socket.Send(sendBytes, sendBytes.Length, SocketFlags.None);
                int recvLength = socket.Receive(recvBytes, recvBytes.Length, SocketFlags.None);
                string receive = Encoding.UTF8.GetString(recvBytes, 0, recvLength);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Disconnect(false);
                socket.Close();
                socket.Dispose();
            }
            
            var buildings = from s in db.Buildings
                         
                            select s;
            return View(buildings);

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
