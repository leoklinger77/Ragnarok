using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Address")]
    public class Address
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Reference { get; set; }
        public string Neighborhood { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public City City{ get; set; }
        public int CityId { get; set; }

        public Address()
        {
        }

        public Address(int id, string zipCode, string street, int number, string complement, string reference, string neighborhood, DateTime insertDate, DateTime? updateDate, City city)
        {
            Id = id;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            Reference = reference;
            Neighborhood = neighborhood;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            City = city;
        }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Id == address.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
