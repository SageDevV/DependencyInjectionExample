namespace DependencyInjectionExample
{
    public class TertiaryObject
    {
        private readonly PrimaryObject _primaryObject;
        private readonly SecondaryObject _secondaryObject;
        private readonly SecondaryObject _secondaryObjectNewInstance;
        public TertiaryObject(PrimaryObject primaryObject, SecondaryObject secondaryObject, SecondaryObject secondaryObjectNewInstance)
        {
            _primaryObject = primaryObject;
            _secondaryObject = secondaryObject;
            _secondaryObjectNewInstance = secondaryObjectNewInstance;
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PrimaryObjectId => _primaryObject.Id;
        public Guid SecondaryObjectId => _secondaryObject.Id;
        public Guid SecondaryObjectNewInstance => _secondaryObjectNewInstance.Id;
    }
}
