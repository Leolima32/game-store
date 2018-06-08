using System;
using GameStore.Application.Commands;

namespace GameStore.Application.Interfaces
{
    public interface IOrderServices
    {
        CommandResult FinishCreditCardOrder (FinishCreditCardOrderCommand order, Guid UserId);
        CommandResult FinishPayPalOrder (FinishPayPalOrderCommand order, Guid UserId);
    }
}