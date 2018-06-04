using GameStore.Application.Commands;

namespace GameStore.Application.Interfaces
{
    public interface IOrderServices
    {
        CommandResult FinishCreditCardOrder (FinishCreditCardOrderCommand order);
        CommandResult FinishPayPalOrder (FinishPayPalOrderCommand order);
    }
}