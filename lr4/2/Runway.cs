using System;

namespace DesignPatterns.Mediator
{
    class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        private CommandCentre _mediator;
        public bool IsBusy { get; private set; } = false;

        public Runway(CommandCentre mediator)
        {
            this._mediator = mediator;
        }

        public void SetBusyStatus(bool isBusy)
        {
            this.IsBusy = isBusy;
            if (this.IsBusy)
            {
                HighLightRed();
            }
            else
            {
                HighLightGreen();
            }
        }

        public void HighLightRed()
        {
            Console.WriteLine($"   [Смуга {this.Id.ToString().Substring(0, 5)}...]: Горить ЧЕРВОНИЙ (зайнято)!");
        }

        public void HighLightGreen()
        {
            Console.WriteLine($"   [Смуга {this.Id.ToString().Substring(0, 5)}...]: Горить ЗЕЛЕНИЙ (вільно)!");
        }
    }
}