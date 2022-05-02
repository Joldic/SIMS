// File:    RoomRepository.cs
// Author:  joldic
// Created: Saturday, April 2, 2022 6:44:28 PM
// Purpose: Definition of Class RoomRepository

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;

using projekat.Exception;

namespace Repository
{
   public class RoomRepository
   {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _roomMaxId;
        private uint _renovationMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private FileStream temp;


        public RoomRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _roomMaxId = GetMaxId(GetAll());
            _renovationMaxId = GetMaxRenovationId(GetAllRenovation());

        }

        private uint GetMaxId(IEnumerable<Room> rooms)
        {
            return rooms.Count() == 0 ? 0 : rooms.Max(room => room.Id);
        }

        private uint GetMaxRenovationId(IEnumerable<RoomRenovationDTO> rooms)
        {
            return rooms.Count() == 0 ? 0 : rooms.Max(room => room.Id);
        }


        public Room GetRoom(uint id)
      {
            try
            {

                return GetAll().SingleOrDefault(room => room.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }
      
      public Room UpdateRoom(Room room)
      {
            string temp_file = _projectPath + "\\Resources\\tempROO.txt";
            string _file = _projectPath + "\\Resources\\room.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertRoomToCSVFormat(room);
                    Room tempApp = ConvertCSVFormatToRoom(line);
                    if (room.Id != tempApp.Id)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        sw.WriteLine(lineToWrite);
                    }
                    //sw.WriteLine(lineToWrite);
                }
            }
            File.Delete(_file);
            File.Move(temp_file, _file);



            return room;
        }
      
      public Boolean RemoveRoom(uint id)
      {
            Boolean retVal = false;
           

            string temp_file = _projectPath + "\\Resources\\tempRD.txt";
            string room_file = _projectPath + "\\Resources\\room.txt";

            using (var sr = new StreamReader(room_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Room room = ConvertCSVFormatToRoom(line);
                    if (room.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(room_file);
            File.Move(temp_file, room_file);

            return retVal;
        }
      
      public Room AddRoom(Room room)
      {
            room.Id = ++_roomMaxId;
            AppendLineToFile(_path, ConvertRoomToCSVFormat(room));
            return room;
      }

        public RoomRenovationDTO AddRenovation(RoomRenovationDTO r)
        {
            r.Id = ++_renovationMaxId;
            string path_to_file = _projectPath + "\\Resources\\renovation.txt";
            AppendLineToFile(path_to_file, ConvertRoomRenovationToCSVFormat(r));
            return r;
        }



        public IEnumerable<Room> GetAll()
      {
            return File.ReadAllLines(_path)
                  .Select(ConvertCSVFormatToRoom)
                  .ToList();
      }

        public IEnumerable<RoomRenovationDTO> GetAllRenovation()
        {
            string path_to_file = _projectPath + "\\Resources\\renovation.txt";
            return File.ReadAllLines(path_to_file)
                  .Select(ConvertCSVFormatToRoomRenovation)
                  .ToList();
        }

        public IEnumerable<RoomEquipmentDTO> GetAllRoomAndEquipment()
        {
            string path_to_file = _projectPath + "\\Resources\\RoomEquipment.txt";
            return File.ReadAllLines(path_to_file)
                .Select(ConvertCSVFormatToRoomEquipment).ToList();
        }

        public RoomEquipmentDTO GetByRoomIdAndEquipmentName(uint id, string name)
        {
            string path_to_file = _projectPath + "\\Resources\\RoomEquipment.txt";
            RoomEquipmentDTO dto = new RoomEquipmentDTO();

            using (var sr = new StreamReader(path_to_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    RoomEquipmentDTO temp = ConvertCSVFormatToRoomEquipment(line);
                    if (temp.RoomId == id & temp.EquipmentName == name)
                    {
                        dto = temp;
                        break;
                    }
                }
            }
            return dto;
        }

        public Boolean SaveChangesToFile(RoomEquipmentDTO dto)
        {
            Boolean retVal = false;



            string temp_file = _projectPath + "\\Resources\\tempRE.txt";
            string dto_file = _projectPath + "\\Resources\\RoomEquipment.txt";


            using (var sr = new StreamReader(dto_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertRoomEquipmentToCSCFormat(dto);
                    RoomEquipmentDTO tempRoom = ConvertCSVFormatToRoomEquipment(line);
                    if (dto.Id != tempRoom.Id)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        sw.WriteLine(lineToWrite);
                        retVal = true;
                    }
                    //sw.WriteLine(lineToWrite);
                }
            }
            File.Delete(dto_file);
            File.Move(temp_file, dto_file);



            return retVal;
        }

        private Room ConvertCSVFormatToRoom(string roomCSVFormat)
        {
            Room room = new Room();
            string[] tokens = roomCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            string Name = tokens[1];
            Enum.TryParse(tokens[2], out RoomType type);
            uint SquareFootage = uint.Parse(tokens[3]);
            Boolean Availability = Boolean.Parse(tokens[4]);


            return new Room(
                Id,
                Name,
                type,
                SquareFootage,
                Availability
            );
        }

        private RoomRenovationDTO ConvertCSVFormatToRoomRenovation(string roomCSVFormat)
        {
            Room room = new Room();
            string[] tokens = roomCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            uint RoomId = uint.Parse(tokens[1]);
         


            return new RoomRenovationDTO(
                Id,
                RoomId,
                DateTime.Parse(tokens[2]),
                DateTime.Parse(tokens[3])
            );
        }

        private RoomEquipmentDTO ConvertCSVFormatToRoomEquipment(string roomEquipmentCSVFormat)
        {
            RoomEquipmentDTO roomEquipment = new RoomEquipmentDTO();
            string[] tokens = roomEquipmentCSVFormat.Split(_delimeter.ToCharArray());
            uint Id = uint.Parse(tokens[0]);
            uint RoomId = uint.Parse(tokens[1]);
            string RoomName = tokens[2];
            Enum.TryParse(tokens[3], out RoomType type);
            uint EquipmentId = uint.Parse(tokens[4]);
            string EquipmentName = tokens[5];
            uint Quantity = uint.Parse(tokens[6]);

            return new RoomEquipmentDTO(
                Id,
                RoomId,
                RoomName,
                type,
                EquipmentId,
                EquipmentName,
                Quantity
             );
        }

        private string ConvertRoomToCSVFormat(Room room)
        {
            return string.Join(_delimeter,
                room.Id,
                room.Name,
                room.Type,
                room.SquareFootage,
                room.Availability);

        }

        private string ConvertRoomRenovationToCSVFormat(RoomRenovationDTO room)
        {
            return string.Join(_delimeter,
                room.Id,
                room.IdRoom,
                room.Start,
                room.End);

        }

        private string ConvertRoomEquipmentToCSCFormat(RoomEquipmentDTO room)
        {
            return string.Join(_delimeter,
                room.Id,
                room.RoomId,
                room.RoomName,
                room.Type,
                room.EquipmentId,
                room.EquipmentName,
                room.Quantity
                );
        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }

    }
}