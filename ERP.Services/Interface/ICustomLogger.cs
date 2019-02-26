using Models.Logging;

namespace ERP.Services.Interface
{
    public interface ICustomLogger
    {

        void InfoLog(Log log);
        void InfoLog(string message);
    }

}
