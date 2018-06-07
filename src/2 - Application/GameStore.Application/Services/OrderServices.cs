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
            var email = new Email(command.Email);

            var payment = new CreditCardPayment(
               command.CardHolderName,
               command.CardNumber,
               command.PaidDate,
               command.ExpireDate,
               command.Total,
               command.TotalPaid,
               command.Payer,
               email);

            var cart = new ShoppingCart(command.UserId,command.ListOfItems);

            var order = new Order(command.UserId, cart, payment);

            order.AddNonconformity(payment, cart);

            if (order.IsInvalid)
                return new CommandResult(false, "Can't finish the order request.");

            _unit.Orders.CreateOrder(order);

            return new CommandResult(true, "Order finished with success.");
        }

        public CommandResult FinishPayPalOrder(FinishPayPalOrderCommand command)
        {
            var email = new Email(command.Email);

            var payment = new PayPalPayment(
               command.TransactionCode,
               command.PaidDate,
               command.ExpireDate,
               command.Total,
               command.TotalPaid,
               command.Payer,
               email);

            var cart = new ShoppingCart(command.UserId,command.ListOfItems);

            var order = new Order(command.UserId, cart, payment);

            order.AddNonconformity(payment, cart);

            if (order.IsInvalid)
                return new CommandResult(false, "Can't finish the order request.");

            _unit.Orders.CreateOrder(order);

            return new CommandResult(true, "Order finished with success.");
        }
    }
}