using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AIFitnessProject.Core.Constants.RoleConstants;
namespace AIFitnessProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
