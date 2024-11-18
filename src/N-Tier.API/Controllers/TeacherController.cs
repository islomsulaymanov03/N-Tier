using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models.Exam;
using N_Tier.Application.Models;
using N_Tier.Application.Services;
using N_Tier.Application.Models.Teacher;

namespace N_Tier.API.Controllers
{
	public class TeacherController:ApiController
	{

		private readonly ITeacherService _teacherService;

		public TeacherController(ITeacherService teacherService)
		{
			_teacherService = teacherService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateTeacherModel createTeacherModel)
		{
			return Ok(ApiResult<CreateTeacherResponseModel>.Success(
				await _teacherService.CreateAsync(createTeacherModel)));
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateAsync(Guid id, UpdateTeacherModel updateTeacherModel)
		{
			return Ok(ApiResult<UpdateTeacherResponseModel>.Success(
				await _teacherService.UpdateAsync(id, updateTeacherModel)));
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			return Ok(ApiResult<BaseResponseModel>.Success(await _teacherService.DeleteAsync(id)));
		}
	}
}
