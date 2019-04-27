using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Stone.Clients.Messages
{
    public class ClientMessage
    {
        [DataMember(Name = "name")]
        [Required(ErrorMessage = "Field 'name' is required")]
        public string Name { get; set; }

        [DataMember(Name = "state")]
        [Required(ErrorMessage = "Field 'state' is required")]
        public string State { get; set; }

        [DataMember(Name = "cpf")]
        [Required(ErrorMessage = "Field 'cpf' is required")]
        public string Cpf { get; set; }
    }
}
