using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirebaseCMServer.Controllers
{
    public class FCMController : ApiController
    {
        [HttpGet]
        public List<FCM> layDanhSachFCM()
        {
            
            try
            {
                List<FCM> ds = new List<FCM>();
                FCMDataContext context = new FCMDataContext();
                ds = context.FCMs.ToList();
                return ds;
            }
            catch
            {
               
            }
            return null;
        }
        [HttpPost]
        public bool addToken(string token)
        {
            try
            {
                if (layTheoToken(token) != null)
                {
                    return false;
                }
                else
                {
                    FCMDataContext context = new FCMDataContext();
                    FCM fCM = new FCM();
                    fCM.Token = token;
                    context.FCMs.InsertOnSubmit(fCM);
                    context.SubmitChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        [HttpGet]
        public FCM layTheoID(int id)
        {
            FCM fCM = null;
            try
            {
                FCMDataContext context = new FCMDataContext();
                fCM = context.FCMs.FirstOrDefault(x=>x.ID==id);
                
            }
            catch { }
            return fCM;
        }
        [HttpGet]
        public FCM layTheoToken(string token)
        {
            FCM fCM = null;
            try
            {
                FCMDataContext context = new FCMDataContext();
                fCM = context.FCMs.FirstOrDefault(x=>x.Token==token);

            }
            catch { }
            return fCM;
        }
    }
}
