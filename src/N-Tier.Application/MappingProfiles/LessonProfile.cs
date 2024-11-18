using AutoMapper;
using N_Tier.Application.Models.Lesson;
using N_Tier.Application.Models.TodoList;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
	public class LessonProfile: Profile
	{
        public LessonProfile()
        {
			CreateMap<CreateLessonModel, Lesson>();

			CreateMap<Lesson, CreateLessonModel>();
		}
    }
}
