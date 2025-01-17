using System.Runtime.Serialization;

namespace Otter.Models
{
    [DataContract]
    public class PluginConfigUser // (types.PluginConfigUser)
    {
        [DataMember(Name = "GID", EmitDefaultValue = false)]
        public uint GID { get; set; }

        [DataMember(Name = "UID", EmitDefaultValue = false)]
        public uint UID { get; set; }
    }
}
