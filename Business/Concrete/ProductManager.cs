using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Constants;
using Core.Utilities.Results;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Caching;
using Business.BusinessAspects.Autofac;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        [SecuredOperation("Product.List,Admin")] // Authorization check
        [CacheAspect(duration:10)] // Cache for 60 seconds
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(filter: p => p.CategoryId == p.CategoryId).ToList());
        }

        //Cross Cutting Concerns - Validation, Cache, Logging, Transaction, Performance, Authorization
        //AOP - Aspect Oriented Programming


        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Add(Product product)
        {

            //Business codes
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

        [TransactionScopeAspect]
        public IResult TransactionOperation(Product product)
        {
            _productDal.Update(product);
            //_productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);

        }
    }
}