using Demo.WebAPI.Tests.Config;

namespace Demo.WebAPI.Tests;

[Collection(nameof(IntegrationApiTestsFixtureCollection))]
public class DemoControllerTests
{
    private readonly IntegrationTestsFixture _testsFixture;

    public DemoControllerTests(IntegrationTestsFixture testsFixture)
        => _testsFixture = testsFixture;


    [Fact]
    public async void Logger_Trace_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo/trace");


        // Assert
        act.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void Logger_Debug_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo/debug");


        // Assert
        act.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void Logger_Info_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo/info");


        // Assert
        act.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void Logger_Warning_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo/warning");


        // Assert
        act.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void Logger_Error_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo/error");


        // Assert
        act.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void LoggerException_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo/exception");


        // Assert
        act.EnsureSuccessStatusCode();
    }

    [Fact]
    public async void Logger_Critical_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo/critical");


        // Assert
        act.EnsureSuccessStatusCode();
    }
}
