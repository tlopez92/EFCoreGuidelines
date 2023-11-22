using EfCore.Testing.SimpleApi.Controllers;
using EfCore.Testing.SimpleApi.Models;
using EfCore.Testing.SimpleApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace EfCore.Testing.Tests.Repositories;

public class RepositoryTest
{
    [Fact]
    public async Task IfGenreExists_ReturnsGenre()
    {
        // Arrange
        var repository = Substitute.For<IGenreRepository>();
        repository.Get(2)!.Returns(Task.FromResult(new Genre { Id = 2, Name = "Action" }));
        var controller = new GenresWithRepositoryController(repository);
        
        // Act
        var result = await controller.Get(2);
        var okResult = result as OkObjectResult;
        
        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
        Assert.Equal("Action", (okResult.Value as Genre)?.Name);
        await repository.Received().Get(2);
    }
}