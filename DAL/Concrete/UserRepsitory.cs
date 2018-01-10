using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{




  public  class UserRepsitory
    {

    private readonly SqlConnection _con;

     public UserRepsitory(SqlConnection con )
      {
            
        _con = con;
     }

        public int Add (UserAdd userAdd)
        {
            int id=0;

            string query = "INSERT INTO Users "+
           "(Surname,[Name], Email, PasswordSalt,[Password]) "+
    " VALUES "+
          $" ('{userAdd.SurName}', '{userAdd.Name}', '{userAdd.Email}', '{userAdd.PasswordSalt}', '{userAdd.Password}'); ";
            using (SqlCommand command = new SqlCommand(query, _con))
            {
               
                int res = command.ExecuteNonQuery();
                if (res == 1)
                {
                    query = "SELECT SCOPE_IDENTITY() as UserId";
                    command.CommandText = query;
                   var reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        id = int.Parse(reader["UserId"].ToString());
                    }


                }
            }



            _con.Close();

            return id;
        }

        public void SetRole(UserRole ur)
        {
            string query = "INSERT INTO UserRoles " +
            "(UserId, RoleId) " +
             "VALUES " +
            $"({ur.UserId}, {ur.RoleId}) ";

            _con.Open();

            using (SqlCommand command = new SqlCommand(query, _con))
            {
                int res = command.ExecuteNonQuery();
                if (res != 1)
                {
                  //  помилка недоавилося
                }
            }

        }

        








    }



   
}
