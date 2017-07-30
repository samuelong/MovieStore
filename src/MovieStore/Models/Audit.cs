using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{//
    public class Audit
    {
        public Guid AuditID { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string URLAccessed { get; set; }
        public DateTime TimeAccessed { get; set; }

        public Audit()
        {
        }
    }
    public class AuditAttribute : ActionFilterAttribute
    {
        public int AuditingLevel { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            Audit audit = new Audit()
            {
                AuditID = Guid.NewGuid(),
                IPAddress = request.HttpContext.Connection.RemoteIpAddress.ToString(),
                URLAccessed = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(request),
                TimeAccessed = DateTime.Now,
                UserName = filterContext.HttpContext.User.Identity.Name ?? "Anonymous"
            };

            base.OnActionExecuting(filterContext);
        }

    }
}