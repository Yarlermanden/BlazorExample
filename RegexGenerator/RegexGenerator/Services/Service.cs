using RegexGenerator.Helpers;
using Serilog;

namespace RegexGenerator.Services
{
    public interface IService
    {
        public void ServiceMethod(string test);
    }
    
    public class Service : IService
    {
        public IHelper Helper { get; set; }

        public Service(IHelper helper)
        {
            Helper = helper;
        }
        
        public void ServiceMethod(string test)
        {
            Log.Information("Service method is invoked");
            Helper.HelperMethod(test);
        }
    }
}