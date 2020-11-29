using System;
using System.Collections.Generic;
using System.Linq;
using Branches.Models;

namespace Branches.Data
{
    public class SqlBranchRepo : IBranchRepo
    {
        private readonly BranchContext _context;

        public SqlBranchRepo(BranchContext context)
        {
            _context = context;
        }

        public void CreateBranch(Branch branch)
        {
            if (branch == null)
            {
                throw new ArgumentNullException(nameof(branch));
            }
            _context.Branches.Add(branch);
        }

        public void DeleteBranch(Branch branch)
        {
            if (branch == null)
            {
                throw new ArgumentNullException(nameof(branch));
            }
            _context.Branches.Remove(branch);
        }

        public IEnumerable<Branch> GetAllBranches()
        {
            return _context.Branches.ToList();
        }

        public Branch GetBranchById(int id)
        {
            return _context.Branches.FirstOrDefault(b => b.id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateBranch(Branch branch)
        {
            // Nothing
        }
    }
}