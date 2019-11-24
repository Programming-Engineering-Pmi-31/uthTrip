namespace uthTrip.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class ReviewDTO
    {
        public int Review_ID { get; set; }
        public int Writer_ID { get; set; }
        public int Trip_ID { get; set; }
        public string Review1 { get; set; }
        public int? Mark { get; set; }
    }
}
