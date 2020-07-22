using leave_management.Contracts;
using leave_management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveTypeRepository : ILeaveTyperepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveType entity)
        {
            var leaveType = _db.LeaveTypes.Add(entity);
            //save
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            //save
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            // another way to get particular id using --> " _db.LeaveTypes.FirstOrDefault()"
            return leaveType;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveTypes(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
           var changes = _db.SaveChanges();
            return changes > 0;


            //save
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
            //save
        }
    }
}
