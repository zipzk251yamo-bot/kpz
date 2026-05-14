using System;

namespace DesignPatterns.Mediator
{
    class Aircraft
    {
        public string Name { get; private set; }
        private CommandCentre _mediator;

        public Aircraft(string name, CommandCentre mediator)
        {
            this.Name = name;
            this._mediator = mediator;
        }

        public void Land()
        {
            Console.WriteLine($"\n-> Літак {this.Name} запитує посадку.");
            _mediator.Notify(this, "Land");
        }

        public void TakeOff()
        {
            Console.WriteLine($"\n-> Літак {this.Name} запитує зліт.");
            _mediator.Notify(this, "TakeOff");
        }
    }
}