// File:    PregledRepository.cs
// Author:  joldic
// Created: 30 March 2022 18:43:52
// Purpose: Definition of Class PregledRepository

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Model;
using projekat.Exception;

namespace Repository
{

    public class AppointmentRepository
   {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _appointmentMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;
        private String fileName;

        public AppointmentRepository(string path, string delimeter, string dateTimeFormat)
        {
            _path = path;
            _delimeter = delimeter;
            _dateTimeFormat = dateTimeFormat;
            _appointmentMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Appointment> appointments)
        {
            return appointments.Count() == 0 ? 0 : appointments.Max(appointment => appointment.Id);
        }



        public Appointment CreateNewAppointment(Appointment appointment)
        {
            appointment.Id = ++_appointmentMaxId;
            AppendLineToFile(_path, ConvertAppointmentToCSVFormat(appointment));
            return appointment;
        }



      
        public Boolean DeleteApointment(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Appointment> appointments = GetAll();

            appointments = appointments.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\temp1.txt";
            string appointment_file = _projectPath + "\\Resources\\appointment.txt";

            using(var sr = new StreamReader(appointment_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Appointment appointment = ConvertCSVFormatToAppointment(line);
                    if(appointment.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(appointment_file);
            File.Move(temp_file, appointment_file);

            return retVal;

            

                return retVal;
        }
      



        public Appointment UpdateApointment(Appointment apointment)
        {
            throw new NotImplementedException();
        }
      



        public Appointment GetApointment(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(apointment => apointment.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }




        public IEnumerable<Appointment> GetAll()
        {
            return File.ReadAllLines(_path)
                .Select(ConvertCSVFormatToAppointment)
                .ToList();
        }

        private Appointment ConvertCSVFormatToAppointment(string appointmentCSVFormat)
        {
            Appointment Appointment = new Appointment();
            string[] tokens = appointmentCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            uint IdDoctor = uint.Parse(tokens[3]);
            uint IdPatinet = uint.Parse(tokens[4]);
            uint IdRoom= uint.Parse(tokens[5]);
            

            return new Appointment(
                Id,
                DateTime.Parse(tokens[1]),
                DateTime.Parse(tokens[2]),
                IdDoctor,
                IdPatinet,
                IdRoom
            );


        }
        private string ConvertAppointmentToCSVFormat(Appointment Appointment)
        {
            return string.Join(_delimeter,
                Appointment.Id,
                Appointment.StartAppointment,
                Appointment.EndAppointment,
                Appointment.IdDoctor,
                Appointment.IdPatient,
                Appointment.IdRoom);

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }

    }
}