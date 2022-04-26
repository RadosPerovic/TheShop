namespace TheShop.Core.Application
{
    public static class Messages
    {
        public const string CustomerNotFound = "There is no customer with Id: {0}";
        public const string ArticleNotFound = "There is no article in the shop with Id: {0}";
        public const string FilteredArticleNotFound = "There is no article with quantity {0}, or with price lower than: {1}";
        public const string SuppliersNotFound = "There is no suppliers";
        public const string ExternalServiceNotFound = "There is no external service for Supplier with Id: {0},  Name: {1}";
        public const string ExternalArticleNotFound = "There is no artical with Id: {0} from supplier Id: {1}";
        public const string OrderNotFound = "There is no order with Id: {0}";
    }
}
