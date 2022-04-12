using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aaaaaaaa.view.Model;
using aaaaaaaa.model;

namespace aaaaaaaa.view.Converter
{
     class RoomConverter : AbstractConverter
    {
        public static RoomView ConvertRoomToRoomView(Room room)
          => new RoomView
          {
             Id = room.Id,
             RoomName = room.Name,
             RoomType = room.Type,
             SquareFootage = room.SquareFootage
          };


        public static IList<RoomView> ConvertRoomListToRoomViewList(IList<Room> rooms)
           => ConvertEntityListToViewList(rooms, ConvertRoomToRoomView);
    }
}
