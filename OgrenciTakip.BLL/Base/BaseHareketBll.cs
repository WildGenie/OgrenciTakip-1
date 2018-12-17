﻿

using OgrenciTakip.BLL.Functions;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.DAL.Interfaces;
using OgrenciTakip.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OgrenciTakip.BLL.Base
{
    public class BaseHareketBll<T, TContext> : IBaseBll where T : BaseHareketEntity where TContext : DbContext
    {
        #region Variables
        private IUnitOfWork<T> _uow;
        #endregion

        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            GeneralFunctions.CreateOfUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Select(filter, selector);
        }

        protected bool Insert(IList<BaseHareketEntity> entitites)
        {
            GeneralFunctions.CreateOfUnitOfWork<T, TContext>(ref _uow);
            _uow.Rep.Insert(entitites.EntityListConvert<T>());
            return _uow.Save();
        }

        protected bool Update(IList<BaseHareketEntity> entitites)
        {
            GeneralFunctions.CreateOfUnitOfWork<T, TContext>(ref _uow);

            _uow.Rep.Update(entitites.EntityListConvert<T>());
            return _uow.Save();
        }

        protected bool Delete(IList<BaseHareketEntity> entitites)
        {
            GeneralFunctions.CreateOfUnitOfWork<T, TContext>(ref _uow);

            _uow.Rep.Delete(entitites.EntityListConvert<T>());
            return _uow.Save();
        }

        #region Dispose

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
        #endregion
    }
}
