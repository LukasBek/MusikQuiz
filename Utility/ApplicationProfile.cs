using AutoMapper;
using MusikQuiz.DTO;
using MusikQuiz.Models;

namespace MusikQuiz.Utility
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserVmDto>().ReverseMap();
            CreateMap<User, UserImDto>().ReverseMap();
            CreateMap<User, UserImNewPassDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Quiz, QuizImDto>().ReverseMap();
            CreateMap<Quiz, QuizVmMain>().ReverseMap();
            CreateMap<Quiz, QuizVmSingle>().ReverseMap();

            CreateMap<Sound, SoundDto>().ReverseMap();
        }
    }
}
