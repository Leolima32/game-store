using System;

namespace GameStore.Application.ViewModels
{
    public class ResultViewModel {
        public ResultViewModel()
        {
            
        }
        public ResultViewModel(int httpStatus, string message)
        {
            HttpStatus = httpStatus;
            Message = message;
        }

        public ResultViewModel(Guid id, int httpStatus, string message)
        {
            Id = id;
            HttpStatus = httpStatus;
            Message = message;
        }

        public Guid? Id { get; set; }
        public int HttpStatus { get; set; }
        public string Message { get; set; }     
    }
}