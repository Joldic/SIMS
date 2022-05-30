using Model;
using projekat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Controller
{
    public class EquipmentController
    {
        private readonly EquipmentService _service;

        public EquipmentController(EquipmentService service)
        {
            _service = service;
        }

        public Equipment CreateNewEquipment(Equipment equipment)
        {
            return _service.CreateNewEquipment(equipment);
        }

        public Equipment ReadEquipment(uint id)
        {
            return _service.ReadEquipment(id);
        }

  

        public Equipment UpdateEquipment(Equipment equipment)
        {
            return _service.UpdateEquipment(equipment);
        }

        public Boolean DeleteEquipment(uint id)
        {
            return _service.DeleteEquipment(id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _service.GetAll();
        }

        public IEnumerable<RoomEquipmentDTO> GetAllRoomAndEquipment()
        {
            return _service.GetAllRoomAndEquipment();
        }
       
        public RoomEquipmentDTO GetByRoomIdAndEquipmentName(uint id, string name)
        {
            return _service.GetByRoomIdAndEquipmentName(id, name);
        }

        public Boolean SaveChangesToFile(RoomEquipmentDTO r)
        {
            return _service.SaveChangesToFile(r);
        }

    }
}
