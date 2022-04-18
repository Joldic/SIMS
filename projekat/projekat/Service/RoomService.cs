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
      public Room FindRoom(uint id)
      {
         throw new NotImplementedException();
      }
      
      public Room ChangeRoom(Room room)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteRoom(uint id)
      {
         throw new NotImplementedException();
      }
      
      public Room CreateNewRoom(Room room)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Room> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public RoomRepository roomRepository;
   
   }
}