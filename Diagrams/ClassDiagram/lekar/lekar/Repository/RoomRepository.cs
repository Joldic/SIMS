using System;
using Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using lekar.Exception;

namespace Repository
{
   public class RoomRepository
   {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _roomMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public RoomRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _roomMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(List<Room> rooms)
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

        public List<Room> GetAll()
        {
            return File.ReadAllLines(_path)
                .Select(ConvertCSVFormatToRoom)
                .ToList();
        }

        public Room UpdateRoom(Room room)
        {
            string temp_file = _projectPath + "\\Resources\\temp.txt";
            string room_file = _projectPath + "\\Resources\\room.txt";

            using (var sr = new StreamReader(room_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertRoomToCSVFormat(room);
                    Room tempRoom = ConvertCSVFormatToRoom(line);
                    if (room.Id != tempRoom.Id)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        sw.WriteLine(lineToWrite);
                    }
                }
            }
            File.Delete(room_file);
            File.Move(temp_file, room_file);

            return room;
        }

        public Boolean RemoveRoom(uint id)
        {
            string temp_file = _projectPath + "\\Resources\\temp.txt";
            string room_file = _projectPath + "\\Resources\\room.txt";
            Boolean retVal = false;
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

        private Room ConvertCSVFormatToRoom(string roomCSVFormat)
        {
            Room room = new Room();
            string[] tokens = roomCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            string Name = tokens[1];
            Enum.TryParse(tokens[2], out RoomType type);
            uint SF = uint.Parse(tokens[3]);

            return new Room(
                Id,
                Name,
                type,
                SF
            );
        }

        private string ConvertRoomToCSVFormat(Room room)
        {
            return string.Join(_delimeter,
                room.Id,
                room.Name,
                room.Type,
                room.SquareFootage);
        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}