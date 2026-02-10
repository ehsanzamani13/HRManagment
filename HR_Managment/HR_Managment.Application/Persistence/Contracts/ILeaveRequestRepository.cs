using HR_Managment.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment.Application.Persistence.Contracts;

public interface ILeaveRequestRepository : IGenericeRepository<LeaveRequestDto>
{

}
