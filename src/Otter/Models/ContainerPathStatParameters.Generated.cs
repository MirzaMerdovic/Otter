using System.Runtime.Serialization;
using Otter.Converters.QueryString;

namespace Otter.Models
{
    [DataContract]
    public class ContainerPathStatParameters // (main.ContainerPathStatParameters)
    {
        [QueryStringParameter("path", true)]
        public string Path { get; set; }

        [QueryStringParameter("noOverwriteDirNonDir", false, typeof(BoolQueryStringConverter))]
        public bool? AllowOverwriteDirWithFile { get; set; }
    }
}
