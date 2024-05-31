using Staff_API.Model;

namespace Staff_API.Services
{
    public interface IStaffService
    {
        List<Staff> GetAllStaffs(bool? isActive);

        Staff? GetStaffByID(int id);

        Staff AddStaff(AddUpdateStaff obj);

        Staff? UpdateStaff(int id, AddUpdateStaff obj);

        bool DeleteStaffByID(int id);
    }
}
