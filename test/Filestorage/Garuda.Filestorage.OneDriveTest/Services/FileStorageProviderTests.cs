using Garuda.Filestorage.Configurations;
using Garuda.Filestorage.OneDrive.Services;
using Garuda.Filestorage.Requests;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Garuda.Filestorage.OneDriveTest.Services
{
    [TestFixture]
    public class FileStorageProviderTests
    {
        private IOptions<FileStorageOptions> subOptions;
        private FileStorageProvider provider;

        [SetUp]
        public void SetUp()
        {
            this.subOptions = Substitute.For<IOptions<FileStorageOptions>>();
            this.provider = new FileStorageProvider(this.subOptions);
        }

        [Test]
        public void GetClient_StateUnderTest_ExpectedBehavior()
        {
            // Act
            var result = provider.GetClient();

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetToken_StateUnderTest_ExpectedBehavior()
        {
            // Act
            var result = await provider.GetToken();

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task CheckLoggedInUser_StateUnderTest_ExpectedBehavior()
        {
            // Act
            var result = await provider.CheckLoggedInUser();

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task UploadFile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            FileUploadFormRequest file = null;

            // Act
            var result = await provider.UploadFile(
                file);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task UploadFileByString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            FileUploadBase64Request file = null;

            // Act
            var result = await provider.UploadFileByString(
                file);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetFile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string fileId = null;
            string parentId = null;
            string pathDownload = null;

            // Act
            var result = await provider.GetFile(
                fileId,
                parentId,
                pathDownload);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task DeleteAvatar_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string avatar = null;

            // Act
            await provider.DeleteAvatar(
                avatar);

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetFilesByName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string fileName = null;
            string parentId = null;

            // Act
            var result = await provider.GetFilesByName(
                fileName,
                parentId);

            // Assert
            Assert.Fail();
        }
    }
}
