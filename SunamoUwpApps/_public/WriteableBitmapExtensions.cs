namespace apps._public;

using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;

/// <summary>Mode of access to the pixels of a bitmap.</summary>
public enum ReadWriteMode
{
    /// <summary>Pixels are only read.</summary>
    ReadOnly,
    /// <summary>Pixels are read and written.</summary>
    ReadWrite
}

/// <summary>Scope of access to the pixels of a bitmap, the bitmap is invalidated when the scope ends.</summary>
public sealed class BitmapContext : IDisposable
{
    private readonly ReadWriteMode mode;

    /// <summary>Bitmap the context works with.</summary>
    public WriteableBitmap WriteableBitmap { get; }

    /// <summary>Creates the context over the bitmap.</summary>
    public BitmapContext(WriteableBitmap bitmap, ReadWriteMode mode)
    {
        WriteableBitmap = bitmap;
        this.mode = mode;
    }

    /// <summary>Invalidates the bitmap when it was opened for writing.</summary>
    public void Dispose()
    {
        if (mode == ReadWriteMode.ReadWrite)
        {
            WriteableBitmap.Invalidate();
        }
    }
}

/// <summary>Creates bitmaps.</summary>
public static class BitmapFactory
{
    /// <summary>Creates an empty bitmap of the size.</summary>
    public static WriteableBitmap New(int width, int height)
    {
        return new WriteableBitmap(width, height);
    }
}

/// <summary>Pixel level operations over <see cref="WriteableBitmap"/> (BGRA, 4 bytes per pixel).</summary>
public static class WriteableBitmapExtensions
{
    /// <summary>Opens the context for accessing pixels.</summary>
    public static BitmapContext GetBitmapContext(this WriteableBitmap bitmap, ReadWriteMode mode)
    {
        return new BitmapContext(bitmap, mode);
    }

    /// <summary>Returns the color of the pixel.</summary>
    public static Color GetPixel(this WriteableBitmap bitmap, int x, int y)
    {
        var data = bitmap.PixelBuffer.ToArray();
        var index = (y * bitmap.PixelWidth + x) * 4;
        return Color.FromArgb(data[index + 3], data[index + 2], data[index + 1], data[index]);
    }

    /// <summary>Sets the color of the pixel.</summary>
    public static void SetPixel(this WriteableBitmap bitmap, int x, int y, Color color)
    {
        var index = (y * bitmap.PixelWidth + x) * 4;
        using var stream = bitmap.PixelBuffer.AsStream();
        stream.Position = index;
        stream.Write(new[] { color.B, color.G, color.R, color.A }, 0, 4);
    }

    /// <summary>Copies the pixels of the buffer to the bitmap.</summary>
    public static Task<WriteableBitmap> FromPixelBuffer(this WriteableBitmap bitmap, IBuffer buffer, int width, int height)
    {
        var data = buffer.ToArray();
        using (var stream = bitmap.PixelBuffer.AsStream())
        {
            stream.Write(data, 0, Math.Min(data.Length, (int)bitmap.PixelBuffer.Capacity));
        }
        bitmap.Invalidate();
        return Task.FromResult(bitmap);
    }

    /// <summary>Decodes the image of the stream to the bitmap.</summary>
    public static async Task<WriteableBitmap> FromStream(this WriteableBitmap bitmap, IRandomAccessStream stream, BitmapPixelFormat pixelFormat)
    {
        stream.Seek(0);
        var decoder = await BitmapDecoder.CreateAsync(stream);
        var pixels = await decoder.GetPixelDataAsync(pixelFormat, BitmapAlphaMode.Straight, new BitmapTransform(), ExifOrientationMode.IgnoreExifOrientation, ColorManagementMode.DoNotColorManage);
        var data = pixels.DetachPixelData();
        using (var target = bitmap.PixelBuffer.AsStream())
        {
            target.Write(data, 0, Math.Min(data.Length, (int)bitmap.PixelBuffer.Capacity));
        }
        bitmap.Invalidate();
        return bitmap;
    }
}
