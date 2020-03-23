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
using WebPage.Models;

namespace WebPage.Controllers.APIController
{
    public class UserController : ApiController
    {
        private DatabaseContextPage db = new DatabaseContextPage();

        public HttpResponseMessage LoginUser(string email)
        {
            if(string.IsNullOrEmpty(email)) Request.CreateResponse(HttpStatusCode.BadRequest, new { status = "Failed" });

            return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success" });
        }

        public HttpResponseMessage RegisterUser(UserEntity userEntity)
        {
            if (!ModelState.IsValid) Request.CreateResponse(HttpStatusCode.BadRequest, new { status = "Failed" });

            UserEntity _result = db.UserEntities.Where(x => x.Email == userEntity.Email).FirstOrDefault();
            if (_result != null)
                return Request.CreateResponse(HttpStatusCode.Conflict, new { status = "Failed", msg = "Email already exist !" });

            if (db.UserEntities.Where(x => x.MobileNumber == userEntity.MobileNumber).FirstOrDefault() != null)
                return Request.CreateResponse(HttpStatusCode.Conflict, new { status = "Failed", msg = "Mobile phone already exist !" });

            try
            {
                db.UserEntities.Add(userEntity);
                db.SaveChanges();
            }
            catch(Exception ex) {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { status = "Failed" });
            }

            _result = db.UserEntities.Where(x => x.Email == userEntity.Email).FirstOrDefault();

            if (_result != null)
                return Request.CreateResponse(HttpStatusCode.OK, new { status = "Success", data = _result.UserId });
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { status = "Failed" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}