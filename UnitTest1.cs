namespace HW_API
{
    public class tests
    {
        private Client client;

        private readonly string localFilePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "files/file.txt");

        [SetUp]
        public void Setup()
        {
            client = new Client();
        }

        [Test, Order(1)]
        public async Task TestUpload()
        {
            var response = await client.UploadFile(localFilePath);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(true, response.Data.is_downloadable);
        }

        [Test, Order(2)]
        public async Task TestGetMetadata()
        {
            var response = await client.GetFileMetadata("/file.txt");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("file.txt", response.Data.name);
        }

        [Test, Order(3)]
        public async Task TestDelete()
        {
            var response = await client.DeleteFile("/file.txt");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(true, response.Data.metadata.is_downloadable);
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }

    }
}