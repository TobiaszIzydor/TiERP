using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiWms.Application.ApplicationUser.Commands.SetRoleToApplicationUser;
using TiWms.Application.ApplicationUser.GetAllRoles;
using TiWms.Application.ApplicationUser.GetAllUsers;
using TiWms.MVC.Models;
using System.Threading.Tasks;

namespace TiWms.MVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Wyświetlanie formularza
        public async Task<IActionResult> Set()
        {
            var model = new SetRoleToUserView
            {
                SetRoleToApplicationUserCommand = new SetRoleToApplicationUserCommand(), // Konstruktor z pustymi wartościami
                Users = await _mediator.Send(new GetAllUsersQuery()),
                Roles = await _mediator.Send(new GetAllRolesQuery())
            };

            return View(model);
        }

        // Obsługa formularza po wysłaniu
        [HttpPost]
        public async Task<IActionResult> Set(SetRoleToUserView modelview)
        {
            var command = modelview.SetRoleToApplicationUserCommand;

            await _mediator.Send(command); // Wywołanie komendy (przypisanie roli)
            return RedirectToAction(nameof(Set)); // Po zakończeniu przekierowanie do tej samej akcji (reset formularza)
        }
    }
}
