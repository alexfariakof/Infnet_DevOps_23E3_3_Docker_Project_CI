using System.Net;
using Infnet_DevOps_23E3_3_Docker_Project.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Moq;
using Moq.Protected;

namespace Infnet_DevOps_23E3_3_Docker_Project_Test.HealthChecks
{
    public class HealthCheckRandomTests
    {
        [Fact]
        public async Task HealthCheckRandom_ShouldReturnHealthy()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            var client = new HttpClient(mockMessageHandler.Object);

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                });

            httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

            var healthCheck = new HealthCheckRandom(httpClientFactoryMock.Object);

            // Act
            var healthCheckResult = await healthCheck.CheckHealthAsync(new HealthCheckContext(), CancellationToken.None);

            // Assert
            Assert.Equal(HealthStatus.Healthy, healthCheckResult.Status);
        }

        [Fact]
        public async Task HealthCheckRandom_ShouldReturnUnhealthy()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            var client = new HttpClient(mockMessageHandler.Object);

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                });

            httpClientFactoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

            var healthCheck = new HealthCheckRandom(httpClientFactoryMock.Object);

            // Act
            var healthCheckResult = await healthCheck.CheckHealthAsync(new HealthCheckContext(), CancellationToken.None);

            // Assert
            Assert.Equal(HealthStatus.Unhealthy, healthCheckResult.Status);
        }
    }
}
