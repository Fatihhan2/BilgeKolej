using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace CoreTier
{
    public interface ICoreService<T> where T : CoreEntity
    {
        string Create(T model);
        string Create(List<T> model);

        List<T> GetList();

        T GetById(Guid id);

        string Update(T model);

        string Delete(T model);

        string ChangeEducetion(T model,CoreTier.Enum.Status status);

        bool Any(Expression<Func<T, bool>> exp);

        
    }
}
