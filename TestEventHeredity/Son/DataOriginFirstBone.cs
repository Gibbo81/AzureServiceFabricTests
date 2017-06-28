using System.Runtime.Serialization;
using Father;

namespace Son
{
    [DataContract(
        Name = "DataOriginal",
        Namespace = "http://www.cohowinery.com/employees")]
    public class DataOriginFirstBone : DataOriginal
    {
        public DataOriginFirstBone(string name, int id, string description) : base(name, id)
        {
            Description = description;
        }

        [DataMember]
        public string Description { get; private set; }
    }
}
