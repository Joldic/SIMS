using Model;
using projekat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Service
{
    public class RenovationService
    {
        private readonly RenovationRepository _repo;

        public RenovationService(RenovationRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<RoomRenovationDTO> GetAllRenovation()
        {
            return _repo.GetAllRenovation();
        }

        public RoomRenovationDTO AddRenovation(RoomRenovationDTO dto)
        {
            return _repo.AddRenovation(dto);
        }

     

    }
}
