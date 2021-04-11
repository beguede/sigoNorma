using AutoMapper;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NormasService.Api.Controllers;
using NormasService.Application;
using NormasService.Application.Interfaces;
using NormasService.Application.Models;
using NormasService.Domain.Entities;
using NormasService.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NormasService.Tests.Controllers
{
    public class NormaControllerTest
    {
        private Mock<IMapper> _mockMapper;
        private Mock<INormaApplication> _mockNormaApplication;

        public NormaControllerTest()
        {
            _mockMapper = new Mock<IMapper>();
            _mockNormaApplication = new Mock<INormaApplication>();
        }

        public NormaController CriaNovaInstancia()
        {
            return new NormaController(_mockMapper.Object, _mockNormaApplication.Object);
        }

        [Fact]
        public async Task ObterTodasNormas_Sucesso()
        {
            IList<Norma> listaNorma = FakeNorma.ObterListaNormaDefault();
            IList<NormaModel> listaNormaModel = FakeNorma.ObterListaNormaModelDefault();

            var normaController = CriaNovaInstancia();

            _mockMapper.Setup(m => m.Map<IList<NormaModel>>(It.IsAny<IList<Norma>>()))
                .Returns(listaNormaModel);

            _mockNormaApplication.Setup(m => m.ListarTodos())
                .ReturnsAsync(Result<IList<Norma>>.Ok(listaNorma));


            var response = await normaController.ListarTodos();

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task ObterTodasNormas_BadRequest()
        {
            IList<Norma> listaNorma = FakeNorma.ObterListaNormaDefault();
            IList<NormaModel> listaNormaModel = FakeNorma.ObterListaNormaModelDefault();

            var normaController = CriaNovaInstancia();

            _mockMapper.Setup(m => m.Map<IList<NormaModel>>(It.IsAny<IList<Norma>>()))
                .Returns(listaNormaModel);

            _mockNormaApplication.Setup(m => m.ListarTodos())
                .ReturnsAsync(Result<IList<Norma>>.Ok(null));


            var response = await normaController.ListarTodos();

            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task ObterTodasNormas_ErroInterno()
        {
            IList<Norma> listaNorma = FakeNorma.ObterListaNormaDefault();
            IList<NormaModel> listaNormaModel = FakeNorma.ObterListaNormaModelDefault();

            var normaController = CriaNovaInstancia();

            _mockMapper.Setup(m => m.Map<IList<NormaModel>>(It.IsAny<IList<Norma>>()))
                .Returns(listaNormaModel);

            _mockNormaApplication.Setup(m => m.ListarTodos())
                .Throws(new Exception());

            var response = await normaController.ListarTodos();

            Assert.Equal(500, ((ObjectResult)response).StatusCode);
        }      

        [Fact]
        public async Task ObterPorId_Sucesso()
        {
            Guid id = new Guid("327ee256-65d1-4765-b7e8-39a00acb40ff");
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<NormaModel>(It.IsAny<Norma>()))
                .Returns(normaModel);

            _mockNormaApplication.Setup(m => m.ObterPorId(It.IsAny<Guid>()))
                .ReturnsAsync(Result<Norma>.Ok(norma));

            var normaController = CriaNovaInstancia();

            var response = await normaController.ObterPorId(id);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task ObterPorId_BadRequest()
        {
            Guid id = new Guid("327ee256-65d1-4765-b7e8-39a00acb40ff");
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<NormaModel>(It.IsAny<Norma>()))
                .Returns(normaModel);

            _mockNormaApplication.Setup(m => m.ObterPorId(It.IsAny<Guid>()))
                .ReturnsAsync(Result<Norma>.Ok(null));

            var normaController = CriaNovaInstancia();

            var response = await normaController.ObterPorId(id);

            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task ObterPorId_ErroInterno()
        {
            Guid id = new Guid("327ee256-65d1-4765-b7e8-39a00acb40ff");
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<NormaModel>(It.IsAny<Norma>()))
                .Returns(normaModel);

            _mockNormaApplication.Setup(m => m.ObterPorId(It.IsAny<Guid>()))
                .Throws(new Exception());

            var normaController = CriaNovaInstancia();

            var response = await normaController.ObterPorId(id);

            Assert.Equal(500, ((ObjectResult)response).StatusCode);
        }

        [Fact]
        public async Task InserirNorma_Sucesso()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaApplication.Setup(m => m.Incluir(It.IsAny<NormaModel>()))
                .ReturnsAsync(Result<Norma>.Ok(norma));

            var normaController = CriaNovaInstancia();

            var response = await normaController.Inserir(normaModel);

            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task InserirNorma_BadRequest()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            norma.AddNotification(new Notification("Norma", "Erro no mapeamento."));
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaApplication.Setup(m => m.Incluir(It.IsAny<NormaModel>()))
                .ReturnsAsync(Result<Norma>.Error(norma.Notifications));

            var normaController = CriaNovaInstancia();

            var response = await normaController.Inserir(normaModel);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async Task InserirNorma_ErroInterno()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaApplication.Setup(m => m.Incluir(It.IsAny<NormaModel>()))
                .Throws(new Exception());

            var normaController = CriaNovaInstancia();

            var response = await normaController.Inserir(normaModel);

            Assert.Equal(500, ((ObjectResult)response).StatusCode);
        }

        [Fact]
        public async Task AtualizarNorma_Sucesso()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaApplication.Setup(m => m.Atualizar(It.IsAny<NormaModel>()))
                .ReturnsAsync(Result<Norma>.Ok(norma));

            var normaController = CriaNovaInstancia();

            var response = await normaController.Atualizar(normaModel);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task AtualizarNorma_BadRequest_Id()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();
            normaModel.Id = Guid.Empty;

            _mockMapper.Setup(m => m.Map<Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaApplication.Setup(m => m.Atualizar(It.IsAny<NormaModel>()))
                .ReturnsAsync(Result<Norma>.Error(norma.Notifications));

            var normaController = CriaNovaInstancia();

            var response = await normaController.Atualizar(normaModel);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async Task AtualizarNorma_BadRequest()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            norma.AddNotification(new Notification("Norma", "Erro no mapeamento."));
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaApplication.Setup(m => m.Atualizar(It.IsAny<NormaModel>()))
                .ReturnsAsync(Result<Norma>.Error(norma.Notifications));

            var normaController = CriaNovaInstancia();

            var response = await normaController.Atualizar(normaModel);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async Task AtualizarNorma_ErroInterno()
        {
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaApplication.Setup(m => m.Atualizar(It.IsAny<NormaModel>()))
                .Throws(new Exception());

            var normaController = CriaNovaInstancia();

            var response = await normaController.Atualizar(normaModel);

            Assert.Equal(500, ((ObjectResult)response).StatusCode);
        }

        [Fact]
        public async Task ExcluirNorma_Sucesso()
        {
            Guid id = new Guid("327ee256-65d1-4765-b7e8-39a00acb40ff");
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaApplication.Setup(m => m.Excluir(It.IsAny<Guid>()));

            var normaController = CriaNovaInstancia();

            var response = await normaController.Excluir(id);

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task ExcluirNorma_ErroInterno()
        {
            Guid id = new Guid("327ee256-65d1-4765-b7e8-39a00acb40ff");
            Norma norma = FakeNorma.ObterNormaDefault();
            NormaModel normaModel = FakeNorma.ObterNormaModelDefault();

            _mockMapper.Setup(m => m.Map<Norma>(It.IsAny<NormaModel>()))
                .Returns(norma);

            _mockNormaApplication.Setup(m => m.Excluir(It.IsAny<Guid>()))
                .Throws(new Exception());

            var normaController = CriaNovaInstancia();

            var response = await normaController.Excluir(id);

            Assert.Equal(500, ((ObjectResult)response).StatusCode);
        }
    }
}
