// File:    Equipment.cs
// Author:  joldic
// Created: 18 April 2022 12:18:43
// Purpose: Definition of Class Equipment

using System;

namespace Model
{
   public class Equipment
   {
        public uint Id { get; set; }
        public uint Quantity { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }

        public Equipment()
        {

        }

        public Equipment(uint id)
        {
            Id = id;
        }

        public Equipment(uint id, uint quantity, string name, EquipmentType type) : this(id)
        {
            Quantity = quantity;
            Name = name;
            Type = type;
        }

        public Equipment(uint quantity, string name, EquipmentType type) : this(quantity)
        {
            Name = name;
            Type = type;
        }
    }
}