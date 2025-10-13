using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using Xunit;

namespace BusinessLogic.Tests;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepoMock = new();
    private readonly Mock<IRepositoryWrapper> _repoMock = new();
    private readonly UserService _service;

    public UserServiceTests()
    {
        _repoMock.Setup(r => r.User).Returns(_userRepoMock.Object);
        _service = new UserService(_repoMock.Object);
    }

    [Fact]
    public async Task CreateAsync_NullUser_ShouldThrowArgumentNullException()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(null!));
    }

    [Theory]
    [MemberData(nameof(GetInvalidUsers))]
    public async Task CreateAsync_InvalidUser_ShouldThrowArgumentException(User invalidUser)
    {
        var ex = await Assert.ThrowsAsync<ArgumentException>(() => _service.Create(invalidUser));
        _userRepoMock.Verify(r => r.Create(It.IsAny<User>()), Times.Never);
        _repoMock.Verify(r => r.Save(), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_ValidUser_ShouldCallCreateAndSave()
    {
        var newUser = new User
        {
            username = "tester",
            email = "test@example.com",
            password_hash = "hash",
            is_active = true,
            created_at = DateTime.UtcNow
        };

        await _service.Create(newUser);

        _userRepoMock.Verify(r => r.Create(It.Is<User>(u => ReferenceEquals(u, newUser))), Times.Once);
        _repoMock.Verify(r => r.Save(), Times.Once);
    }

    public static IEnumerable<object[]> GetInvalidUsers()
    {
        // username пустой
        yield return new object[] { new User { username = "", email = "e@e.com", password_hash = "h" } };
        // email пустой
        yield return new object[] { new User { username = "ok", email = "", password_hash = "h" } };
        // пароль пустой
        yield return new object[] { new User { username = "ok", email = "e@e.com", password_hash = "" } };
        // username слишком короткий
        yield return new object[] { new User { username = "ab", email = "e@e.com", password_hash = "h" } };
    }
}
