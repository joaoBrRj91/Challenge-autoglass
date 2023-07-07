using System;
using System.Net;

namespace ChallengeAutoGlass.Application.Responses
{
	public class BaseResponse
	{
        public BaseResponse()
        {
			Errors = new List<string>();
        }

        public bool IsSuccess { get; set; }

		public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

		public object? Result { get; set; }

		public List<string> Errors { get; set; }
	}
}

