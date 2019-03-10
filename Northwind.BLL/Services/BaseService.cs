using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Domain;
using Northwind.DAL.Interfaces;
using Northwind.DAL.Repository;
using Northwind.Domain.ViewModel;
using AutoMapper;
using Northwind.BLL.Abstract;

namespace Northwind.BLL.Services
{
  public class BaseService<Model, ViewModel> where Model : class where ViewModel : class
  {
    private IRepository<Model> db;

    public BaseService()
    {
      db = new GenericRepository<Model>();
    }

    public List<ViewModel> Get()
    {
      var entity = db.Get().ToList();
      return Mapper.Map<List<Model>, List<ViewModel>>(entity);
    }

    public void Add(ViewModel models)
    {
      var entity = Mapper.Map<ViewModel, Model>(models);
      db.Insert(entity);
    }

    public void Save(ViewModel models)
    {
      var entity = Mapper.Map<ViewModel, Model>(models);
      db.Update(entity);
    }

    public void Delete(string EntityID)
    {
      var entity = db.GetByID(EntityID);
      db.Delete(entity);
    }
  }
}