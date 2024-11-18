using N_Tier.Application.Models.Exam;
using N_Tier.Application.Models.Grades;
using N_Tier.Application.Models.Lesson;

namespace N_Tier.Application.Models;

public class ApiResult<T>
{
    private ApiResult() { }

    private ApiResult(bool succeeded, T result, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Result = result;
        Errors = errors;
    }

    public bool Succeeded { get; set; }

    public T Result { get; set; }

    public IEnumerable<string> Errors { get; set; }

    public static ApiResult<T> Success(T result)
    {
        return new ApiResult<T>(true, result, new List<string>());
    }

    public static ApiResult<T> Failure(IEnumerable<string> errors)
    {
        return new ApiResult<T>(false, default, errors);
    }

	public static object? Success(UpdateExamResponseModel updateExamResponseModel)
	{
		throw new NotImplementedException();
	}

	public static object? Success(UpdateGradeResponseModel updateGradeResponseModel)
	{
		throw new NotImplementedException();
	}

	public static object? Success(UpdateLessonResponseModel updateLessonResponseModel)
	{
		throw new NotImplementedException();
	}
}
