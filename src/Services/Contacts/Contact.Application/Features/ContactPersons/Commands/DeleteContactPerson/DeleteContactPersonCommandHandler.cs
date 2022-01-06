using AutoMapper;
using Contact.Application.Contracts.Persistence;
using Contact.Application.Exceptions;
using Contact.Domain.ContactPersonAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.ContactPersons.Commands.DeleteContactPerson
{
    public class DeleteContactPersonCommandHandler : IRequestHandler<DeleteContactPersonCommand>
    {
        private readonly IContactPersonRepository _contactPersonRepository;
        private readonly IContactPersonInfoRepository _contactPersonInfoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteContactPersonCommandHandler> _logger;

        public DeleteContactPersonCommandHandler(IContactPersonRepository contactPersonRepository,
            IContactPersonInfoRepository contactPersonInfoRepository,
            IMapper mapper, ILogger<DeleteContactPersonCommandHandler> logger)
        {
            _contactPersonRepository = contactPersonRepository ?? throw new ArgumentNullException(nameof(contactPersonRepository));
            _contactPersonInfoRepository = contactPersonInfoRepository ?? throw new ArgumentNullException(nameof(contactPersonInfoRepository)); ;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteContactPersonCommand request, CancellationToken cancellationToken)
        {
            var contactWithLoading = await _contactPersonRepository.GetAsync(x => x.Id == request.Id, null, "ContactPersonInfos");
            var contactToDelete = contactWithLoading.FirstOrDefault();
            
            if (contactToDelete == null)
                throw new NotFoundException(nameof(ContactPerson), request.Id);

            if (contactToDelete.ContactPersonInfos.Count > 0)
                await _contactPersonInfoRepository.DeleteListAsync(contactToDelete.ContactPersonInfos.ToList());

            await _contactPersonRepository.DeleteAsync(contactToDelete);

            _logger.LogInformation($"Contact Person {contactToDelete.Id} is successfully deleted.");

            return Unit.Value;

        }
    }
}
