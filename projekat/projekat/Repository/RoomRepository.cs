// File:    RoomRepository.cs
// Author:  joldic
// Created: Saturday, April 2, 2022 6:44:28 PM
// Purpose: Definition of Class RoomRepository

using System;
using System.Collections.Generic;
using Model;


namespace Repository
{
   public class RoomRepository
   {
      private String fileName;
      
      public Room GetRoom(uint id)
      {
         throw new NotImplementedException();
      }
      
      public Room UpdateRoom(Room room)
      {
         throw new NotImplementedException();
      }
      
      public Boolean RemoveRoom(uint id)
      {
         throw new NotImplementedException();
      }
      
      public Room AddRoom(Room room)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Room> GetAll()
      {
         throw new NotImplementedException();
      }
   
   }
}