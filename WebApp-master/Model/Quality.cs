using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Quality
    {
        public long Id { get; set; }
        public QualityLevel Smile { get; set; }
        public QualityLevel Beauty { get; set; }
        public QualityLevel Nature { get; set; }
        public QualityLevel Character { get; set; }
        public QualityLevel Communication { get; set; }
        public QualityLevel Humor { get; set; }
        public long OfPersonId { get; set; }
        public long ByPersonId { get; set; }
    }

    public enum QualityLevel
    {
        VeryLow,
        Low,
        Normal,
        High,
        VeryHigh
    }
}
