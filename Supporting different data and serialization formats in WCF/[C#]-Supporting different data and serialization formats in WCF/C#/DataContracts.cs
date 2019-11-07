using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.ServiceModel;

namespace JsonNetMessageFormatter
{
    [DataContract]
    [Newtonsoft.Json.JsonObject(MemberSerialization = Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Person
    {
        [DataMember(Order = 1), Newtonsoft.Json.JsonProperty]
        public string FirstName;
        [DataMember(Order = 2), Newtonsoft.Json.JsonProperty]
        public string LastName;
        [DataMember(Order = 3),
            Newtonsoft.Json.JsonProperty,
            Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.IsoDateTimeConverter))]
        public DateTime BirthDate;
        [DataMember(Order = 4), Newtonsoft.Json.JsonProperty]
        public List<Pet> Pets;
        [DataMember(Order = 5), Newtonsoft.Json.JsonProperty]
        public int Id;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Person[");
            sb.AppendFormat(
                "FirstName={0},LastName={1},BirthDate={2},Id={3},Pets",
                this.FirstName,
                this.LastName,
                this.BirthDate.ToLongDateString(),
                this.Id);
            if (this.Pets == null)
            {
                sb.Append("=null");
            }
            else
            {
                sb.AppendFormat("(Count={0})=<", this.Pets.Count);
                for (int i = 0; i < this.Pets.Count; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(',');
                    }

                    sb.Append(this.Pets[i]);
                }

                sb.Append('>');
            }

            sb.Append(']');
            return sb.ToString();
        }
    }

    [DataContract, Newtonsoft.Json.JsonObject(MemberSerialization = Newtonsoft.Json.MemberSerialization.OptIn)]
    public class Pet
    {
        [DataMember(Order = 1), Newtonsoft.Json.JsonProperty]
        public string Name;
        [DataMember(Order = 2), Newtonsoft.Json.JsonProperty]
        public string Color;
        [DataMember(Order = 3), Newtonsoft.Json.JsonProperty]
        public string Markings;
        [DataMember(Order = 4), Newtonsoft.Json.JsonProperty]
        public int Id;

        public override string ToString()
        {
            return string.Format(
                "Pet[Name={0},Color={1},Markings={2},Id={3}]",
                this.Name,
                this.Color,
                this.Markings,
                this.Id);
        }
    }
}
