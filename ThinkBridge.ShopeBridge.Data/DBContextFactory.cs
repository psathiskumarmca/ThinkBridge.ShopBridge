using System.Data.Entity;


namespace ThinkBridge.ShopBridge.Data
{
    public class DBContextFactory
    {
        public static DbContext GetDBContextInstance(string type)
        {
            switch (type.ToLower())
            {
                case "mail":
                    {
                        return null;
                    }
                default:
                    {
                        return new ShopBridgeEntities();
                    }
            }
        }
    }
}
