using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Storage;
using OrderManager.Portable.Infrastructure;

namespace OrderManager.WindowsPhone.Infrastructure
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
            string path = Path.Combine(@"\data\", FileName);
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.FileExists(path))
                    return Task.FromResult<ItemContainer>(null);
                using (var fileStream = new IsolatedStorageFileStream(path, FileMode.Open, store))
                    return Task.FromResult((ItemContainer) Serializer.ReadObject(fileStream));
            }
        }

        protected override async Task SaveDataAsync(ItemContainer container)
        {
            StorageFolder local = ApplicationData.Current.LocalFolder;
            StorageFolder dataFolder = await local.CreateFolderAsync("data", CreationCollisionOption.OpenIfExists);
            StorageFile file = await dataFolder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
            using (Stream storageFileStream = await file.OpenStreamForWriteAsync())
                Serializer.WriteObject(storageFileStream, container);
        }

        #endregion
    }
}