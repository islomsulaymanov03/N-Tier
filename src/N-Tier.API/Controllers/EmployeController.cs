using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using N_Tier.Application.Services;
using N_Tier.Application.Models.Employee;

namespace N_Tier.API.Controllers
{
	public class EmployeController:ApiController
	{
		private readonly IEmployeService _employeService;

		public EmployeController(IEmployeService employeService)
		{
			_employeService = employeService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateEmployeModel createEmployeModel)
		{
			return Ok(ApiResult<CreateEmployeResponseModel>.Success(
				await _employeService.CreateAsync(createEmployeModel)));
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateAsync(Guid id, UpdateEmployeModel updateEmployeModel)
		{
			return Ok(ApiResult<UpdateEmployeResponseModel>.Success(
				await _employeService.UpdateAsync(id, updateEmployeModel)));
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			return Ok(ApiResult<BaseResponseModel>.Success(await _employeService.DeleteAsync(id)));
		}
	}
}
