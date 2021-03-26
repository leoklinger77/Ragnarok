using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_State")]
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sigle { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        //public ICollection<City> Cities { get; set; } = new HashSet<City>();

        public State()
        {
        }
        public State(int id, string name, string sigle, DateTime insertDate, DateTime? updateDate)
        {
            Id = id;
            Name = name;
            Sigle = sigle;
            InsertDate = insertDate;
            UpdateDate = updateDate;
        }

        public override bool Equals(object obj)
        {
            return obj is State state &&
                   Id == state.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
