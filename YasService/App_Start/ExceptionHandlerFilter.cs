namespace YasService
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;
    using Newtonsoft.Json;
    using Exceptions;

    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var exception = actionExecutedContext.Exception;
                var statusCode = HttpStatusCode.InternalServerError;
                var validationException = exception as BusinessValidationException;
                string content;

                if (validationException != null)
                {
                    var businessValidationException = validationException;
                    content = businessValidationException.Message;
                    statusCode = HttpStatusCode.BadRequest;
                }
                else if (exception is NotFoundException)
                {
                    content = FormatExceptionMessage(exception.Message);
                    statusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    content = FormatExceptionMessage(new SystemException().Message);
                }

                actionExecutedContext.Response = this.ExceptionResponse(content, statusCode);
            }
        }

        private static string FormatExceptionMessage(string exceptionMessage)
        {
            return JsonConvert.SerializeObject(new { error = exceptionMessage });
        }

        private string GetExceptionFullMessage(Exception ex)
        {
            var result = "";
            var prefix = "";
            while (ex != null)
            {
                result = result + prefix + ex.Message;
                ex = ex.InnerException;
                prefix = prefix + Environment.NewLine + "    ";
            }
            return result;
        }

        private HttpResponseMessage ExceptionResponse(string content, HttpStatusCode statusCode)
        {
            return new HttpResponseMessage { Content = new StringContent(content), StatusCode = statusCode };
        }
    }
}