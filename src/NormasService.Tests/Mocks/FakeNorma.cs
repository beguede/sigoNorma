using NormasService.Application.Models;
using NormasService.Domain.Entities;
using System;
using System.Collections.Generic;

namespace NormasService.Tests.Mocks
{
    public static class FakeNorma
    {
        public static Norma ObterNormaDefault()
        {
            Norma norma = new Norma(new Guid("8afcf517-2e58-4c7e-a9c9-132c0ef1947f"))
            {
                Codigo = "ABNT NBR ISO 7113:2017",
                DataPublicacao = new DateTime(2017, 07, 31),
                Status = "Em Vigor",
                Idioma = "Português",
                Titulo = "Máquinas florestais manuais portáteis - Acessórios de corte para roçadeiras - Lâminas metálicas inteiriças",
                Comite = "ABNT/CB-203 Tratores e Máquinas Agrícolas e Florestais",
                Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                Objetivo = "Esta Norma especifica os requisitos para o material e marcação de lâminas metálicas inteiriças para roçadeiras manuais portáteis, bem como as dimensões básicas e tolerâncias para serras circulares destinadas às roçadeiras manuais portáteis."
            };

            return norma;
        }

        public static IList<Norma> ObterListaNormaDefault()
        {
            IList<Norma> listaNorma = new List<Norma>
            {
                new Norma(new Guid("8afcf517-2e58-4c7e-a9c9-132c0ef1947f"))
                {
                    Codigo = "ABNT NBR ISO 7113:2017",
                    DataPublicacao = new DateTime(2017, 07, 31),
                    Status = "Em Vigor",
                    Idioma = "Português",
                    Titulo = "Máquinas florestais manuais portáteis - Acessórios de corte para roçadeiras - Lâminas metálicas inteiriças",
                    Comite = "ABNT/CB-203 Tratores e Máquinas Agrícolas e Florestais",
                    Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                    Objetivo = "Esta Norma especifica os requisitos para o material e marcação de lâminas metálicas inteiriças para roçadeiras manuais portáteis, bem como as dimensões básicas e tolerâncias para serras circulares destinadas às roçadeiras manuais portáteis."
                },
                new Norma(new Guid("83074998-be47-4e8d-b0df-986b354aa3a6"))
                {
                    Codigo = "ABNT NBR ISO 7113:2017",
                    DataPublicacao = new DateTime(2017, 07, 31),
                    Status = "Em Vigor",
                    Idioma = "Português",
                    Titulo = "Máquinas florestais manuais portáteis - Acessórios de corte para roçadeiras - Lâminas metálicas inteiriças",
                    Comite = "ABNT/CB-203 Tratores e Máquinas Agrícolas e Florestais",
                    Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                    Objetivo = "Esta Norma especifica os requisitos para o material e marcação de lâminas metálicas inteiriças para roçadeiras manuais portáteis, bem como as dimensões básicas e tolerâncias para serras circulares destinadas às roçadeiras manuais portáteis."
                }
            };

            return listaNorma;
        }

        public static NormaModel ObterNormaModelDefault()
        {
            NormaModel normaModel = new NormaModel
            {
                Id = new Guid("8afcf517-2e58-4c7e-a9c9-132c0ef1947f"),
                Codigo = "ABNT NBR ISO 7113:2017",
                DataPublicacao = new DateTime(2017, 07, 31),
                Status = "Em Vigor",
                Idioma = "Português",
                Titulo = "Máquinas florestais manuais portáteis - Acessórios de corte para roçadeiras - Lâminas metálicas inteiriças",
                Comite = "ABNT/CB-203 Tratores e Máquinas Agrícolas e Florestais",
                Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                Objetivo = "Esta Norma especifica os requisitos para o material e marcação de lâminas metálicas inteiriças para roçadeiras manuais portáteis, bem como as dimensões básicas e tolerâncias para serras circulares destinadas às roçadeiras manuais portáteis."
            };

            return normaModel;
        }

        public static IList<NormaModel> ObterListaNormaModelDefault()
        {
            IList<NormaModel> listaNormaModel = new List<NormaModel>
            {
                new NormaModel
                {
                    Id = new Guid("8afcf517-2e58-4c7e-a9c9-132c0ef1947f"),
                    Codigo = "ABNT NBR ISO 7113:2017",
                    DataPublicacao = new DateTime(2017, 07, 31),
                    Status = "Em Vigor",
                    Idioma = "Português",
                    Titulo = "Máquinas florestais manuais portáteis - Acessórios de corte para roçadeiras - Lâminas metálicas inteiriças",
                    Comite = "ABNT/CB-203 Tratores e Máquinas Agrícolas e Florestais",
                    Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                    Objetivo = "Esta Norma especifica os requisitos para o material e marcação de lâminas metálicas inteiriças para roçadeiras manuais portáteis, bem como as dimensões básicas e tolerâncias para serras circulares destinadas às roçadeiras manuais portáteis."
                },
                new NormaModel
                {
                    Id = new Guid("83074998-be47-4e8d-b0df-986b354aa3a6"),
                    Codigo = "ABNT NBR ISO 7113:2017",
                    DataPublicacao = new DateTime(2017, 07, 31),
                    Status = "Em Vigor",
                    Idioma = "Português",
                    Titulo = "Máquinas florestais manuais portáteis - Acessórios de corte para roçadeiras - Lâminas metálicas inteiriças",
                    Comite = "ABNT/CB-203 Tratores e Máquinas Agrícolas e Florestais",
                    Organismo = "ABNT - Associação Brasileira de Normas Técnicas",
                    Objetivo = "Esta Norma especifica os requisitos para o material e marcação de lâminas metálicas inteiriças para roçadeiras manuais portáteis, bem como as dimensões básicas e tolerâncias para serras circulares destinadas às roçadeiras manuais portáteis."
                }
            };

            return listaNormaModel;
        }
    }
}
