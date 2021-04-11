using AutoMapper;
using Flunt.Notifications;
using Moq;
using NormasService.Application;
using NormasService.Application.Models;
using NormasService.Domain.Entities;
using NormasService.Domain.Repositories;
using NormasService.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NormasService.Tests.Appications
{
    public class NormaApplicationTest
    {
        private Mock<IMapper> _mockMapper;
        private Mock<INormaRepository> _mockNormaRepository;

        public NormaApplication CriaNovaInstancia()
        {
            _mockMapper = new Mock<IMapper>();
            _mockNormaRepository = new Mock<INormaRepository>();

            return new NormaApplication(_mockMapper.Object, _mockNormaRepository.Object);
        }

        [Fact]
        public async Task ObterTodasNormaAsync_Ok()
        {
            var normaApplication = CriaNovaInstancia();

            _mockNormaRepository.Setup(m => m.ListarTodos())
                .ReturnsAsync(FakeNorma.ObterListaNormaDefault());

            var response = await normaApplication.ListarTodos();

            Assert.IsType<Result<IList<Norma>>>(response);
            Assert.True(response.Object != null);
            Assert.True(response.Notifications.Count == 0);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task ObterNormaPorIdAsync_Ok()
        {
            Guid id = new Guid("8afcf517-2e58-4c7e-a9c9-132c0ef1947f");

            var normaApplication = CriaNovaInstancia();

            _mockNormaRepository.Setup(m => m.ObterPorId(It.IsAny<Guid>()))
                .ReturnsAsync(FakeNorma.ObterNormaDefault());

            var response = await normaApplication.ObterPorId(id);

            Assert.IsType<Result<Norma>>(response);
            Assert.True(response.Object != null);
            Assert.True(response.Notifications.Count == 0);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task IncluirNormaAsync_Ok()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            var normaApplication = CriaNovaInstancia();

            _mockMapper.Setup(m => m.Map<NormaModel, Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaRepository.Setup(m => m.Incluir(It.IsAny<Norma>()));

            var response = await normaApplication.Incluir(normaModel);

            Assert.IsType<Result<Norma>>(response);
            Assert.True(response.Object != null);
            Assert.True(response.Notifications.Count == 0);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task IncluirNormaAsync_Error()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            norma.AddNotification(new Notification("Norma", "Erro ao executar o mapeamento."));
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            var normaApplication = CriaNovaInstancia();

            _mockMapper.Setup(m => m.Map<NormaModel, Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaRepository.Setup(m => m.Incluir(It.IsAny<Norma>()));

            var response = await normaApplication.Incluir(normaModel);

            Assert.IsType<Result<Norma>>(response);
            Assert.True(response.Object == null);
            Assert.True(response.Notifications.Any());
            Assert.True(response.Invalid);
        }

        [Fact]
        public async Task AtualizarNormaAsync_Ok()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            var normaApplication = CriaNovaInstancia();

            _mockMapper.Setup(m => m.Map<NormaModel, Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaRepository.Setup(m => m.Atualizar(It.IsAny<Norma>()));

            var response = await normaApplication.Atualizar(normaModel);

            Assert.IsType<Result<Norma>>(response);
            Assert.True(response.Object != null);
            Assert.True(response.Notifications.Count == 0);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task AtualizarNormaAsync_Error()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            norma.AddNotification(new Notification("Norma", "Erro ao executar o mapeamento."));
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            var normaApplication = CriaNovaInstancia();

            _mockMapper.Setup(m => m.Map<NormaModel, Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaRepository.Setup(m => m.Atualizar(It.IsAny<Norma>()));

            var response = await normaApplication.Atualizar(normaModel);

            Assert.IsType<Result<Norma>>(response);
            Assert.True(response.Object == null);
            Assert.True(response.Notifications.Any());
            Assert.True(response.Invalid);
        }

        [Fact]
        public async Task ExcluirNormaAsync_Ok()
        {
            Guid id = new Guid("8afcf517-2e58-4c7e-a9c9-132c0ef1947f");


            var normaApplication = CriaNovaInstancia();

            _mockNormaRepository.Setup(m => m.Excluir(It.IsAny<Guid>()));

            await normaApplication.Excluir(id);
        }
    }
}
