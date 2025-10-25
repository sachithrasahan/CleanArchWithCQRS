namespace Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }


        public Customer(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }


        // parameterless for serializers
        private Customer() { }


        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
