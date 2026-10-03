namespace SunamoUwpApps._sunamo;

/// <summary>Common contract of a log message colored by <typeparamref name="Color"/>.</summary>
public interface ILogMessage<Color, StorageClass>
{
    /// <summary>Background color of the message.</summary>
    Color Bg { get; set; }
    /// <summary>Text of the message.</summary>
    string Message { get; }
    /// <summary>Fills the message and returns it.</summary>
    LogMessageAbstract<Color, StorageClass> Initialize(DateTime datum, TypeOfMessage st, string zprava, Color color);
}

/// <summary>Base class of a log message independent of the UI technology.</summary>
public abstract class LogMessageAbstract<Color, StorageClass> : ILogMessage<Color, StorageClass>
{
    /// <summary>Time of creation.</summary>
    public DateTime Dt { get; private set; }
    /// <summary>Type of the message.</summary>
    public TypeOfMessage st { get; private set; }
    /// <summary>Text of the message.</summary>
    public string Message { get; private set; } = null;
    /// <summary>Background color.</summary>
    public Color Bg { get; set; } = default;

    /// <summary>Is here for easy cast LogMessage to generic version.</summary>
    public LogMessageAbstract<Color, StorageClass> Initialize(DateTime dt, TypeOfMessage typeOfMessage, string message, Color color)
    {
        Dt = dt;
        st = typeOfMessage;
        Message = message;
        Bg = color;
        return this;
    }

    /// <summary>Must be method because it works with controls.</summary>
    protected virtual void SetBg(Color c)
    {
    }
}

/// <summary>Base class of a log service independent of the UI technology.</summary>
public abstract class LogServiceAbstract<Color, StorageClass, TextBlock>
{
    /// <summary>Returns background color for the type of message.</summary>
    public abstract Color GetBackgroundBrushOfTypeOfMessage(TypeOfMessage st);
    /// <summary>Returns foreground color for the type of message.</summary>
    public abstract Color GetForegroundBrushOfTypeOfMessage(TypeOfMessage st);

    /// <summary>Reads messages from the file, null by default.</summary>
    protected virtual List<LogMessageAbstract<Color, StorageClass>> ReadMessagesFromFile(StorageClass fileStream)
    {
        return null;
    }

    /// <summary>Initializes the service.</summary>
    public virtual void Initialize(string soubor, bool invariant, TextBlock tssl, Langs l)
    {
    }

    /// <summary>Saves messages to the file.</summary>
    public abstract void SaveToFile();
    /// <summary>Creates an empty message.</summary>
    protected abstract LogMessageAbstract<Color, StorageClass> CreateMessage();
    /// <summary>Adds a message.</summary>
    public abstract LogMessageAbstract<Color, StorageClass> Add(TypeOfMessage st, string status);
}
