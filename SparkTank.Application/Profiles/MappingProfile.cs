using AutoMapper;
using SparkTank.Domain.Entities;
using SparkTank.Application.DTOs.UserDto;
using tech.Domain.Entities;
using tech.Application.DTOs.RecipesDto;
using tech.Application.DTOs.CommentsDto;


namespace SparkTank.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Profile
            CreateMap<UserEntity, CreateUserDto>().ReverseMap();
            CreateMap<UserEntity, GetUserDto>().ReverseMap();

            //recipe
            CreateMap<RecipeEntity, CreateRecipeDto>().ReverseMap();
            CreateMap<RecipeEntity, GetRecipeDto>().ReverseMap();
            CreateMap<RecipeEntity, GetRecipesDto>().ReverseMap();
            CreateMap<RecipeEntity, UpdateRecipesDto>().ReverseMap();

            //comment 
            CreateMap<CommentEntity, CreateCommentDto>().ReverseMap();
            CreateMap<CommentEntity, UpdateCommentDto>().ReverseMap();
            CreateMap<CommentEntity, GetCommentDto>().ReverseMap();
            CreateMap<CommentEntity, GetCommentsDto>().ReverseMap();

            
        }
    }
}