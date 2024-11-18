using AutoMapper;
using N_Tier.Application.Models.TodoItem;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Teacher;
using N_Tier.DataAccess.Repositories.Impl;
using Microsoft.Extensions.Options;
using N_Tier.Application.Models.TodoList;

namespace N_Tier.Application.Services.Impl
{
	public class TeacherService : ITeacherService
	{
		private readonly IMapper _mapper;
		private readonly ITeacherRepository _teacherRepository;

		public TeacherService(ITeacherRepository teacherRepository,
			IMapper mapper)
		{
			_teacherRepository = teacherRepository;
			_mapper = mapper;
		}
		public async Task<CreateTeacherResponseModel> CreateAsync(CreateTeacherModel createTeacherModel, CancellationToken cancellationToken = default)
		{
			var todoItem = _mapper.Map<Teacher>(createTeacherModel);

			return new CreateTeacherResponseModel
			{
				Id = (await _teacherRepository.AddAsync(todoItem)).Id
			};
		}

		public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var todoItem = await _teacherRepository.GetFirstAsync(ti => ti.Id == id);

			return new BaseResponseModel
			{
				Id = (await _teacherRepository.DeleteAsync(todoItem)).Id
			};
		}

		public async Task<IEnumerable<TeacherResponseModel>> GetAll()
		{

			var currentUserId = _teacherRepository.GetUserId();

			var todoLists = await _teacherRepository.GetAllAsync(tl => tl.CreatedBy == currentUserId);

			return _mapper.Map<IEnumerable<TeacherResponseModel>>(todoLists);
		}

		public async Task<UpdateTeacherResponseModel> UpdateAsync(Guid id, UpdateTeacherModel updateTeacherModel, CancellationToken cancellationToken = default)
		{
			var todoItem = await _teacherRepository.GetFirstAsync(ti => ti.Id == id);

			_mapper.Map(updateTeacherModel, todoItem);

			return new UpdateTeacherResponseModel
			{
				Id = (await _teacherRepository.UpdateAsync(todoItem)).Id
			};
		}
	}
}
