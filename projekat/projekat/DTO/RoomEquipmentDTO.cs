using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model
{
    public class RoomEquipmentDTO
    {
        public uint Id { get; set; }

        public uint RoomId { get; set; }

        public string RoomName { get; set; }

        public RoomType Type { get; set; }

        public uint EquipmentId { get; set; }

        public string EquipmentName { get; set; }

        public uint Quantity { get; set; }

        public RoomEquipmentDTO()
        {

        }

        public RoomEquipmentDTO(uint id)
        {
            Id = id;
        }

        public RoomEquipmentDTO(uint id, uint roomId, string roomName, RoomType type, uint equipmentId, string equipmentName, uint quantity) : this(id)
        {
            RoomId = roomId;
            RoomName = roomName;
            Type = type;
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            Quantity = quantity;
        }
    }
}
