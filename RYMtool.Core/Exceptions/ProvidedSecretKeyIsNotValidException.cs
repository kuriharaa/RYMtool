namespace RYMtool.Core.Exceptions;

public class ProvidedSecretKeyIsNotValidException : Exception
{
    public ProvidedSecretKeyIsNotValidException(string secret):base($"provided key is not valid, provided key - {secret}")
    {
        
    }
}