using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using OrderManager.Portable.Infrastructure;

namespace OrderManager.Touch.Infrastructure
{
    public class FileRepository : FileRepositoryBase
    {
        #region Fields

        private const string FileName = "repository.bin";
        private static readonly DataContractSerializer Serializer = new DataContractSerializer(typeof (ItemContainer));

        #endregion

        #region Overrides of FileRepositoryBase

        protected override Task<ItemContainer> LoadDataAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string path = Path.Combine(documents, FileName);
                if (!File.Exists(path))
                    return null;
                using (var memoryStream = new MemoryStream(File.ReadAllBytes(path)))
                    return (ItemContainer) Serializer.ReadObject(memoryStream);
            });
        }

        protected override Task SaveDataAsync(ItemContainer container)
        {
            return Task.Factory.StartNew(() =>
            {
                using (var memoryStream = new MemoryStream())
                {
                    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string path = Path.Combine(folderPath, FileName);
                    Serializer.WriteObject(memoryStream, container);
                    File.WriteAllBytes(path, memoryStream.ToArray());
                }
            });
        }

        #endregion
    }
}