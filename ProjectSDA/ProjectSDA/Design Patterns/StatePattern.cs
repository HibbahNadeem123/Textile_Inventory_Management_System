using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSDA.Design_Patterns
{
    public class StatePattern
    {
        static void Main()
        {
            // Setup ProductDp in a state

            ProductDp c = new ProductDp(new AvailableStock(), 3);

            // Issue requests, which toggles state

            c.Request();
            c.Request();
            c.Request();
            c.Request();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'State' abstract class

    /// </summary>

    abstract class State

    {
        public abstract void Handle(ProductDp ProductDp);
    }

    /// <summary>

    /// A 'ConcreteState' class

    /// </summary>

    class AvailableStock : State

    {
        public override void Handle(ProductDp ProductDp)
        {
            if (ProductDp.qty <= 0)
            {
                ProductDp.State = new NotInStock();
            }

        }
    }

    /// <summary>

    /// A 'ConcreteState' class

    /// </summary>

    class NotInStock : State

    {
        public override void Handle(ProductDp ProductDp)
        {
            if (ProductDp.qty <= 0)
            {
                ProductDp.State = new AvailableStock();
            }
        }
    }

    /// <summary>

    /// The 'ProductDp' class

    /// </summary>

    class ProductDp
    {
        private State _state;
        public int qty;
        // Constructor

        public ProductDp(State state, int q)
        {
            this.State = state;
            qty = q;
        }

        // Gets or sets the state

        public State State
        {
            get { return _state; }
            set

            {
                _state = value;
                Console.WriteLine("State: " +
                  _state.GetType().Name);
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}