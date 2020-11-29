using System.Collections.Generic;
using AutoMapper;
using Branches.Data;
using Branches.Dtos;
using Branches.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Branches.Controllers
{
    // api/branches
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchRepo _repository;
        private readonly IMapper _mapper;

        public BranchesController(IBranchRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/branches
        [HttpGet]
        public ActionResult<IEnumerable<BranchReadDto>> GetAllBranches()
        {
            var branchItems = _repository.GetAllBranches();
            return Ok(_mapper.Map<IEnumerable<BranchReadDto>>(branchItems));
        }

        // GET api/branches/{id}
        [HttpGet("{id}", Name = "GetBranchById")]
        public ActionResult<Branch> GetBranchById(int id)
        {
            var branchItem = _repository.GetBranchById(id);
            if (branchItem != null)
            {
                return Ok(_mapper.Map<BranchReadDto>(branchItem));
            }
            return NotFound();
        }

        // POST api/branches
        [HttpPost]
        public ActionResult<BranchReadDto> CreateBranch(BranchCreateDto brancheCreateDto)
        {
            var branchModel = _mapper.Map<Branch>(brancheCreateDto);
            _repository.CreateBranch(branchModel);
            _repository.SaveChanges();
            var branchReadDto = _mapper.Map<BranchReadDto>(branchModel);
            return CreatedAtRoute(nameof(GetBranchById), new { id = branchReadDto.id }, branchReadDto);
        }

        // PUT api/branches/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBranch(int id, BranchUpdateDto branchUpdateDto)
        {
            var branchModelFromRepo = _repository.GetBranchById(id);
            if (branchModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(branchUpdateDto, branchModelFromRepo);
            _repository.UpdateBranch(branchModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // PATCH api/branches/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialBranchUpdate(int id, JsonPatchDocument<BranchUpdateDto> pathcDoc)
        {
            var branchModelFromRepo = _repository.GetBranchById(id);
            if (branchModelFromRepo == null)
            {
                return NotFound();
            }

            var branchToPatch = _mapper.Map<BranchUpdateDto>(branchModelFromRepo);
            pathcDoc.ApplyTo(branchToPatch, ModelState);

            if (!TryValidateModel(branchToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(branchToPatch, branchModelFromRepo);
            _repository.UpdateBranch(branchModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/branches/{id}
        [HttpDelete("{id}")]
        public ActionResult Deletebranch(int id)
        {
            var branchModelFromRepo = _repository.GetBranchById(id);
            if (branchModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteBranch(branchModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}