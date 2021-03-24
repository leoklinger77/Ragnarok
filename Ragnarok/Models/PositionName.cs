﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_PositionName")]
    public class PositionName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ICollection<Employee> Employee { get; set; } = new HashSet<Employee>();

        public PositionName()
        {
        }

        public PositionName(int id, string name, DateTime insertDate, DateTime? updateDate)
        {
            Id = id;
            Name = name;
            InsertDate = insertDate;
            UpdateDate = updateDate;
        }

        public override bool Equals(object obj)
        {
            return obj is PositionName name &&
                   Id == name.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}