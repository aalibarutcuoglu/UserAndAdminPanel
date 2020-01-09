using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TelefonRehberi.Models.Entities;

namespace TelefonRehberi.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Server = ALI; Database = TelefonRehberi; Trusted_Connection = True";
        }

        [HttpPost]
        public ActionResult Index(Login model)
        {
            connectionString();
            con.Open();
            com.Connection = con;        
            com.CommandText = "select * from Login where Email = '"+model.Email+"' and Password = '"+model.Password+"'";
            dr = com.ExecuteReader();           

            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("Home","AdminUI");
            }
            else
            {
                con.Close();
                return View();
            }

            
        }


        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }
    }
}