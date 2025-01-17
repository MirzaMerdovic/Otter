using System.Runtime.Serialization;

namespace Otter.Models
{
    [DataContract]
    public class ImagesLoadResponse // (types.ImageLoadResponse)
    {
        [DataMember(Name = "Body", EmitDefaultValue = false)]
        public object Body { get; set; }

        [DataMember(Name = "JSON", EmitDefaultValue = false)]
        public bool JSON { get; set; }
    }
}
