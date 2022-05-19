using ProductsAPI.DBContexts;
using ProductsAPI.Model;
using ProductsAPI.Model.Entity;
using ProductsAPI.Modules.ProductModule.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Modules.ProductModule.Helper
{
    public class ProductHelper : IProductHelper
    {
        public bool ChangeProductStatus(int productId, ProductStatuses oldStatus, ProductStatuses newStatus, ProductContext dbContext)
        {
            var entityOld = dbContext.ProductStatusDetail.FirstOrDefault(x => x.ProductId == productId && x.ProductStatusId == (int)oldStatus);
            var entityNew = dbContext.ProductStatusDetail.FirstOrDefault(x => x.ProductId == productId && x.ProductStatusId == (int)newStatus);

            if (entityOld != null)
            {
                entityOld.Quantity -= 1;
                dbContext.ProductStatusDetail.Update(entityOld);
                Save(dbContext);
                dbContext.Entry(entityOld).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                if (entityNew != null)
                {
                    entityNew.Quantity += 1;
                    dbContext.ProductStatusDetail.Update(entityNew);
                    Save(dbContext);
                    dbContext.Entry(entityNew).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }

            return dbContext.ChangeTracker.HasChanges();
        }

        private void Save(ProductContext dbContext)
        {
            dbContext.SaveChanges();
        }
    }
}
