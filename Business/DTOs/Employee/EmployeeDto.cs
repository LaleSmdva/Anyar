using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Employee;

public class EmployeeDto
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Position { get; set; }
	public string? Description { get; set; }
	public string? Image { get; set; }
}
