using System;

namespace ServerSideApiAttempt1.Models
{
    public class Todo_Items
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int UsersId { get; set; }
        public int CategoryId { get; set; }
    }
}
