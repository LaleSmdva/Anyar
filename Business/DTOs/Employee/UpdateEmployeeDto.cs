using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Employee;

public class UpdateEmployeeDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public string? Description { get; set; }
    public IFormFile? Image { get; set; }
}
