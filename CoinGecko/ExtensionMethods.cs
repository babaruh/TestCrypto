namespace CoinGecko;

public static class ExtensionMethods
{
    // Add a parameter
    public static void AddParameter(
        this Dictionary<string, object> parameters,
        string key,
        string value)
    {
        parameters.Add(key, value);
    }
    
    // Add an optional parameter. Not added if value is null
    public static void AddOptionalParameter(
        this Dictionary<string, object> parameters,
        string key,
        object? value)
    {
        if (value == null)
            return;
        parameters.Add(key, value);
    }
    
    //Append a base url with provided path
    public static string AppendPath(this string url, params string[] path)
    {
        if (!url.EndsWith("/"))
            url += "/";
        
        url = path.Aggregate(url, (current, str) => current + str.Trim('/') + "/");
        
        return url.TrimEnd('/');
    }
}