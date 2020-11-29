using AutoMapper;
using Branches.Dtos;
using Branches.Models;

namespace Branches.Profiles
{
    public class BranchesProfile : Profile
    {
        public BranchesProfile()
        {
            // Source -> Target
            CreateMap<Branch, BranchReadDto>();
            CreateMap<BranchCreateDto, Branch>();
            CreateMap<BranchUpdateDto, Branch>();
            CreateMap<Branch, BranchUpdateDto>();
        }
    }
}