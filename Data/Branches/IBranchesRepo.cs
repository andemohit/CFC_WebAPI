using System.Collections.Generic;
using Branches.Models;

namespace Branches.Data
{
    public interface IBranchRepo
    {
        bool SaveChanges();
        IEnumerable<Branch> GetAllBranches();
        Branch GetBranchById(int id);
        void CreateBranch(Branch branch);
        void UpdateBranch(Branch branch);
        void DeleteBranch(Branch branch);
    }
}