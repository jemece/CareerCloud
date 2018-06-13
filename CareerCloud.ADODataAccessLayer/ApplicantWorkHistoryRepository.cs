﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Linq.Expressions;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantWorkHistoryRepository :BaseADO, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection _connection = new SqlConnection(_connString);
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                foreach(ApplicantWorkHistoryPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Work_History]
                                                        (
                                                           [Id]
                                                          ,[Applicant]
                                                          ,[Company_Name]
                                                          ,[Country_Code]
                                                          ,[Location]
                                                          ,[Job_Title]
                                                          ,[Job_Description]
                                                          ,[Start_Month]
                                                          ,[Start_Year]
                                                          ,[End_Month]
                                                          ,[End_Year]
                                                        )
                                                        VALUES
                                                        (
                                                           @Id
                                                          ,@Applicant
                                                          ,@Company_Name
                                                          ,@Country_Code
                                                          ,@Location
                                                          ,@Job_Title
                                                          ,@Job_Description
                                                          ,@Start_Month
                                                          ,@Start_Year
                                                          ,@End_Month
                                                          ,@End_Year
                                                        )";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", poco.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);

                    _connection.Open();
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                }

            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            ApplicantWorkHistoryPoco[] result = new ApplicantWorkHistoryPoco[1000];
            SqlConnection _connection = new SqlConnection(_connString);
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "SELECT * from Applicant_Work_History";

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int p = 0;
                while (reader.Read())
                {
                    ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.CompanyName = reader.GetString(2);
                    poco.CountryCode = reader.GetString(3);
                    poco.Location = reader.GetString(4);
                    poco.JobTitle = reader.GetString(5);
                    poco.JobDescription = reader.GetString(6);
                    poco.StartMonth = reader.GetInt16(7);
                    poco.StartYear = reader.GetInt32(8);
                    poco.EndMonth = reader.GetInt16(9);
                    poco.EndYear = reader.GetInt32(10);
                    poco.TimeStamp = (byte[])reader["Time_Stamp"];

                    result[p] = poco;
                    p++;
                }
                _connection.Close();
            }

            return result.Where(t => t != null).ToList();
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection _connection = new SqlConnection(_connString);
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                foreach(ApplicantWorkHistoryPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Work_History]
                                                      WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection _connection = new SqlConnection(_connString);
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                foreach(ApplicantWorkHistoryPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Work_History]
                                                 SET [Applicant] = @Applicant
                                                    ,[Company_Name] = @Company_Name
                                                    ,[Country_Code] = @Country_Code
                                                    ,[Location] = @Location
                                                    ,[Job_Title] = @Job_Title
                                                    ,[Job_Description] = @Job_Description
                                                    ,[Start_Month] = @Start_Month
                                                    ,[Start_Year] = @Start_Year
                                                    ,[End_Month] = @End_Month
                                                    ,[End_Year] = @End_Year
                                               WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", poco.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);

                    _connection.Open();
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }
    }
}
