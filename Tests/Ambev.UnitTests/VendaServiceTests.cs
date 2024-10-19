using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ambev.API.Services;
using Ambev.API.Services.Dtos;
using Ambev.Data.Interfaces;
using Ambev.Domain.Entities;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.UnitTests
{
    public class VendaServiceTests
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;
        private readonly VendaService _vendaService;

        public VendaServiceTests()
        {
            _vendaRepository = Substitute.For<IVendaRepository>();
            _mapper = Substitute.For<IMapper>();
            _vendaService = new VendaService(_vendaRepository, _mapper);
        }

        [Fact]
        public async Task Adicionar_Should_Add_Venda()
        {
            // Arrange
            var vendaDto = new Bogus.Faker<VendaDTO>()
                .RuleFor(v => v.ClienteId, f => f.Random.Guid())
                .RuleFor(v => v.Filial, f => f.Random.Guid())
                .RuleFor(v => v.Numero, f => f.Random.Int(1, 1000))
                .Generate();

            var venda = new Venda(vendaDto.ClienteId, vendaDto.Filial, new List<ItemVenda>());

            _mapper.Map<Venda>(vendaDto).Returns(venda);
            _vendaRepository.CreateAsync(venda).Returns(venda);
            _mapper.Map<VendaDTO>(venda).Returns(vendaDto);

            // Act
            var result = await _vendaService.Adicionar(vendaDto);

            // Assert
            result.Should().NotBeNull();
            result.ClienteId.Should().Be(vendaDto.ClienteId);
            result.Numero.Should().Be(vendaDto.Numero);
            await _vendaRepository.Received(1).CreateAsync(Arg.Any<Venda>());
        }

        [Fact]
        public async Task BuscarPorId_Should_Return_Venda()
        {
            // Arrange
            var id = Guid.NewGuid();
            var venda = new Venda(id);
            var vendaDto = new VendaDTO { Id = id };

            _vendaRepository.GetByIdAsync(id).Returns(venda);
            _mapper.Map<VendaDTO>(venda).Returns(vendaDto);

            // Act
            var result = await _vendaService.BuscarPorId(id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
            await _vendaRepository.Received(1).GetByIdAsync(id);
        }

        [Fact]
        public async Task Atualizar_Should_Update_Venda()
        {
            // Arrange
            var id = Guid.NewGuid();
            var vendaDto = new VendaDTO { Id = id, Numero = 123 };

            var venda = new Bogus.Faker<Venda>()
                .RuleFor(v => v.Numero, vendaDto.Numero)
                .Generate();

            _mapper.Map<Venda>(vendaDto).Returns(venda);

            // Act
            var result = await _vendaService.Atualizar(id, vendaDto);

            // Assert
            result.Should().NotBeNull();
            result.Numero.Should().Be(vendaDto.Numero);
            await _vendaRepository.Received(1).UpdateAsync(id, Arg.Any<Venda>());
        }
    }
}

