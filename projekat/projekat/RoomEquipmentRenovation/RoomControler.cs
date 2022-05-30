// File:    RoomControler.cs
// Author:  joldic
// Created: Saturday, April 2, 2022 6:28:05 PM
// Purpose: Definition of Class RoomControler

using System;
using System.Collections.Generic;
using Model;
using Service;
namespace Controller
{
   public class RoomControler
   {
        private readonly RoomService _service;

        public RoomControler(RoomService service)
        {
            _service = service;
        }
        public Room CreateNewRoom(Room room)
        {
            return _service.CreateNewRoom(room);
        }
      
        public Room FindRoom(uint id)
        {
            return _service.FindRoom(id);
        }
      
        public Room ChangeRoom(Room room)
        {
            return _service.ChangeRoom(room);
        }
      
        public Boolean DeleteRoom(uint id)
        {
            return _service.DeleteRoom(id);
        }
      
        public IEnumerable<Room> GetAll()
        {
            return _service.GetAll();
        }
        public Boolean AvailableForDeletion(uint id)
        {
            return _service.AvailableForDeletion(id);
        }


   }
}