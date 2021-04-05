using AutoMapper;
using NormasService.Domain.Entities;
using NormasService.Domain.Repositories;
using NormasService.Infrastructure.Database;
using System.Diagnostics.CodeAnalysis;

namespace NormasService.Infrastructure.Repositories
{
    [ExcludeFromCodeCoverage]
    public class NormaRepository : BaseRepository<Norma>, INormaRepository
    {
        private readonly IMapper _mapper;
        protected readonly DatabaseContext _context;

        public NormaRepository(IMapper mapper, DatabaseContext context)
            : base(context)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
