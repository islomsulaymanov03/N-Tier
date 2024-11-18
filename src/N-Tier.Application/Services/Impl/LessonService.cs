using AutoMapper;
using N_Tier.Application.Exceptions;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Lesson;
using N_Tier.Application.Models.Student;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using N_Tier.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
	public class LessonService : ILessonService
	{
		private readonly IClaimService _claimService;
		private readonly IMapper _mapper;
		private readonly ILessonRepository _lessonRepository;
		private object updateTodoListModel;

		public LessonService(ILessonRepository lessonRepository, IClaimService claimService,
			IMapper mapper)
		{
			_lessonRepository = lessonRepository;
			_claimService = claimService;
			_mapper = mapper;
		}

		public async Task<CreateLessonResponseModel> CreateAsync(CreateLessonModel createLessonModel, CancellationToken cancellationToken = default)
		{
			var todoList = _mapper.Map<Lesson>(createLessonModel);

			var addedTodoList = await _lessonRepository.AddAsync(todoList);

			return new CreateLessonResponseModel
			{
				Id = addedTodoList.Id
			};
		}

		public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var todoList = await _lessonRepository.GetFirstAsync(tl => tl.Id == id);

			return new BaseResponseModel
			{
				Id = (await _lessonRepository.DeleteAsync(todoList)).Id
			};
		}

		public async Task<IEnumerable<LessonResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var currentUserId = _claimService.GetUserId();

			var todoLists = await _lessonRepository.GetAllAsync(tl => tl.CreatedBy == currentUserId);

			return _mapper.Map<IEnumerable<LessonResponseModel>>(todoLists);
		}
		public async Task<UpdateLessonResponseModel> UpdateAsync(Guid id, UpdateLessonModel updateStudentModel, CancellationToken cancellationToken = default)
		{
			var todoList = await _lessonRepository.GetFirstAsync(tl => tl.Id == id);

			var userId = _claimService.GetUserId();

			if (userId != todoList.CreatedBy)
				throw new BadRequestException("The selected list does not belong to you");

			todoList.Title = updateTodoListModel;

			return new UpdateLessonResponseModel
			{
				Id = (await _lessonRepository.UpdateAsync(todoList)).Id
			};
		}
	}
}
