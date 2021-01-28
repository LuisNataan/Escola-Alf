using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;

namespace Escola.Alf.Solution.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult HandleException(this ControllerBase controllerBase, Exception ex)
        {
            if (ex is AuthenticationException)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            else if (ex is ValidationException)
            {
                return new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
            return controllerBase.BadRequest();
        }
    }
}
