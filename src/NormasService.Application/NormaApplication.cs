using AutoMapper;
using NormasService.Application.Interfaces;
using NormasService.Application.Models;
using NormasService.Domain.Entities;
using NormasService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NormasService.Application
{
    public class NormaApplication : INormaApplication
    {
        private readonly IMapper _mapper;
        private readonly INormaRepository _normaRepository;

        public NormaApplication(IMapper mapper, INormaRepository normaRepository)
        {
            _mapper = mapper;
            _normaRepository = normaRepository;
        }

        public async Task<Result<Norma>> ObterPorId(Guid id)
        {
            Norma norma = await _normaRepository.ObterPorId(id);
            return Result<Norma>.Ok(norma);
        }

        public async Task<Result<Norma>> Incluir(NormaModel normaModel)
        {
            var norma = _mapper.Map<NormaModel, Norma>(normaModel);

            if (norma.Valid)
            {
                await _normaRepository.Incluir(norma);
                return Result<Norma>.Ok(norma);
            }

            return Result<Norma>.Error(norma.Notifications);
        }

        public async Task<Result<Norma>> Atualizar(NormaModel normaModel)
        {
            var norma = _mapper.Map<NormaModel, Norma>(normaModel);

            if (norma.Valid)
            {
                await _normaRepository.Atualizar(norma);
                return Result<Norma>.Ok(norma);
            }

            return Result<Norma>.Error(norma.Notifications);
        }

        public async Task Excluir(Guid id)
        {
            await _normaRepository.Excluir(id);
            return;
        }

        public async Task<Result<IList<Norma>>> ListarTodos()
        {
            IList<Norma> listaNorma = await _normaRepository.ListarTodos();
            return Result<IList<Norma>>.Ok(listaNorma);
        }
    }
}
