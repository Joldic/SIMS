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
      public Room CreateNewRoom(Room room)
      {
         throw new NotImplementedException();
      }
      
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
      
      public IEnumerable<Room> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public RoomService roomService;
   
   }
}