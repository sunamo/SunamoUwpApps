namespace apps._public;

public interface IResourceHelper
{
    string GetString(string name);

    Stream GetStream(string name);
}
