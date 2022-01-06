using AutoMapper;
using Contact.Application.Contracts.Persistence;
using Contact.Domain.ContactPersonAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.ContactPersons.Commands.SaveContactPerson
{
    public class SaveContactPersonContactHandler : IRequestHandler<SaveContactPersonCommand, Guid>
    {
        private readonly IContactPersonRepository _contactPersonRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SaveContactPersonContactHandler> _logger;

        public SaveContactPersonContactHandler(IContactPersonRepository contactPersonRepository, IMapper mapper,
            ILogger<SaveContactPersonContactHandler> logger)
        {
            _contactPersonRepository = contactPersonRepository ?? throw new ArgumentNullException(nameof(contactPersonRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> Handle(SaveContactPersonCommand request, CancellationToken cancellationToken)
        {
            var contactPersonEntity = _mapper.Map<ContactPerson>(request);
            var newContactPerson = await _contactPersonRepository.AddAsync(contactPersonEntity);

            _logger.LogInformation($"Contact {newContactPerson.Id} is successfully created.");

            return newContactPerson.Id;
        }
    }
}
