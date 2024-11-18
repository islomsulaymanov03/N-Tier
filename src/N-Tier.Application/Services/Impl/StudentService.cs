using AutoMapper;
using N_Tier.Application.Models.Teacher;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N_Tier.Application.Models.Student;
using N_Tier.Application.Models.TodoList;
using N_Tier.DataAccess.Repositories.Impl;
using N_Tier.Application.Exceptions;
using N_Tier.Shared.Services;

namespace N_Tier.Application.Services.Impl
{
	public class StudentService:IStudentService
	{
		private readonly IClaimService _claimService;
		private readonly IMapper _mapper;
		private readonly IStudentRepository _studentService;
		private object updateTodoListModel;

		public StudentService(IStudentRepository studentRepository,IClaimService claimService,
			IMapper mapper)
		{
			_studentService = studentRepository;
			_claimService = claimService;
			_mapper = mapper;
		}

		public async Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel, CancellationToken cancellationToken = default)
		{
			var todoList = _mapper.Map<Student>(createStudentModel);

			var addedTodoList = await _studentService.AddAsync(todoList);

			return new CreateStudentResponseModel
			{
				Id = addedTodoList.Id
			};
		}

		public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var todoList = await _studentService.GetFirstAsync(tl => tl.Id == id);

			return new BaseResponseModel
			{
				Id = (await _studentService.DeleteAsync(todoList)).Id
			};
		}

		public async Task<IEnumerable<StudentResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var currentUserId = _claimService.GetUserId();

			var todoLists = await _studentService.GetAllAsync(tl => tl.CreatedBy == currentUserId);

			return _mapper.Map<IEnumerable<StudentResponseModel>>(todoLists);
		}
		public async Task<UpdateStudentResponseModel> UpdateAsync(Guid id, UpdateStudentModel updateStudentModel, CancellationToken cancellationToken = default)
		{
			var todoList = await _studentService.GetFirstAsync(tl => tl.Id == id);

			var userId = _claimService.GetUserId();

			if (userId != todoList.CreatedBy)
				throw new BadRequestException("The selected list does not belong to you");

			todoList.Title = updateTodoListModel;

			return new UpdateStudentResponseModel
			{
				Id = (await _studentService.UpdateAsync(todoList)).Id
			};
		}
	}
}
