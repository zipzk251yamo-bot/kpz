namespace TechFactory.AbstractFactory
{
    interface ITechFactory
    {
        public ILaptop CreateLaptop();
        public INetbook CreateNetbook();
        public IEBook CreateEBook();
        public ISmartphone CreateSmartphone();
    }
}