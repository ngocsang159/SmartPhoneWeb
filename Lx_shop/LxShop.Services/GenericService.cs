using LxShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxShop.Services
{
    public class GenericService<T> where T : class
    {
        protected readonly IAccountAdminRepository _AccountAdminRepository;
        protected readonly IProduct_categoryRepository _ProductCategoryRepository;
        protected readonly IProduct_Category_TypeRepository _ProductCategoryTypeRepository;
        protected readonly IBrandRepository _BrandRepository;
        protected readonly IProductRepository _ProductRepository;
        protected readonly IBannerRepository _BannerRepository;
        protected readonly ICustomerRepository _CustomerRepository;
        protected readonly IOrderRepository _OrderRepository;
        protected readonly IProduct_ColorRepository _ProductColorRepository;
        protected readonly IProduct_imageRepository _ProductImageRepository;
        protected readonly IProduct_SpecificationRepository _ProductSpecificationRepository;
        

        public GenericService()
        {
            
            _AccountAdminRepository = new AccountAdminRepository();
            _ProductCategoryRepository = new Product_categoryRepository();
            _ProductCategoryTypeRepository = new Product_Category_TypeRepository();
            _BrandRepository = new BrandRepository();
            _ProductRepository = new ProductRepository();
            _BannerRepository = new BannerRepository();
            _CustomerRepository = new CustomerRepository();
            _OrderRepository = new OrderRepository();
            _ProductColorRepository = new Product_ColorRepository();
            _ProductImageRepository = new Product_imageRepository();
            _ProductSpecificationRepository = new Product_SpecificationRepository();
        }

    }
}
