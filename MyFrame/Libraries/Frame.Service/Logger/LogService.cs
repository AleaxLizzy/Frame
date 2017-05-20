using Frame.Core.Logs;
using Frame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Service.Logger
{
    public class LogService : ILogService
    {
        private readonly IRepository<Log> _logRepository;
        public LogService(IRepository<Log> logRepository)
        {
            _logRepository =logRepository;
        }
        public void Add(Log entity)
        {
            _logRepository.Insert(entity);
        }
    }
}
