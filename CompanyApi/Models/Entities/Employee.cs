﻿using Dapper.Contrib.Extensions;

namespace CompanyApi.Models.Entities;

public class Employee
{
	[Key]
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string Title { get; set; }

	public int CompanyId { get; set; }

	[Write(false)]
	public Company Company { get; set; }

}
