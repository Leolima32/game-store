using System;
using AutoMapper;
using GameStore.Application.Interfaces;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Application.Commands;
using Flunt.Notifications;
using GameStore.Domain.ValueObjects;
using PaymentContext.Domain.ValueObjects;
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

            //// Verificar se Documento já está cadastrado
            //if (_repository.DocumentExists(command.Document))
            //    AddNotification("Document", "Este CPF já está em uso");

            // Gerar os VOs
            var name = new PersonName(command.FirstName, command.LastName);
            var email = new Email(command.Email);

            // Gerar as Entidades
            CreditCardPayment payment = new CreditCardPayment();
            var order = new Order(command.UserId,);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                email
            );

            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as Validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            // Salvar as Informações
            _repository.CreateSubscription(student);

            // Enviar E-mail de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "bem vindo ao balta.io", "Sua assinatura foi criada");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public CommandResult FinishPayPalOrder(FinishPayPalOrderCommand order)
        {
            throw new NotImplementedException();
        }
    }
}