using System;
using AutoMapper;
using GameStore.Application.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Application.Commands;
using Flunt.Notifications;
using GameStore.Domain.ValueObjects;
using GameStore.Domain.Entities;

namespace GameStore.Application.Services
{
    public class OrderServices : Notifiable, IOrderServices
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;
        public OrderServices(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public CommandResult FinishCreditCardOrder(FinishCreditCardOrderCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Can't finish the order request.");
            }

            //var name = new PersonName(command.FirstName, command.LastName);
            //var email = new Email(command.Email);

            //// Gerar as Entidades
            //var payment = new CreditCardPayment(
            //    command.CardHolderName,
            //    command.CardNumber,
            //    command.LastTransactionNumber,
            //    command.PaidDate,
            //    command.ExpireDate,
            //    command.Total,
            //    command.TotalPaid,
            //    command.Payer,
            //    email);

            var cart = new ShoppingCart(command.UserId,command.ListOfItems);

            var order = new Order(command.UserId, cart);

            //AddNotifications(name, email, payment);

            if (Invalid)
                return new CommandResult(false, "Can't finish the order request.");

            _unit.Orders.CreateOrder(order);

            return new CommandResult(true, "Order finished with success.");
        }

        public CommandResult FinishPayPalOrder(FinishPayPalOrderCommand order)
        {
            throw new NotImplementedException();
        }
    }
}