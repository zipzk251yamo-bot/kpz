namespace TechFactory.AbstractFactory
{
    // Бренд IProne
    class IProneLaptop : ILaptop {
        public string Model { get; private set; }
        public IProneLaptop(string model) => Model = model;
    }
    class IProneSmartphone : ISmartphone {
        public string Model { get; private set; }
        public IProneSmartphone(string model) => Model = model;
    }

    // Бренд Kiaomi
    class KiaomiLaptop : ILaptop {
        public string Model { get; private set; }
        public KiaomiLaptop(string model) => Model = model;
    }
    class KiaomiSmartphone : ISmartphone {
        public string Model { get; private set; }
        public KiaomiSmartphone(string model) => Model = model;
    }
    

    // Бренд Berdichev
    class BeLaptop : ILaptop {
        public string Model { get; private set; }
        public BeLaptop(string model) => Model = model;
    }
    class BeSmartphone : ISmartphone {
        public string Model { get; private set; }
        public BeSmartphone(string model) => Model = model;
    }
    
    class BeBook : IEBook {
        public string Model { get; private set; }
        public BeBook(string model) => Model = model;
    }
   
}