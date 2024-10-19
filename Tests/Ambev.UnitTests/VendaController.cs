namespace Ambev.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Ambev.API.Controllers;
    using Ambev.API.Services.Dtos;
    using Ambev.API.Services.Interfaces;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using NSubstitute;
    using Xunit;

    public class VendaControllerTests
    {
        private readonly IVendaService _vendaService;
        private readonly VendaController _controller;

        public VendaControllerTests()
        {
            _vendaService = Substitute.For<IVendaService>();
            _controller = new VendaController(_vendaService);
        }

        [Fact]
        public async Task GetAll_Should_Return_Ok_With_Data()
        {
            // Arrange
            var vendas = new Bogus.Faker<VendaDTO>()
                .RuleFor(v => v.ClienteId, f => f.Random.Guid())
                .Generate(3);

            _vendaService.BuscarTodos().Returns(vendas);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(vendas);
        }

        [Fact]
        public async Task Create_Should_Return_Ok_When_Valid()
        {
            // Arrange
            var vendaDto = new Bogus.Faker<VendaDTO>()
                .RuleFor(v => v.ClienteId, f => f.Random.Guid())
                .RuleFor(v => v.Filial, f => f.Random.Guid())
                .Generate();

            _vendaService.Adicionar(vendaDto).Returns(vendaDto);

            // Act
            var result = await _controller.Create(vendaDto);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(vendaDto);
        }

        [Fact]
        public async Task GetByNumber_Should_Return_NotFound_When_NotExists()
        {
            // Arrange
            int number = 123;
            _vendaService.BuscarPorNumero(number).Returns((VendaDTO)null);

            // Act
            var result = await _controller.GetByNumber(number);

            // Assert
            var notFoundResult = result.Result as NotFoundResult;
            notFoundResult.Should().NotBeNull();
        }
    }

}