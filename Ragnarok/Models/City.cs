using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_City")]
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public State State { get; set; }
        public int StateId { get; set; }

        public City()
        {
        }
        public City(int id, string name, DateTime insertDate, DateTime? updateDate)
        {
            Id = id;
            Name = name;
            InsertDate = insertDate;
            UpdateDate = updateDate;
        }

        public override bool Equals(object obj)
        {
            return obj is City city &&
                   Id == city.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
