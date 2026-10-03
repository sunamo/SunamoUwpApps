namespace apps._public;

public interface ISimpleConverterT<TOutput, TInput>
{
    TOutput ConvertTo(TInput value);
    TInput? ConvertFrom(TOutput value);
}
