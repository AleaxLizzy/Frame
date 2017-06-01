using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using System.Diagnostics;
using Frame.Core.Infrastructure;
using Frame.Service.Logger;
using Frame.Core.Logs;
using Frame.Util.Extension;
namespace Frame.Web.Framework.Logging
{
    public class EfTraceFormattedListener : FormattedTraceListenerBase
    {
        public EfTraceFormattedListener(ILogFormatter logFormatter)
        {
            this.Formatter = logFormatter;
        }
        public override void WriteLine(string message)
        {
            Write(message);
        }

        public override void Write(string message)
        {
            SaveLogEntry(new LogEntry
            {
                EventId = 0,
                Priority = 5,
                Severity = TraceEventType.Information,
                Message = message
            });

        }
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            if (this.Filter == null || this.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
            {
                if (data is LogEntry)
                {
                    SaveLogEntry(data as LogEntry);
                }
                if (data is string)
                {
                    Write(data as string);
                }
            }
            base.TraceData(eventCache, source, eventType, id, data);
        }

        private void SaveLogEntry(LogEntry logEntry)
        {
            var _logService = EngineContext.Current.Resolve<ILogService>();
            _logService.Add(new Log
            {
                Priority = logEntry.Priority,
                AppDomainName = logEntry.AppDomainName,
                Category = string.Join(",", logEntry.CategoriesStrings),
                MachineName = logEntry.MachineName,
                Message = logEntry.Message,
                ProcessId = logEntry.ProcessId,
                ProcessName = logEntry.ProcessName,
                Severity = logEntry.LoggedSeverity,
                ThreadId = logEntry.Win32ThreadId,
                Title = logEntry.Title,
                CreatedTime = DateTime.Now.ToLocalTime(),
                FormattedMessage = logEntry.ToJson()
            });
        }
    }
}
