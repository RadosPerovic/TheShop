
using TheShop.Core.Domain.Common;

namespace TheShop.Core.Domain.Entities.Customers
{
    public class Customer : Entity
    {
        private string _name;
        private string _surname;
        private string _email;

        private Customer(string name,
            string surname,
            string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public static Customer Create(string name,
            string surname,
            string email)
        {
            return new Customer(name, surname, email);
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                CommonGuard.StringLenghtLessThanOrEqualTo(value, 50);
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            private set
            {
                CommonGuard.StringLenghtLessThanOrEqualTo(value, 50);
                _surname = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                CommonGuard.StringLenghtLessThanOrEqualTo(value, 100);
                _email = value;
            }
        }
    }
}
