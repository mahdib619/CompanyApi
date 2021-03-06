using CompanyApi.Mappers.EndpointMappers;
using CompanyApi.Models.Contracts;
using CompanyApi.Services;

namespace CompanyApi.Endpoints.Employee;

public class GetAllEmployeesEndpoint : Endpoint<EmptyRequest, GetAllEmployeesResponse, EmployeeEndpointMapper<EmptyRequest>>
{
	private readonly IEmployeeService employeeService;

	public GetAllEmployeesEndpoint(IEmployeeService employeeService)
	{
		this.employeeService = employeeService;
	}

	public override void Configure()
	{
		Get();
		Routes("/employees");
		AllowAnonymous();
	}

	public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
	{
		var employees = (await employeeService.GetAll()).Select(c => Map.FromEntity(c));
		var response = new GetAllEmployeesResponse { Employees = employees };

		await SendAsync(response, cancellation: ct);
	}
}