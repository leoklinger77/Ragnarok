namespace Ragnarok.Models.ViewModels
{
    public class ClientFormViewModel
    {
        public ClientJuridical ClientJuridical { get; set; }
        public ClientPhysical ClientPhysical { get; set; }
        public Address Address { get; set; }
        public Contact Celular { get; set; }
        public Contact Comercial { get; set; }
    }
}
