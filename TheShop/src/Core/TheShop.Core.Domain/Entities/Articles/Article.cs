
using TheShop.Core.Domain.Common;

namespace TheShop.Core.Domain.Entities.Articles
{
    public class Article : Entity
    {
        private string _name;
        private string _description;

        protected Article(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Article Create(string name, string description) =>
            new Article(name, description);

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

        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                CommonGuard.StringLenghtLessThanOrEqualTo(value, 100);
                _description = value;
            }
        } 
    }
}
