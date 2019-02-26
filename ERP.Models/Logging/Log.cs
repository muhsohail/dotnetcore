using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Logging
{
    public class Log : Entity
    {
        public Guid Id { get; set; }
        public string ActionName { get; set; }
        public string LogType { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
