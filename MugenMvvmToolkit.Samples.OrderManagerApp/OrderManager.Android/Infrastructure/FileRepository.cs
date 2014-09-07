using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using OrderManager.Portable.Infrastructure;

namespace OrderManager.Android.Infrastructure
{
    public class FileRepository : FileRepositoryBase
    {
        #region Fields

        private const string FileName = "repository.bin";
        private static readonly DataContractSerializer Serializer = new DataContractSerializer(typeof(ItemContainer));

        #endregion

        #region Overrides of FileRepositoryBase

        protected override Task<ItemContainer> LoadDataAsync()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(folderPath, FileName);
            if (!File.Exists(path))
                return Task.FromResult<ItemContainer>(null);
            using (var memoryStream = new MemoryStream(File.ReadAllBytes(path)))
                return Task.FromResult((ItemContainer)Serializer.ReadObject(memoryStream));
        }

        protected override Task SaveDataAsync(ItemContainer container)
        {
            using (var memoryStream = new MemoryStream())
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string path = Path.Combine(folderPath, FileName);
                Serializer.WriteObject(memoryStream, container);
                File.WriteAllBytes(path, memoryStream.ToArray());
                return Empty.Task;
            }
        }

        #endregion
    }
}