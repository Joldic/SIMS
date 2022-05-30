using Model;
using projekat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Service
{
    public class EquipmentService
    {
        private readonly EquipmentRepository _repo;

        public EquipmentService(EquipmentRepository repo)
        {
            _repo = repo;
        }

        public Equipment CreateNewEquipment(Equipment equipment)
        {
            return _repo.AddEquipment(equipment);
        }

        public Equipment ReadEquipment(uint id)
        {
            return _repo.GetEquipment(id);
        }



        public Equipment UpdateEquipment(Equipment equipment)
        {
            return _repo.UpdateEquipment(equipment);
        }

        public Boolean DeleteEquipment(uint id)
        {
            return _repo.RemoveEquipment(id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<RoomEquipmentDTO> GetAllRoomAndEquipment()
        {
            return _repo.GetAllRoomAndEquipment();
        }

        public RoomEquipmentDTO GetByRoomIdAndEquipmentName(uint id, string name)
        {
            return _repo.GetByRoomIdAndEquipmentName(id, name);
        }

        public Boolean SaveChangesToFile(RoomEquipmentDTO r)
        {
            return _repo.SaveChangesToFile(r);
        }
    }
}
