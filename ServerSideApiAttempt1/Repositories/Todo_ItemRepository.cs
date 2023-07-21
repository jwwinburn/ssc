using Microsoft.Extensions.Configuration;
using ServerSideApiAttempt1.Models;
using ServerSideApiAttempt1.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ServerSideApiAttempt1.Repositories
{
    public class Todo_ItemRepository : BaseRepository, ITodo_ItemRepository
    {
        public Todo_ItemRepository(IConfiguration configuration) : base(configuration) { }
        public List<Todo_Items> GetTodo_ItemsByUserId(int userId)
{
    using (var conn = Connection)
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = @"
                SELECT Todo_Items.Id AS tdid, 
                Todo_Items.TaskName, 
                Todo_Category.Category, 
                Todo_Status.CurrentStatus
                FROM Todo_Items 
                JOIN Todo_Category ON Todo_Items.Todo_CategoryId = Todo_Category.Id
                JOIN Todo_Status ON Todo_Items.Todo_StatusId = Todo_Status.Id
                WHERE UsersId = @userId;
            ";

            DbUtils.AddParameter(cmd, "@userId", userId);
            using (SqlDataReader reader = cmd.ExecuteReader ())
            {
                var todoItems = new List<Todo_Items>();
                while (reader.Read ())
                {
                    todoItems.Add(new Todo_Items()
                    {
                        Id = DbUtils.GetInt(reader, "tdid"), // Corrected - Added Id property
                        TaskName = DbUtils.GetString(reader, "TaskName"),
                        Todo_Category = new Todo_Category // Corrected - Changed Todo_Categories to Todo_Category
                        {
                            Category = DbUtils.GetString(reader, "Category") // Corrected - Changed GetInt to GetString for Category
                        },
                        CurrentStatus = DbUtils.GetString(reader, "CurrentStatus") // Corrected - Changed GetInt to GetString for CurrentStatus
                    });
                }
                return todoItems;
            }
        } 
    }
}

    }
}
