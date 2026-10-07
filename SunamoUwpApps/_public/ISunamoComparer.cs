namespace apps._public;


public interface ISunamoComparer<T>
{
    int Desc(T first, T second);
    int Asc(T first, T second);
}
