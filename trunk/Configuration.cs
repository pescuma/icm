using System.Runtime.Serialization;

namespace org.pescuma.icm
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