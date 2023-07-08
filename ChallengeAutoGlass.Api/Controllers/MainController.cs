using System;
using System.Net;
using ChallengeAutoGlass.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAutoGlass.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
	{
		public MainController()
		{
		}

		protected ActionResult CustomActionResult(BaseResponse baseResponse)
		{
			var httpStatusCodeResult = baseResponse.StatusCode;

			ActionResult? actionResult = null;

			switch (httpStatusCodeResult)
			{
				case HttpStatusCode.OK:
					actionResult = Ok(baseResponse);
					break;

                case HttpStatusCode.Created:
                    actionResult = Created(string.Empty,baseResponse);
                    break;

                case HttpStatusCode.NoContent:
                    actionResult = NoContent();
                    break;

                case HttpStatusCode.NotFound:
                    actionResult = NotFound(baseResponse);
                    break;

                case HttpStatusCode.BadRequest:
                    actionResult = BadRequest(baseResponse);
                    break;


                default:
                    actionResult = BadRequest(baseResponse);
                    break;
			}


			return actionResult!;
		}
	}
}

