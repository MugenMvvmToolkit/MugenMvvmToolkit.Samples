using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using OrderManager.Portable.Infrastructure;

namespace OrderManager.Wpf.Infrastructure
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
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
            if (!File.Exists(path))
                return Task.FromResult<ItemContainer>(null);
            using (var memoryStream = new MemoryStream(File.ReadAllBytes(path)))
                return Task.FromResult((ItemContainer) Serializer.ReadObject(memoryStream));
        }

        protected override Task SaveDataAsync(ItemContainer container)
        {
            using (var memoryStream = new MemoryStream())
            {
                Serializer.WriteObject(memoryStream, container);
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
                File.WriteAllBytes(path, memoryStream.ToArray());
                return Empty.TrueTask;
            }
        }

        #endregion
    }
}