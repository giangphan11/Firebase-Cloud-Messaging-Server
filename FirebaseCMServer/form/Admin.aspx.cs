using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirebaseCMServer.form
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGui_Click(object sender, EventArgs e)
        {
            FCMDataContext context = new FCMDataContext();
            List<FCM> dsFcm = context.FCMs.ToList();
            WebRequest tRequest;
            //thiết lập FCM send
            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "POST";
            tRequest.UseDefaultCredentials = true;

            tRequest.PreAuthenticate = true;

            tRequest.Credentials = CredentialCache.DefaultNetworkCredentials;

            //định dạng JSON
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAIPDhI4M:APA91bGS9X69pxDT4NjW1_AN0afGNOJYQmfDm13wsdp45WpHbfO9Lcr3cZ9Z7o5Cq3VNPfK33kWpShB2ExU9bFYSlLPrMasep-57UtRnwOPEXawFqwD1hGrc2BWZWNuASP21pfvODisw"));
            tRequest.Headers.Add(string.Format("Sender: id={0}", "141480240003"));

            string[] arrRegid = dsFcm.Select(x => x.Token).ToArray();
            
            string RegArr = string.Empty;
            RegArr = string.Join("\",\"", arrRegid);

            string postData = "{ \"registration_ids\": [ \"" + RegArr + "\" ],\"data\": {\"message\": \"" + txtNoiDung.Text + "\",\"body\": \"" + txtNoiDung.Text + "\",\"title\": \"" + txtTieuDe.Text + "\",\"collapse_key\":\"" + txtNoiDung.Text + "\"}}";

            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;

            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();

            dataStream = tResponse.GetResponseStream();

            StreamReader tReader = new StreamReader(dataStream);

            String sResponseFromServer = tReader.ReadToEnd();

            txtKQ.Text = sResponseFromServer; //Lấy thông báo kết quả từ FCM server.
            
            tReader.Close();
            dataStream.Close();
            tResponse.Close();
        }
    }
}