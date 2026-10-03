#define ASYNC
namespace SunamoUwpApps._sunamo;

public interface ISunamoComparer<T>
{
    int Desc(T x, T y);
    int Asc(T x, T y);
}
