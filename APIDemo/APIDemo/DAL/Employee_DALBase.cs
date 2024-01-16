using System.Data;
using System.Data.Common;
using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
namespace APIDemo.DAL
{
	public class Employee_DALBase : DAL_Helpers
	{
		public List<EmployeeModel> GetAll()
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("GetAllEmployees");
				List<EmployeeModel> employeeModels = new List<EmployeeModel>();
				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					while (dr.Read())
					{
						EmployeeModel employeeModel = new EmployeeModel();
						employeeModel.EmployeeId = Convert.ToInt32(dr["EmployeeId"].ToString());
						employeeModel.EmployeeName = dr["EmployeeName"].ToString();
						employeeModel.EmpCode = dr["EmpCode"].ToString();
						employeeModel.Email = dr["Email"].ToString();
						employeeModel.Contact = dr["Contact"].ToString();
						employeeModel.Salary = dr["Salary"].ToString();
						employeeModels.Add(employeeModel);
					}
				}
				Console.WriteLine("Data Done");
				return employeeModels;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}

		public EmployeeModel GetByID(int employeeId)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("GetEmployeeById");
				sqlDatabase.AddInParameter(dbCommand, "@EmployeeId", DbType.Int32, employeeId);

				using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
				{
					if (dr.Read())
					{
						EmployeeModel employeeModel = new EmployeeModel
						{
							EmployeeId = Convert.ToInt32(dr["EmployeeId"].ToString()),
							EmployeeName = dr["EmployeeName"].ToString(),
							EmpCode = dr["EmpCode"].ToString(),
							Email = dr["Email"].ToString(),
							Contact = dr["Contact"].ToString(),
							Salary = dr["Salary"].ToString()
						};
						return employeeModel;
					}
				}

				Console.WriteLine("Data Done");
				return null; // Return null if no record found
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error in GetByID: " + ex.Message);
				// Log the exception or rethrow it if needed
				return null;
			}
		}


		public bool Insert(EmployeeModel employeeModel)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("InsertEmployee");

				// Add parameters for the stored procedure
				sqlDatabase.AddInParameter(dbCommand, "@EmployeeName", DbType.String, employeeModel.EmployeeName);
				sqlDatabase.AddInParameter(dbCommand, "@EmpCode", DbType.String, employeeModel.EmpCode);
				sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, employeeModel.Email);
				sqlDatabase.AddInParameter(dbCommand, "@Contact", DbType.String, employeeModel.Contact);
				sqlDatabase.AddInParameter(dbCommand, "@Salary", DbType.String, employeeModel.Salary);

				int rowsAffected = sqlDatabase.ExecuteNonQuery(dbCommand);
				return rowsAffected > 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error in Insert: " + ex.Message);
				// Log the exception or rethrow it if needed
				return false;
			}
		}
		public bool Update(int Id, EmployeeModel employeeModel)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("UpdateEmployee");

				// Add parameters for the stored procedure
				sqlDatabase.AddInParameter(dbCommand, "@EmployeeId", DbType.Int32, Id);
				sqlDatabase.AddInParameter(dbCommand, "@EmployeeName", DbType.String, employeeModel.EmployeeName);
				sqlDatabase.AddInParameter(dbCommand, "@EmpCode", DbType.String, employeeModel.EmpCode);
				sqlDatabase.AddInParameter(dbCommand, "@Email", DbType.String, employeeModel.Email);
				sqlDatabase.AddInParameter(dbCommand, "@Contact", DbType.String, employeeModel.Contact);
				sqlDatabase.AddInParameter(dbCommand, "@Salary", DbType.String, employeeModel.Salary);

				int rowsAffected = sqlDatabase.ExecuteNonQuery(dbCommand);
				return rowsAffected > 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error in Update: " + ex.Message);
				// Log the exception or rethrow it if needed
				return false;
			}
		}

		public bool Delete(int employeeId)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
				DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("DeleteEmployee");

				// Add parameters for the stored procedure
				sqlDatabase.AddInParameter(dbCommand, "@EmployeeId", DbType.Int32, employeeId);

				int rowsAffected = sqlDatabase.ExecuteNonQuery(dbCommand);
				return rowsAffected > 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error in Delete: " + ex.Message);
				// Log the exception or rethrow it if needed
				return false;
			}
		}


	}
}
