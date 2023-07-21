using Microsoft.Extensions.Configuration;
using ServerSideApiAttempt1.Models;
using ServerSideApiAttempt1.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ServerSideApiAttempt1.Repositories
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UsersRepository(IConfiguration configuration) : base(configuration) { }

        public Users GetByFirebaseUserId(string firebaseUserid)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT up.Id, up.FirebaseUserId, up.FirstName, up.LastName, up.Zipcode, 
                               up.Email
                          FROM Users up
                         WHERE FirebaseUserId = @FirebaseuserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserid);

                    Users user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new Users()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            Zipcode = DbUtils.GetInt(reader, "Zipcode")
                        };
                    }
                    reader.Close();

                    return user;
                }
            }
        }
    }
}
