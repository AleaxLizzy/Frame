using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using System.IO;
using System.Reflection;
namespace Frame.Web.Framework.Exceptions
{
    [ConfigurationElementType(typeof(LoggingHandlerData))]
    public class LoggingHandler : IExceptionHandler
    {
        private readonly string _title;
        private readonly Type _formatterType;
        public LoggingHandler(string title, Type formatterType)
        {
            _title = title;
            _formatterType = formatterType;
        }
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            var entry = new LogEntry(exception.Message, "General", 0, 100, TraceEventType.Error, _title, null);
            foreach (DictionaryEntry item in exception.Data)
            {
                if (item.Key is string)
                {
                    entry.ExtendedProperties.Add(item.Key as string, item.Value);
                }
            }
            Type[] types = new Type[] { typeof(TextWriter), typeof(Exception), typeof(Guid) };
            ConstructorInfo constructorInfo = _formatterType.GetConstructor(types);
   
            using(StringWriter writer=new StringWriter())
            {
                var exceptionFormatter = (Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionFormatter)constructorInfo.Invoke(new object[] {writer, exception, handlingInstanceId });
                exceptionFormatter.Format();
                entry.ExtendedProperties.Add("Exception", writer.GetStringBuilder().ToString());
            }
            Logger.Write(entry);
            return exception;
        }
    }
}
