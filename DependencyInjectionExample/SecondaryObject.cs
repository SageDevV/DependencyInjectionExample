namespace DependencyInjectionExample
{
    public class SecondaryObject
    {
        private readonly PrimaryObject _primaryObject;
        public SecondaryObject(PrimaryObject primaryObject)
        => _primaryObject = primaryObject;

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PrimaryObjectId => _primaryObject.Id;
    }
}




