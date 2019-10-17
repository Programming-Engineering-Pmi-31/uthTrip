using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uthTrip.BLL.DTO
{
    public class DatesRangeDTO
    {
        public int Date_ID { get; set; }
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get; set; }

        public DatesRangeDTO(int date_ID, DateTime? start_date, DateTime? end_date)
        {
            Date_ID = date_ID;
            Start_date = start_date;
            End_date = end_date;
        }
    }
}
