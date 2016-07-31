using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using System.Net.Http;

namespace RecruitApp.Handler
{
    public class RecruitExceptionHandler: ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            // Get the Trace ID that was associated with this Exception by the Exception Logger.
            // This Trace ID was logged with the Exception information and should now be returned to the
            // consumer of the service so they can call the support Team when there is an issue.
            string traceId = context.Exception.Data["errorTraceId"] as string;

            string message = string.Empty;
            var errorCodes = new List<string>();
            HttpError httpError;
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            // Map Domain Model Exceptions to Http Status Code
            if (context != null)
            {
               if (context.Exception is SqlException)
                {
                    // Copy the Error Code from the exception, consumer of the service can use this to resolve to
                    // a language dependent error message instead of using the default English error message
                    errorCodes.Add(((SqlException)context.Exception).Number.ToString());

                    // Copy message from exception, default English error message for the consumer of the service
                    message = context.Exception.Message;
                    if (errorCodes.Contains("50002") || errorCodes.Contains("50001") || errorCodes.Contains("50102") || errorCodes.Contains("50201"))
                    {
                        httpStatusCode = HttpStatusCode.Conflict;
                    }
                    else
                    {
                        httpStatusCode = HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    // System.Exception: Unexpected Exception (Shielded Exception)
                    // Exception shielding helps prevent a Web service from disclosing information about the  
                    // internal implementation of the service when an exception occurs. Only exceptions that  
                    // have been sanitized or are safe by design should be returned to the client application. 
                    // use the Exception Shielding pattern to sanitize unsafe exceptions by replacing them with 
                    // exceptions that are safe by design.
                    // Assign Error Code for Shielded Exception, consumer of service can use this to resolve to
                    // a language dependent error message instead of using the default English error message
                    message = "Please re-try your action. If you continue to get this error, please contact the Administrator with the following details: ";
                    errorCodes.Add(context.Exception.Message);
                    httpStatusCode = HttpStatusCode.InternalServerError;
                }

                // Return error message to consumer of service
                httpError = new HttpError() { { "TraceId", traceId }, { "ErrorMessage", message }, { "ErrorCodes", errorCodes } };
                context.Result = new ResponseMessageResult(context.Request.CreateResponse(httpStatusCode, httpError));

            }
        }

    }
}