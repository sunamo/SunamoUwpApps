namespace apps.Delegates;

using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Microsoft.UI.Xaml.Media.Imaging;

/// <summary>
/// Represents the void color type.
/// </summary>
public delegate void VoidColor(Color color);
/// <summary>
/// Represents the void storage file type.
/// </summary>
public delegate void VoidStorageFile(StorageFile storageFile);
/// <summary>
/// Represents the void storage file bitmap image type.
/// </summary>
public delegate void VoidStorageFileBitmapImage(StorageFile storageFile, BitmapImage bitmapImage);
/// <summary>
/// Represents the void storage file bitmap image i buffer type.
/// </summary>
public delegate void VoidStorageFileBitmapImageIBuffer(StorageFile storageFile, BitmapImage bitmapImage, IBuffer buffer);
