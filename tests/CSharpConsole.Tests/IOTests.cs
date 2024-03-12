using System.Text;
using Xunit;

namespace CSharpConsole.Tests
{

    public class IoTests : IAsyncLifetime
    {
        private readonly string _tempFile = Path.Combine(Path.GetTempPath(), "test.txt");
        
        public Task InitializeAsync()
        {
            Console.WriteLine($"tmpFile: {_tempFile}");
            return Task.CompletedTask;
        }

        public Task DisposeAsync()
        {
            // nothing to do
            return Task.CompletedTask;
        }


        [Fact]
        public void CreateATempFileFromScratch()
        {
            if(File.Exists(_tempFile))
            {
                Console.WriteLine("Deleting temp file...");
                File.Delete(_tempFile);
            }
            File.Create(_tempFile).Close();
        }
        
        [Fact]
        public void TestReadWriteToFile()
        {
            const string content = "Hello, C# World!";
            Console.WriteLine($"tempFile: {_tempFile}");
            
            // write to file
            File.WriteAllText(_tempFile, content);
            
            // read from file
            var fileContent = File.ReadAllText(_tempFile, Encoding.UTF8);
            Console.WriteLine($"content: {fileContent}");
            
            // asserts
            Assert.Equal(content, fileContent);
        }

        [Fact]
        public void WriteMultiLinesToFile()
        {
            var text = 
                $"""
                    tempFile: {_tempFile}
                    content: Hello, C# World!
                """.TrimIdent();
            
            File.WriteAllText(_tempFile, text);

            var lines = File.ReadLines(_tempFile).ToList();
            lines.ForEach(Console.WriteLine);
            
            Assert.Equal(2, lines.Count);
        }
    }
}