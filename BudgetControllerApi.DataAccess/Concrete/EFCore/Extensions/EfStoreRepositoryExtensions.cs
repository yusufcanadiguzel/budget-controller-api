using BudgetControllerApi.Entities.Concrete;

namespace BudgetControllerApi.DataAccess.Concrete.EFCore.Extensions
{
    public static class EfStoreRepositoryExtensions
    {
        public static IQueryable<Store> Search(this IQueryable<Store> stores, string searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
                return stores;

            var loweredTerm = searchTerm.Trim().ToLower();

            return stores.Where(s => s.Name.ToLower().Contains(loweredTerm));
        }
    }
}
