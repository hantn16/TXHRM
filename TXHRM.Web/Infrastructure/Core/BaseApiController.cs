using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TXHRM.Model.Models;
using TXHRM.Service;

namespace TXHRM.Web.Infrastructure.Core
{
    public class BaseApiController : ApiController
    {
        private IErrorService _errorService;

        public BaseApiController(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                responseMessage = function.Invoke();
            }
            catch (DbEntityValidationException dbEVEx)
            {
                foreach (var eve in dbEVEx.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(dbEVEx);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEVEx.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadGateway, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                responseMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return responseMessage;
        }

        private void LogError(Exception exception)
        {
            try
            {
                Error error = new Error()
                {
                    CreatedDate = DateTime.Now,
                    Message = exception.Message,
                    StackTrace = exception.StackTrace
                };
                _errorService.Create(error);
                _errorService.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}