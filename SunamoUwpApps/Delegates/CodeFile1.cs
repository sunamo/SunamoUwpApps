namespace apps.Delegates;

using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Microsoft.UI.Xaml.Media.Imaging;

public delegate void VoidColor(Color color);
public delegate void VoidStorageFile(StorageFile storageFile);
public delegate void VoidStorageFileBitmapImage(StorageFile storageFile, BitmapImage bitmapImage);
public delegate void VoidStorageFileBitmapImageIBuffer(StorageFile storageFile, BitmapImage bitmapImage, IBuffer buffer);
