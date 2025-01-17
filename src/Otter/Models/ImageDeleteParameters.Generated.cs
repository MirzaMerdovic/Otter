using System.Runtime.Serialization;
using Otter.Converters.QueryString;

namespace Otter.Models
{
    [DataContract]
    public class ImageDeleteParameters // (main.ImageDeleteParameters)
    {
        [QueryStringParameter("force", false, typeof(BoolQueryStringConverter))]
        public bool? Force { get; set; }

        [QueryStringParameter("noprune", false, typeof(BoolQueryStringConverter))]
        public bool? NoPrune { get; set; }
    }
}
