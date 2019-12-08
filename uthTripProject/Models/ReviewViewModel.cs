namespace UthTripProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using UthTrip.BLL.DTO;

    public class ReviewViewModel
    {
        public ReviewViewModel()
        {
        }

        public ReviewViewModel(int review_ID, int writer_ID, int trip_ID, string review1, int? mark)
        {
            this.Review_ID = review_ID;
            this.Writer_ID = writer_ID;
            this.Trip_ID = trip_ID;
            this.Review1 = review1;
            this.Mark = mark;
        }

        public int Review_ID { get; set; }

        public int Writer_ID { get; set; }

        public int Trip_ID { get; set; }

        [DisplayName("Відгук")]
        public string Review1 { get; set; }

        [DisplayName("Оцінка")]
        public int? Mark { get; set; }
    }
}
