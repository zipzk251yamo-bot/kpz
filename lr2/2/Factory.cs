namespace TechFactory.AbstractFactory
{
    class IProneFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new IProneLaptop("iLap Pro");
        public INetbook CreateNetbook() => null; 
        public IEBook CreateEBook() => null;
        public ISmartphone CreateSmartphone() => new IProneSmartphone("iProne 15");
    }

    class KiaomiFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new KiaomiLaptop("Mi Notebook");
        public INetbook CreateNetbook() => null;
        public IEBook CreateEBook() => null;
        public ISmartphone CreateSmartphone() => new KiaomiSmartphone("Redmi Note");
    }

        class BerdichevFactory : ITechFactory
    {
        public ILaptop CreateLaptop() => new BeLaptop("Ноутбук: Berdbook");
        public INetbook CreateNetbook() => null;
        public IEBook CreateEBook() => new BeBook("Книга: Історія Бердичева");
        public ISmartphone CreateSmartphone() => new BeSmartphone("Телефон: BerdPhone");
    }
}
