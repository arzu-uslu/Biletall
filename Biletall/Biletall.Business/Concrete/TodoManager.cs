using Biletall.Business.Abstract;
using Biletall.DataAccess.Abstract;
using Biletall.Entities.Concrete;
using System.Collections.Generic;

namespace Biletall.Business.Concrete
{
    public class TodoManager : ITodoService
    {
        ITodoDal _todoDal;

        public TodoManager(ITodoDal todoDal)
        {
            _todoDal = todoDal;
        }

        public Todo Add(Todo addedTodo)
        {
            return _todoDal.Add(addedTodo);
        }

        public void Delete(Todo delTodo)
        {
            _todoDal.Delete(delTodo);
        }

        public IList<Todo> GetAll()
        {
            return _todoDal.GetList();
        }

        public Todo GetByID(int id)
        {
            return _todoDal.Get(x => x.ID == id);
        }

        public Todo Update(Todo updatedTodo)
        {
            return _todoDal.Update(updatedTodo);
        }
    }
}
