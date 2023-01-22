using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.ProductAPI.DbContexts;
using Restaurant.Services.ProductAPI.Models;
using Restaurant.Services.ProductAPI.Models.Dto;

namespace Restaurant.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            Product productFind = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productDto.ProductId);

            if (productFind != null)
            {
                _context.Products.Update(product);
            }
            else
            {
                _context.Products.Add(product);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            try
            {
                Product product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                if (product == null)
                {
                    return false;
                }

                _context.Products.Remove(product);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(Guid productId)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
