using Dapper;
using Biletall.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletall.DataAccess.Concrete.Dapper.Repository
{
    public class TodoRepository
    {
        private readonly DapperContext _context;

        public TodoRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Todo>> GetList()
        {
            var query = "SELECT ID,Title,Description, CreatedDate,Satatus FROM Todos";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Todo>(query);
                return companies.ToList();
            }
        }

        public async Task<Todo> GetByID(int id)
        {
            var query = "SELECT * FROM Todos WHERE ID = @Id";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Todo>(query, new { id });

                return company;
            }
        }
        public async Task<Todo> Add(Todo todo)
        {
            var query = "INSERT INTO Todos (Title, Description, CreatedDate,Status) VALUES (@Title, @Description, @CreatedDate,@Status)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Title", todo.Title, DbType.String);
            parameters.Add("Description", todo.Description, DbType.String);
            parameters.Add("CreatedDate", todo.CreatedDate, DbType.DateTime);
            parameters.Add("Status", todo.Status, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdTodo = new Todo
                {
                    ID = id,
                    Title = todo.Title,
                    Description = todo.Description,
                    CreatedDate = todo.CreatedDate,
                    Status = todo.Status
                };

                return createdTodo;
            }
        }
        public async Task Update(Todo todo)
        {
            var query = "UPDATE Todos SET Title = @Title, Description = @Description, CreatedDate = @CreatedDate, Status=@Status WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", todo.ID);
            parameters.Add("Title", todo.Title, DbType.String);
            parameters.Add("Description", todo.Description, DbType.String);
            parameters.Add("CreatedDate", todo.CreatedDate, DbType.DateTime);
            parameters.Add("Status", todo.Status, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Delete(Todo todo)
        {
            var query = "DELETE FROM Todos WHERE ID = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { todo.ID });
            }
        }
    }
}
