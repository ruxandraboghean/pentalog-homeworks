using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinder.Services.Dtos
{
    public class MonkeyDto
    {
        internal object ImageUri;

        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public Uri Image { get; set; }
        public long Population { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
