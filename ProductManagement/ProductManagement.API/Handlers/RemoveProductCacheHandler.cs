using MediatR;
using PM.Core.Caching;
using PM.Services.Catalog;
using ProductManagement.API.Commands;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.API.Handlers
{
    public class RemoveProductCacheHandler : INotificationHandler<RemoveProductCacheCommand>
    {
        private readonly ICacheService _cache;
        private readonly IProductService _productService;

        public RemoveProductCacheHandler(
            ICacheService cache,
            IProductService productService
        )
        {
            _cache = cache;
            _productService = productService;
        }

        public async Task Handle(RemoveProductCacheCommand notification, CancellationToken cancellationToken)
        {
            //Remove all cache of product
            var allProductCacheKeys = _cache.FindKeysByPrefix("PM.Services.Product.");
            if (allProductCacheKeys.Any())
            {
                foreach (var item in allProductCacheKeys)
                {
                    _cache.Remove(item);
                }
            }

            //Optional cache again after remove cache
            await _productService.GetAllProducts();
        }
    }
}
