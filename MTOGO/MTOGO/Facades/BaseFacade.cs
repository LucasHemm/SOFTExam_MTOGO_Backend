namespace MTOGO.Facades;

public abstract class BaseFacade
{
    protected readonly HttpClient _httpClient;

    protected BaseFacade(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

   
}
