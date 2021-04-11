using AutoMapper;
using NormasService.Application.Mapping;
using NormasService.Application.Models;
using NormasService.Domain.Entities;
using NormasService.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NormasService.Tests.Maps
{
    public class NormaMapTest
    {
        [Fact]
        public void NormaModel_Map_Norma_Sucesso()
        {
            var normaDefault = FakeNorma.ObterNormaDefault();
            var normaModelDefault = FakeNorma.ObterNormaModelDefault();

            var mapper = new MapperConfiguration(c => c.AddProfile<NormaMap>()).CreateMapper();

            var norma = mapper.Map<NormaModel, Norma>(normaModelDefault);

            Assert.Equal(normaDefault.Id, norma.Id);
            Assert.Equal(normaDefault.Codigo, norma.Codigo);
            Assert.Equal(normaDefault.Comite, norma.Comite);
            Assert.Equal(normaDefault.DataPublicacao, norma.DataPublicacao);
            Assert.Equal(normaDefault.Idioma, norma.Idioma);
            Assert.Equal(normaDefault.Status, norma.Status);
            Assert.Equal(normaDefault.Objetivo, norma.Objetivo);
            Assert.Equal(normaDefault.Organismo, norma.Organismo);
            Assert.Equal(normaDefault.Titulo, norma.Titulo);
        }

        [Fact]
        public void Norma_Map_NormaModel_Sucesso()
        {
            var normaModelDefault = FakeNorma.ObterNormaModelDefault();
            var normaDefault = FakeNorma.ObterNormaDefault();

            var mapper = new MapperConfiguration(c => c.AddProfile<NormaMap>()).CreateMapper();

            var normaModel = mapper.Map<Norma, NormaModel>(normaDefault);

            Assert.Equal(normaModelDefault.Id, normaModel.Id);
            Assert.Equal(normaModelDefault.Codigo, normaModel.Codigo);
            Assert.Equal(normaModelDefault.Comite, normaModel.Comite);
            Assert.Equal(normaModelDefault.DataPublicacao, normaModel.DataPublicacao);
            Assert.Equal(normaModelDefault.Idioma, normaModel.Idioma);
            Assert.Equal(normaModelDefault.Status, normaModel.Status);
            Assert.Equal(normaModelDefault.Objetivo, normaModel.Objetivo);
            Assert.Equal(normaModelDefault.Organismo, normaModel.Organismo);
            Assert.Equal(normaModelDefault.Titulo, normaModel.Titulo);
        }
    }
}
