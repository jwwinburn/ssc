using System.Collections.Generic;
using ServerSideApiAttempt1.Models;

namespace ServerSideApiAttempt1.Repositories
{
    public interface ITodo_ItemRepository
    {
        List<Todo_Items> GetTodo_ItemsByUserId(int userId);
    }
}