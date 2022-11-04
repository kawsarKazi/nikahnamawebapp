using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace NikahMetromoniApp.Controllers.Api
{
    public class SharedController : ApiController
    {
        public void SMSOTP(string messsage, string number)
        {
            //Previous

            String userid = "01768890336"; //Your Login ID
            String password = "Admin555@#%"; //Your Password

            //Recipient Phone Number multiple number must be separated by comma
            String message = System.Uri.EscapeUriString(messsage);

            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("http://66.45.237.70/api.php");
            //// Set the Method property of the request to POST.  
            request.Method = "POST";
            //// Create POST data and convert it to a byte array.  
            string postData = "username=" + userid + "&password=" + password + "&number=" + number + "&message=" + message;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //// Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded";
            //// Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            //// Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            //// Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object. 

            dataStream.Close();
        }

        public IHttpActionResult SendMail(string email, string mailSubject, string textMessage)
        {
            //var fromAddress = new MailAddress(MailAuthentication.Username, "City Bazar");
            //var toAddress = new MailAddress(email);
            //var fromPassword = MailAuthentication.Passsword;
            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            //};
            //using (var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = mailSubject,
            //    Body = textMessage
            //})
            //{
            //    smtp.Send(message);
            //}

            return Ok(1);
        }
    }
}
