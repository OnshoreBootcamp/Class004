using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class PersonDAO
    {
        public List<PersonDM> ReadPerson(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=MovieDB;Integrated Security=SSPI;"))
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
                    List<PersonDM> people = new List<PersonDM>();
                    while (data.Read())
                    {
                        PersonDM person = new PersonDM();
                        person.id = Convert.ToInt32(data["id"]);
                        person.lastName = data["lastName"].ToString();
                        person.firstName = data["firstName"].ToString();
                        person.email = data["email"].ToString();
                        people.Add(person);
                    }
                    return people;
                }
            }
        }
        public PersonDM GetPerson(int id)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id",id)
                };
                return ReadPerson("GetPersonById", parameters).SingleOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int GetPersonId(string lastName, string firstName, string email)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@LastName",lastName),
                    new SqlParameter("@FirstName",firstName),
                    new SqlParameter("@Email",email)
                };
                return ReadPerson("GetPersonId",
                    parameters).SingleOrDefault().id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public void CreatePerson(string lastName, string firstName, string email)
        {
            DAO dao = new DAO();
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@LastName",lastName),
                    new SqlParameter("@FirstName",firstName),
                    new SqlParameter("@Email",email)
                };
            dao.Write("CreatePerson", parameters);
        }
        public bool DoesPersonExist(int id)
        {
            if (id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}