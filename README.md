# appsettings
```json
"AppSettings" : {
"SecretKey" : "your-secret-key"
}
```
# creating new query
```csharp 
public class NewQuery:Query<Entity>, ITypeResultQuery{
    protected override IQueryable<Album> GetQuery(DbSet<Entity> dbSet){
        //your query goes here
    }
}
```
## invoke query
```csharp
var result = await _repository.ListAsync(new NewQuery());
```
