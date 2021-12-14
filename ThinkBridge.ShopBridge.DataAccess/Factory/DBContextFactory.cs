

using Microsoft.EntityFrameworkCore;

namespace ThinkBridge.ShopBridge.DataAccess.Factory
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
                        return new ShopBridgeDbContext();
                    }
            }
        }
    }
}
