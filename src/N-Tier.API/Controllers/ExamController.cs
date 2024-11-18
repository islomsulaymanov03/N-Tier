using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models.Employee;
using N_Tier.Application.Models;
using N_Tier.Application.Services;
using N_Tier.Application.Models.Exam;

namespace N_Tier.API.Controllers
{
	public class ExamController:ApiController
	{
		private readonly IExamService _examService;

		public ExamController(IExamService examService)
		{
			_examService = examService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(CreateExanModel createExanModel)
		{
			return Ok(ApiResult<CreateExamResponseModel>.Success(
				await _examService.CreateAsync(createExanModel)));
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateAsync(Guid id, UpdateExamModel updateExamModel)
		{
			return Ok(ApiResult<UpdateExamResponseModel>.Success(
				await _examService.UpdateAsync(id, updateExamModel)));
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			return Ok(ApiResult<BaseResponseModel>.Success(await _examService.DeleteAsync(id)));
		}
	}
}
