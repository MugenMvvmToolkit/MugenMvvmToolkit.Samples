using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Storage;
using OrderManager.Portable.Infrastructure;

namespace OrderManager.WinRT.Infrastructure
{
    public class FileRepository : FileRepositoryBase
    {
        #region Fields

        private const string FileName = "repository.bin";
        private static readonly DataContractSerializer Serializer = new DataContractSerializer(typeof (ItemContainer));

        #endregion

        #region Overrides of FileRepositoryBase

        protected override async Task<ItemContainer> LoadDataAsync()
        {
            IReadOnlyList<StorageFile> files = await ApplicationData.Current.LocalFolder.GetFilesAsync();
            StorageFile file = files.FirstOrDefault(f => f.Name == FileName);
            if (file == null)
                return null;
            using (Stream fileStream = await file.OpenStreamForReadAsync())
            {
                var serializer = new DataContractSerializer(typeof (ItemContainer));
                return (ItemContainer) serializer.ReadObject(fileStream);
            }
        }

        protected override async Task SaveDataAsync(ItemContainer container)
        {
            StorageFile file = await ApplicationData
                .Current
                .LocalFolder
                .CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
            using (var ms = new MemoryStream())
            using (Stream fileStream = await file.OpenStreamForWriteAsync())
            {
                Serializer.WriteObject(ms, container);
                ms.Seek(0, SeekOrigin.Begin);
                await ms.CopyToAsync(fileStream);
            }
        }

        #endregion
    }
}