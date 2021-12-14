using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBridge.ShopBridge.Business.Helper;
using ThinkBridge.ShopBridge.Business.Repository;
using ThinkBridge.ShopBridge.DataAccess;
using ThinkBridge.ShopBridge.DataAccess.Factory;
using ThinkBridge.ShopBridge.DataAccess.Model;

namespace ThinkBridge.ShopBridge.Business.UOW
{
    public class UOWProduct : IUOWProduct, IDisposable
    {
        #region Properties
        public DbContext DbContext { get; set; }

        IRepository<Product> product;
        IRepository<ProductOffer> productOffer;
        public IRepository<Product> Product
        {
            get
            {
                if (product == null)
                {
                    product = new Repository<Product>(DbContext);
                }
                return product;
            }
        }

        public IRepository<ProductOffer> ProductOffer
        {
            get
            {
                if (productOffer == null)
                {
                    productOffer = new Repository<ProductOffer>(DbContext);
                }
                return productOffer;
            }
        }
        #endregion

        public UOWProduct()
        {
            CreateDbContext();
        }
        public UOWProduct(string type)
        {
            CreateDbContext(type);
        }


        protected void CreateDbContext(string type = "")
        {
            try
            {
                DbContext = DBContextFactory.GetDBContextInstance(type);

                // Do NOT enable proxied entities, else serialization fails.
                //if false it will not get the associated certification and skills when we
                //get the applicants
                //DbContext.Configuration.ProxyCreationEnabled = true;

                // Load navigation properties explicitly (avoid serialization trouble)
                //DbContext.Configuration.LazyLoadingEnabled = true;

                // Because Web API will perform validation, we don't need/want EF to do so
                //DbContext.Configuration.ValidateOnSaveEnabled = false;

                //DbContext.Configuration.AutoDetectChangesEnabled = false;
                // We won't use this performance tweak because we don't need 
                // the extra performance and, when autodetect is false,
                // we'd have to be careful. We're not being that careful :)
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                throw;
            }
        }

        public bool Commit()
        {
            try
            {
                return DbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                ExceptionLogger.Instance.Log(ex, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name, 9999);
                throw;
            }
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
        #endregion
    }
}

