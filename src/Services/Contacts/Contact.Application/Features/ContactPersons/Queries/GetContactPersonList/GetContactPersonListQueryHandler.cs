using AutoMapper;
using Contact.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.ContactPersons.Queries.GetContactPersonList
{
    public class GetContactPersonListQueryHandler : IRequestHandler<GetContactPersonListQuery, List<ContactPersonResponse>>
    {
        private readonly IContactPersonRepository _contactPersonRepository;
        private readonly IMapper _mapper;

        public GetContactPersonListQueryHandler(IContactPersonRepository contactPersonRepository, IMapper mapper)
        {
            _contactPersonRepository = contactPersonRepository ?? throw new ArgumentNullException(nameof(contactPersonRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ContactPersonResponse>> Handle(GetContactPersonListQuery request, CancellationToken cancellationToken)
        {
            var contactPersonList = await _contactPersonRepository.GetAllAsync();
            return _mapper.Map<List<ContactPersonResponse>>(contactPersonList);
        }
    }
}
