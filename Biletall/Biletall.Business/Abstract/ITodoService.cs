using Biletall.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletall.Business.Abstract
{
    public interface ITodoService
    {
        IList<Todo> GetAll();
        Todo Add(Todo addedTodo);
        void Delete(Todo deletedTodo);
        Todo Update(Todo updatedTodo);
        Todo GetByID(int id);

    }
}
