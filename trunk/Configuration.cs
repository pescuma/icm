using System.Runtime.Serialization;

namespace InternetConnectionMonitor
{
    [DataContract]
    public class Configuration : BaseConfiguration
    {
        public Configuration()
        : base()
        {
        }
        
        public Configuration(Configuration other)
        : base(other)
        {
        }
    }
}