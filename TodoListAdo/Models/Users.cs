using Microsoft.Data.SqlClient;

namespace TodoListAdo.Models
{

    public interface IUsers
    {
        List<UsersDTO> DisplayUsers();

    }
    public class Users: IUsers
    {
        private readonly IConfiguration _configuration;
        private readonly string connection_source;
        public Users(IConfiguration configuration) 
        {
            _configuration= configuration;
            connection_source = _configuration["ConnectionStrings:ConnectionObj"];
        }





        public List<UsersDTO> DisplayUsers()
        {
            List<UsersDTO> users = new List<UsersDTO>();

            using (SqlConnection connect = new SqlConnection(connection_source))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("select * from Users", connect);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while(sqlDataReader.Read())
                {
                    int id = int.Parse(sqlDataReader["Id"].ToString());
                    string user = sqlDataReader["UserName"].ToString();
                    string pass = sqlDataReader["Password"].ToString();

                    users.Add(new UsersDTO
                    {
                        Id = id,
                        UserName= user,
                        Password= pass
                    });
                }
                return users;

            }

        }
    }
}
