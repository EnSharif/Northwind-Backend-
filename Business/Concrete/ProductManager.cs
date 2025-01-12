using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        public IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SucessDataResult<Product>(_productDal.Get(p => p.ProductId == productId)) ;
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SucessDataResult<List<Product>>( _productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SucessDataResult<List<Product>> (_productDal.GetList(filter: p => p.CategoryId == categoryId).ToList());
        }
        // Magig string
        // Business codes
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}

