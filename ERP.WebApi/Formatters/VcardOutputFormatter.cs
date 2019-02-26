using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace ERP.WebApi.Formatters
{
    #region classdef
    public class VcardOutputFormatter : TextOutputFormatter
    #endregion
    {
        #region ctor
        public VcardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        #endregion

        #region canwritetype
        protected override bool CanWriteType(Type type)
        {
            if (typeof(Contact).IsAssignableFrom(type)
                || typeof(IEnumerable<Contact>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        #endregion

        #region writeresponse
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            IServiceProvider serviceProvider = context.HttpContext.RequestServices;
            var logger = serviceProvider.GetService(typeof(ILogger<VcardOutputFormatter>)) as ILogger;

            var response = context.HttpContext.Response;

            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<Contact>)
            {
                foreach (Contact contact in context.Object as IEnumerable<Contact>)
                {
                    FormatVcard(buffer, contact, logger);
                }
            }
            else
            {
                var contact = context.Object as Contact;
                FormatVcard(buffer, contact, logger);
            }
            return response.WriteAsync(buffer.ToString());
        }

        private static void FormatVcard(StringBuilder buffer, Contact contact, ILogger logger)
        {
            buffer.AppendLine("BEGIN:VCARD");
            buffer.AppendLine("VERSION:2.1");
            buffer.AppendFormat($"N:{contact.Name};{contact.Name}\r\n");
            buffer.AppendFormat($"FN:{contact.EmailAddress} {contact.EmailAddress}\r\n");
            buffer.AppendFormat($"UID:{contact.Id}\r\n");
            buffer.AppendLine("END:VCARD");
            logger.LogInformation($"Writing {contact.Name} {contact.Name}");
        }
        #endregion
    }
}
