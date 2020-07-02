using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FilterTest.Filters
{
    public class APIVersionFilterAttribute : ActionFilterAttribute
    {
        private const decimal _currentVersion = 2.1m;
        private const string _versionHeader = "api-version";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var request = filterContext.RequestContext.HttpContext.Request;
                if (!request.Headers.AllKeys.Contains(_versionHeader))
                {
                    SetStatusGone(filterContext);
                }
                else
                {
                    var headerValue = request.Headers.Get(_versionHeader);
                    var version = Convert.ToDecimal(headerValue);

                    if(version < _currentVersion)
                    {
                        SetStatusGone(filterContext);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        private void SetStatusGone(ActionExecutingContext filterContext)
        {
            filterContext.Result = new HttpStatusCodeResult(499, "Call to outdated API version.");
        }
    }
}