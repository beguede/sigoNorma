using NormasService.Application.Models;
using NormasService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NormasService.Application.Interfaces
{
    public interface INormaApplication
    {
        Task<Result<Norma>> ObterPorId(Guid id);
        Task<Result<Norma>> Incluir(NormaModel normaModel);
        Task<Result<Norma>> Atualizar(NormaModel normaModel);
        Task Excluir(Guid id);
        Task<Result<IList<Norma>>> ListarTodos();
    }
}