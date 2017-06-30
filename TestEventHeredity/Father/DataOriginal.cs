using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Father
{
    [DataContract(
        Name = "DataOriginal",
        Namespace = "http://www.cohowinery.com/employees")]
    public class DataOriginal
    {
        public static readonly List<Type> KnownTypes = new List<Type>();

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public int Id { get; private set; }


        public DataOriginal(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}