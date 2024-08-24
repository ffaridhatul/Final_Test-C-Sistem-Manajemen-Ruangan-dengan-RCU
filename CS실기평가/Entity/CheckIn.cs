using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest.Model
{
    public class CheckIn
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int CheckInDays { get; set; }
        public int Payment { get; set; }
    }
}
