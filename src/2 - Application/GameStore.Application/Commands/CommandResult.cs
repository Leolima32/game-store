using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Application.Commands
{
    public class CommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
