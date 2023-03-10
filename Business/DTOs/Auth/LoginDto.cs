using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Auth;

public class LoginDto
{
	[Required]
	public string? UserNameOrEmail { get; set; }
	[Required,DataType(DataType.Password)]
	public string? Password { get; set; }
	public bool RememberMe { get; set; }

}
