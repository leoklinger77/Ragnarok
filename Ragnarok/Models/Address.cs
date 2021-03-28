using Ragnarok.Services.Lang;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_Address")]
    public class Address
    {
        public int Id { get; set; }        
        private string _zipCode;
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public string Street { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Reference { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public string Neighborhood { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public City City{ get; set; }
        public int CityId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MSG_E_001")]
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value.Replace("-", ""); }
        }
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
