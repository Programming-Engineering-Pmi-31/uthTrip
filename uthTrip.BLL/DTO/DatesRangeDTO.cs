namespace UthTrip.BLL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DatesRangeDTO
    {
        public DatesRangeDTO()
        {
        }

        public DatesRangeDTO(int date_ID, DateTime? start_date, DateTime? end_date)
        {
            this.Date_ID = date_ID;
            this.Start_date = start_date;
            this.End_date = end_date;
        }

        public int Date_ID { get; set; }

        public DateTime? Start_date { get; set; }

        public DateTime? End_date { get; set; }
    }
}
