using Staff_API.Model;
using System.Net;

namespace Staff_API.Services
{
    public class StaffService : IStaffService
    {
        private readonly List<Staff> _StaffesList;
        public StaffService()
        {
            _StaffesList = new List<Staff>()
            {
                new Staff(){
                    UserId = 1,
                    FirstName = "Test",
                    SurName = "",
                    isActive = true,
                    DateOfBirth = DateTime.Now.ToShortDateString(),
                }
            };
        }

        public List<Staff> GetAllStaffs(bool? isActive)
        {
            return isActive == null ? _StaffesList : _StaffesList.Where(Staff => Staff.isActive == isActive).ToList();
        }

        public Staff? GetStaffByID(int id)
        {
            return _StaffesList.FirstOrDefault(Staff => Staff.UserId == id);
        }

        public Staff AddStaff(AddUpdateStaff obj)
        {
            var addStaff = new Staff()
            {
                UserId = _StaffesList.Max(Staff => Staff.UserId) + 1,
                FirstName = obj.FirstName,
                SurName = obj.SurName,
                isActive = obj.isActive,
                DateOfBirth = obj.DateOfBirth,
                Address = obj.Address,
            };

            _StaffesList.Add(addStaff);

            return addStaff;
        }

        public Staff? UpdateStaff(int id, AddUpdateStaff obj)
        {
            var StaffIndex = _StaffesList.FindIndex(index => index.UserId == id);
            if (StaffIndex > 0)
            {
                var Staff = _StaffesList[StaffIndex];

                Staff.FirstName = obj.FirstName;
                Staff.SurName = obj.SurName;
                Staff.isActive = obj.isActive;
                Staff.DateOfBirth = obj.DateOfBirth;
                Staff.Address = obj.Address;

                _StaffesList[StaffIndex] = Staff;

                return Staff;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteStaffByID(int id)
        {
            var StaffIndex = _StaffesList.FindIndex(index => index.UserId == id);
            if (StaffIndex >= 0)
            {
                _StaffesList.RemoveAt(StaffIndex);
            }
            return StaffIndex >= 0;
        }
    }
}
