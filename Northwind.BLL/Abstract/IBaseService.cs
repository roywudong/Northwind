using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Abstract
{
  public interface IBaseService<Model, ViewModel, Keytype>
    where Model : class
    where ViewModel : class
  {
    List<ViewModel> Get();

    void Add(ViewModel models);

    void Save(ViewModel models);

    void Delete(Keytype EntityID);
  }
}