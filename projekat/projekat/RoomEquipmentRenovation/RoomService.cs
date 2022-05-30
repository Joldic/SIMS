// File:    RoomService.cs
// Author:  joldic
// Created: Saturday, April 2, 2022 6:34:31 PM
// Purpose: Definition of Class RoomService

using System;
using Repository;

using System.Collections.Generic;
using Model;
namespace Service
{
   public class RoomService
   {
        private readonly  RoomRepository _repo;

        public RoomService(RoomRepository repo)
        {
            _repo = repo;
        }

        public Room FindRoom(uint id)
        {
            return _repo.GetRoom(id);
        }
      
        public Room ChangeRoom(Room room)
        {
            return _repo.UpdateRoom(room);
        }
      
        public Boolean DeleteRoom(uint id)
        {
            return _repo.RemoveRoom(id);
        }
      
        public Room CreateNewRoom(Room room)
        {
            return _repo.AddRoom(room);
        }
      
        public IEnumerable<Room> GetAll()
        {
            return _repo.GetAll();
        }
        public Boolean AvailableForDeletion(uint id)
        {
            return _repo.AvailableForDeletion(id);
        }

    }
}