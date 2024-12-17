using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {

        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref string ImagePath, ref int NationalityCountryID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string qurey = "SELECT * FROM [dbo].[People] where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(qurey, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader != null)
                {
                    if (reader.Read())
                    {
                        isFound = true;

                        NationalNo = (string)reader["NationalNo"];
                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];
                        if (reader["ThirdName"] != DBNull.Value)
                        {
                            ThirdName = (string)reader["ThirdName"];
                        }
                        else
                        {
                            ThirdName = "";
                        }
                        LastName = (string)reader["LastName"];
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                        Gendor = (byte)reader["Gendor"];
                        Phone = (string)reader["Phone"];
                        Email = (string)reader["Email"];
                        if (reader["ImagePath"] != DBNull.Value)
                        {
                            ImagePath = (string)reader["ImagePath"];
                        }
                        else
                        {
                            ImagePath = "";
                        }
                        if (reader["NationalityCountryID"] != DBNull.Value)
                        {
                            NationalityCountryID = (int)reader["NationalityCountryID"];
                        }
                        else
                        {
                            NationalityCountryID = -1;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }finally { 
                connection.Close(); 
            }


            return isFound;
        }

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref string ImagePath, ref int NationalityCountryID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string qurey = "SELECT * FROM [dbo].[People] where NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(qurey, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader != null)
                {
                    if (reader.Read())
                    {
                        isFound = true;

                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];
                        if (reader["ThirdName"] != DBNull.Value)
                        {
                            ThirdName = (string)reader["ThirdName"];
                        }
                        else
                        {
                            ThirdName = "";
                        }
                        LastName = (string)reader["LastName"];
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                        Gendor = (byte)reader["Gendor"];
                        Phone = (string)reader["Phone"];
                        if (reader["Email"] != DBNull.Value)
                        {
                            Email = (string)reader["Email"];
                        }
                        else
                        {
                            Email = "";
                        }
                        if (reader["ImagePath"] != DBNull.Value)
                        {
                            ImagePath = (string)reader["ImagePath"];
                        }
                        else
                        {
                            ImagePath = "";
                        }
                        
                        NationalityCountryID = (int)reader["NationalityCountryID"];
                        

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, string ImagePath, int NationalityCountryID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string qurey = "INSERT INTO [dbo].[People] ([NationalNo],[FirstName],[SecondName],[ThirdName],[LastName],[DateOfBirth],[Gendor],[Address],[Phone],[Email],[ImagePath],[NationalityCountryID]) " +
                "VALUES(@NationalNo ,@FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone , @Email, @ImagePath, @NationalityCountryID);" +
                "select Max(PersonID) from People;";

            SqlCommand command = new SqlCommand(qurey, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            try
            {
                connection.Open();

                int PersonID = (int)command.ExecuteScalar();

                if (PersonID > 0)
                {
                    ID = PersonID;
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }finally { 

                connection.Close(); 
            }

            return ID;
        }

        public static bool UpdatePersonInfo(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, string ImagePath, int NationalityCountryID)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string qurey = "UPDATE [dbo].[People]"
                            + " SET [NationalNo]  = @NationalNo  "
                            + "    ,[FirstName]   = @FirstName   "
                            + "    ,[SecondName]  = @SecondName  "
                            + "    ,[ThirdName]   = @ThirdName   "
                            + "    ,[LastName]    = @LastName    "
                            + "    ,[DateOfBirth] = @DateOfBirth "
                            + "    ,[Gendor]      = @Gendor      "
                            + "    ,[Address]     = @Address     "
                            + "    ,[Phone]       = @Phone       "
                            + "    ,[Email]       = @Email       "
                            + "    ,[ImagePath] = @ImagePath     "
                            + "    ,[NationalityCountryID] = @NationalityCountryID "
                          + " WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(qurey, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            try
            {
                connection.Open();

                int rowAffected = (int)command.ExecuteNonQuery();

               if (rowAffected > 0)
                {
                    isUpdated = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }

        public static bool DeletePerson(int PersonID)
        {
            bool isDeleted = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string Qurey = "DELETE FROM [dbo].[People] WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Qurey, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {

                connection.Open();

                int rowAffected = (int)command.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    isDeleted = true;
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isDeleted;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string Qurey = "select isFound = 'Yes' from People where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Qurey, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object obj = command.ExecuteScalar();

                if (obj != null)
                {
                    isFound = true;
                }

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string Qurey = "select isFound = 'Yes' from People where NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(Qurey, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                object obj = command.ExecuteScalar();

                if (obj != null)
                {
                    isFound = true;
                }

            }
            catch (Exception ex) {
                Console.WriteLine(); 

            }
            finally { 
                connection.Close(); 

            }

            return isFound;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);

            string Qurey = "SELECT People.[PersonID],People.[NationalNo],People.[FirstName],People.[SecondName],People.[ThirdName],People.[LastName],People.[DateOfBirth], case when People.Gendor = 0 then 'Male' else 'Female' end as Gendor,People.[Address],People.[Phone],People.[Email],People.[ImagePath], Countries.CountryName " +
                           "FROM [dbo].[People] " +
                           "left join Countries ON " +
                           "People.NationalityCountryID = Countries.CountryID  order  by FirstName ;";

            SqlCommand command = new SqlCommand(Qurey, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader != null)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex);

            }
            finally { 
                connection.Close(); 

            }

            return dt;
        }


    }
}
