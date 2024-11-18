using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models.Exam;
using N_Tier.Application.Models;
using N_Tier.Application.Services;
using N_Tier.Application.Models.Grades;

namespace N_Tier.API.Controllers
{
	public class GradesController:ApiController
	{

		private readonly IGradesService _gradesService;

		public GradesController(IGradesService gradesService)
		{
			_gradesService = gradesService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateGradesModel createGradesModel)
		{
			return Ok(ApiResult<CreateGradesResponseModel>.Success(
				await _gradesService.CreateAsync(createGradesModel)));
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateAsync(Guid id, UpdateGradesModel updateGradesModel)
		{
			return Ok(ApiResult<UpdateGradeResponseModel>.Success(
				await _gradesService.UpdateAsync(id, updateGradesModel)));
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			return Ok(ApiResult<BaseResponseModel>.Success(await _gradesService.DeleteAsync(id)));
		}
	}
}
