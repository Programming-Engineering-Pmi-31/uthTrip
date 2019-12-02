namespace UthTrip.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ReviewDTO
    {
        public ReviewDTO(int review_ID, int writer_ID, int trip_ID, string review1, int? mark)
        {
            Review_ID = review_ID;
            Writer_ID = writer_ID;
            Trip_ID = trip_ID;
            Review1 = review1;
            Mark = mark;
        }

        public int Review_ID { get; set; }

        public int Writer_ID { get; set; }

        public int Trip_ID { get; set; }

        public string Review1 { get; set; }

        public int? Mark { get; set; }
    }
}
