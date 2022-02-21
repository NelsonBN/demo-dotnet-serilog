using Demo.WebAPI.Tests.Config;

namespace Demo.WebAPI.Tests;

[Collection(nameof(IntegrationApiTestsFixtureCollection))]
public class DemoLogLevelControllerTests
{
    private readonly IntegrationTestsFixture _testsFixture;

    public DemoLogLevelControllerTests(IntegrationTestsFixture testsFixture)
        => _testsFixture = testsFixture;


    [Fact]
    public async void Logger_Trace_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo-log-level/trace");


        // Assert
        act.Should()
            .Match(m => m.IsSuccessStatusCode);
    }

    [Fact]
    public async void Logger_Debug_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo-log-level/debug");


        // Assert
        act.Should()
            .Match(m => m.IsSuccessStatusCode);
    }

    [Fact]
    public async void Logger_Info_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo-log-level/info");


        // Assert
        act.Should()
            .Match(m => m.IsSuccessStatusCode);
    }

    [Fact]
    public async void Logger_Warning_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo-log-level/warning");


        // Assert
        act.Should()
            .Match(m => m.IsSuccessStatusCode);
    }

    [Fact]
    public async void Logger_Error_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo-log-level/error");


        // Assert
        act.Should()
            .Match(m => m.IsSuccessStatusCode);
    }

    [Fact]
    public async void LoggerException_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo-log-level/exception");


        // Assert
        act.Should()
            .Match(m => m.IsSuccessStatusCode);
    }

    [Fact]
    public async void Logger_Critical_200()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("demo-log-level/critical");


        // Assert
        act.Should()
            .Match(m => m.IsSuccessStatusCode);
    }
}
