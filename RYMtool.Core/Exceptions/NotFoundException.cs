namespace RYMtool.Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string type, int id):base($"the entity {type} was not found with id - {id}")
    {
        
    }
}