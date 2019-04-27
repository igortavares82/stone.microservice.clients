namespace Stone.Clients.Models.Entities
{
    public class Client
    {
        public Client(){}

        public Client(string name, string state, string cpf)
        {
            Name = name;
            State = state;
            Cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
        }

        public string Name { get; set; }
        public string State { get; set; }
        public string Cpf { get; set; }
    }
}
