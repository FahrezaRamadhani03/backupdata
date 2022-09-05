using Garuda.Modules.Hangfire.Configurations;
using Garuda.Modules.Hangfire.Services;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Garuda.Modules.HangfireTest.Services
{
    [TestFixture]
    public class BackgroundJobManagerTests
    {
        private BackgroundJobCollection subBackgroundJobCollection;
        private IServiceScopeFactory subServiceScopeFactory;
        private BackgroundJobManager backgroundJobManager;

        [SetUp]
        public void SetUp()
        {
            this.subBackgroundJobCollection = Substitute.For<BackgroundJobCollection>();
            this.subServiceScopeFactory = Substitute.For<IServiceScopeFactory>();
            this.backgroundJobManager = new BackgroundJobManager(
                this.subBackgroundJobCollection,
                this.subServiceScopeFactory);
        }

        [Test]
        public async Task EnqueueAsync_StateUnderTest_ExpectedBehavior<TArgs>()
        {
            // Arrange
            TArgs args = default(TArgs);
            TimeSpan? delay = null;
            DateTimeOffset? enqueueAt = null;

            // Act
            var result = await backgroundJobManager.EnqueueAsync(
                args,
                delay,
                enqueueAt);

            // Assert
            Assert.Fail();
        }
    }
}
