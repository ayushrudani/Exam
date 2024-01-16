using APIDemo.DAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
	[ApiController]
	[Route("api/student")]
	public class EmployeeController : Controller
	{
		[HttpGet]
		public IActionResult Get()
		{
			Employee_DALBase student = new Employee_DALBase();
			List<EmployeeModel> students = student.GetAll();

			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
			if (students.Count > 0 && students != null)
			{
				response.Add("status", true);
				response.Add("message", "Data Found.");
				response.Add("data", students);
				return Ok(response);
			}
			else
			{
				response.Add("status", false);
				response.Add("message", "Data Not Found.");
				response.Add("data", null);
				return NotFound(response);
			}

		}


		[HttpGet("UserID")]
		public IActionResult GetById(int UserID)
		{
			Employee_DALBase student = new Employee_DALBase();
			EmployeeModel studentById = student.GetByID(UserID);

			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
			if (studentById != null)
			{
				response.Add("status", true);
				response.Add("message", "Data Found.");
				response.Add("data", studentById);
				return Ok(response);
			}
			else
			{
				response.Add("status", false);
				response.Add("message", "Data Not Found.");
				response.Add("data", null);
				return NotFound(response);
			}
		}


		[HttpPost]
		public IActionResult Post(EmployeeModel studentModel)
		{
			Employee_DALBase studentDAL = new Employee_DALBase();

			bool insertionResult = studentDAL.Insert(studentModel);

			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
			if (insertionResult)
			{
				response.Add("status", true);
				response.Add("message", "Student inserted successfully.");
				return Ok(response);
			}
			else
			{
				response.Add("status", false);
				response.Add("message", "Failed to insert student.");
				return StatusCode(500, response);
			}
		}


		[HttpPut]
		public IActionResult Put(int id, [FromForm] EmployeeModel updatedStudent)
		{
			Employee_DALBase studentDAL = new Employee_DALBase();
			bool updateResult = studentDAL.Update(id, updatedStudent);

			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
			if (updateResult)
			{
				response.Add("status", true);
				response.Add("message", "Student updated successfully.");
				return Ok(response);
			}
			else
			{
				response.Add("status", false);
				response.Add("message", "Failed to update student.");
				return StatusCode(500, response);
			}
		}

		[HttpDelete("id")]
		public IActionResult DeleteStudent(int id)
		{
			Employee_DALBase studentDAL = new Employee_DALBase();

			bool deleteResult = studentDAL.Delete(id);

			Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
			if (deleteResult)
			{
				response.Add("status", true);
				response.Add("message", "Student deleted successfully.");
				return Ok(response);
			}
			else
			{
				response.Add("status", false);
				response.Add("message", "Failed to delete student.");
				return StatusCode(500, response);
			}
		}


	}
}
