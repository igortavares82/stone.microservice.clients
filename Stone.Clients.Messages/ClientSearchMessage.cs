using Stone.Framework.Validator.Concretes;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Stone.Clients.Messages
{
    [DataContract(Namespace = "http://www.stone.com/charging/client/type")]
    public class ClientSearchMessage
    {
        [DataMember(Name = "cpf")]
        [Cpf(ErrorMessage = "invalid value")]
        [Required(ErrorMessage = "field is required")]
        public string Cpf { get; set; }
    }
}
