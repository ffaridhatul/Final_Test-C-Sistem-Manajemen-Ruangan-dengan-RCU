using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControlUnit
{
    public class RcuPacket
    {
        public int RcuId;
        public DoorStatusEnum DoorStatus;
        public KeyStatusEnum KeyStatus;
        public int Temperature;
    }
}
