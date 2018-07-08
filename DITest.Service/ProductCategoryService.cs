using DITest.Data.Infrastructure;
using DITest.Data.Repositories;
using DITest.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DITest.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);

        void Update(ProductCategory productCategory);

        ProductCategory Delete(int id);

        List<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string keyword);

        IEnumerable<ProductCategory> GetAllByParentId(int parentId);

        ProductCategory GetById(int id);

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory ProductCategory)
        {
            return _productCategoryRepository.Add(ProductCategory);
        }

        public ProductCategory Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public List<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll().ToList(); ;
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public ProductCategory GetById(int id)
        {
            ProductCategory productCategory= _productCategoryRepository.GetSingleById(id);
            return productCategory;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(ProductCategory ProductCategory)
        {
            _productCategoryRepository.Update(ProductCategory);
        }
    }
}