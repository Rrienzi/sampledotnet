using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.DataAccess
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly string _connString;
        
        public UserDetailsRepository(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("myConnection");
        }
        public async Task DeleteUserDetail(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DeleteUserDetail", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return;
                }
            }
        }

        public async Task<List<UserDetails>> GetAllUserDetails()
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllUserDetails", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<UserDetails>();
                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    return response;
                }
            }
        }

        private UserDetails MapToValue(SqlDataReader reader)
        {
            return new UserDetails
            {
                Id = (int)reader["id"],
                FirstName = reader["firstname"].ToString(),
                LastName = reader["lastname"].ToString(),
                Address = reader["address"].ToString(),
                Email = reader["email"].ToString(),
            };
        }


/*        private UserDetails viewModel(SqlDataReader reader)
        {
            return new UserDetails
            {
                Id = (int)reader["id"],
                FirstName = reader["firstname"].ToString(),
                LastName = reader["lastname"].ToString(),
                Address = reader["address"].ToString(),
                Email = reader["email"].ToString(),
                Fid = (int)reader["fId"],
                FfirstName = reader["fFirstName"].ToString(),
                FlastName = reader["fLastName"].ToString(),
                IsActive = (bool)reader["isActive"],
                UserId = (int)reader["userId"]
            };
        }*/

        public async Task<UserDetails> GetUserDetailById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetUserDetailById", conn))
                {
                    
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    UserDetails response = null;

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }

                        return response;
                    }
                }
            }
        }

        public async Task InsertUserDetail(UserDetails userDetails)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertUserDetail", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure; 
                    cmd.Parameters.Add(new SqlParameter("@firstname", userDetails.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastname", userDetails.LastName));
                    cmd.Parameters.Add(new SqlParameter("@address", userDetails.Address));
                    cmd.Parameters.Add(new SqlParameter("@email", userDetails.Email));

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return;

                }
            }
        }

        public async Task UpdateUserDetail(UserDetails userDetails, int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateUserDetail", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    cmd.Parameters.Add(new SqlParameter("@firstname", userDetails.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastname", userDetails.LastName));
                    cmd.Parameters.Add(new SqlParameter("@address", userDetails.Address));
                    cmd.Parameters.Add(new SqlParameter("@email", userDetails.Email));
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return;
                }
            }
        }

         public async Task<UserDetails> GetUserFriendsById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetUserFriendsById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    UserDetails response = null;

                    await conn.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }

                        return response;
                    }
                }
            }
        }
    }
}
