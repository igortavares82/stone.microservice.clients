namespace Stone.Clients.Models.Entities
{
    public class Client
    {
        public Client(){}

        public Client(string name, string state, string cpf)
        {
            Name = name;
            State = state;
            Cpf = cpf;
        }

        public string Name { get; private set; }
        public string State { get; private set; }
        public string Cpf { get; private set; }
    }
}
