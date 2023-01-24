using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations;

public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
{
	public EmployeeRepository(AppDbContext context):base(context)
	{
	}
}
