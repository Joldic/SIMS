using Model;
using projekat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Controller
{
    public class RenovationController
    {
        private readonly RenovationService _service;

        public RenovationController(RenovationService service)
        {
            _service = service;
        }

        public IEnumerable<RoomRenovationDTO> GetAllRenovation()
        {
            return _service.GetAllRenovation();
        }

        public RoomRenovationDTO AddRenovation(RoomRenovationDTO dto)
        {
            return _service.AddRenovation(dto);
        }


    }
}
