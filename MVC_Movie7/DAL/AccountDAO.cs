using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAO
    {
        public List<AccountDM> ReadAccount(string statement,
            SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=MovieDB;
                Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataReader data = command.ExecuteReader();
                    List<AccountDM> accounts = new List<AccountDM>();
                    while (data.Read())
                    {
                        AccountDM account = new AccountDM();
                        account.id = Convert.ToInt32(data["id"]);
                        account.userId = Convert.ToInt32(data["userId"]);
                        account.movieId = Convert.ToInt32(data["movieId"]);
                        accounts.Add(account);
                    }
                    return accounts;
                }
            }
        }
        public void CreateAccount(AccountDM account)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId",account.userId),
                new SqlParameter("@MovieId",account.movieId)
            };
            dao.Write("CreateAccount", parameters);
        }
        public void DeleteAccount(int id)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            dao.Write("DeleteAccount", parameters);
        }
        public List<AccountDM> GetAllAccounts()
        {
            List<AccountDM> allAccounts = ReadAccount("GetAllAccounts", null);
            if (allAccounts != null)
            {
                return allAccounts;
            }
            else
            {
                allAccounts.Take(0).ToList();
                return allAccounts;
            }
        }
        public List<AccountDM> GetAccountById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id)
            };
            return ReadAccount("GetAccountById", parameters);
        }
        public void UpdateAccountDB(int id, int userId, int movieId)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@UserId", userId),
                new SqlParameter("@MovieId", movieId)
            };
            dao.Write("UpdateAccount", parameters);
        }
    }
}
