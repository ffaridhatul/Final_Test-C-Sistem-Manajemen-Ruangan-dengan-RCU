namespace CSharpTest.Model
{
    public class Room
    {
        public int Id { get; set; }
        public int RcuId { get; set; }
        public string RoomNo { get; set; }
        public int Floor { get; set; }
        public RoomStatusEnum RoomStatus { get; set; }
        public KeyStatusEnum KeyStatus { get; set; }
        public DoorStatusEnum DoorStatus { get; set; }
        public int? Temperature { get; set; }
        public int? CheckInId { get; set; }
        public int NightlyRate { get; set; }
    }
}
