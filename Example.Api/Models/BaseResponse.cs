namespace AssetManagement.Api.Models;

/// <summary>
/// Interface for all Api Response
/// </summary>
public interface IApiResponse { }

/// <summary>
/// Base Response Interface for all Api Response
/// </summary>
public interface IBaseResponse
{
    /// <summary>
    /// Response Status Success or Fail 
    /// </summary>
    /// <example>true</example>
    public bool Status { get; }
}

/// <summary>
/// Response if Success without Data
/// </summary>
public class SuccessResponse : IBaseResponse
{
    /// <summary>
    /// Response Status Success or Fail
    /// </summary>
    /// <example>true</example>
    public bool Status => true;
}

/// <summary>
/// Response if Success with Data
/// </summary>
/// <typeparam name="TData"></typeparam>
public class SuccessResponse<TData> : SuccessResponse where TData : IApiResponse
{
    /// <summary>
    /// Response Data From Api
    /// </summary>
    public required TData Data { get; set; }
}

/// <summary>
/// Response if Success with List of Data
/// </summary>
/// <typeparam name="TData"></typeparam>
public class SuccessListResponse<TData> : SuccessResponse where TData : IApiResponse
{
    /// <summary>
    /// Response Data From Api
    /// </summary>
    public required List<TData> Data { get; set; }
}

/// <summary>
/// Response if Fail
/// </summary>
public class FailResponse : IBaseResponse
{
    public bool Status => false;

    /// <summary>
    /// Response Code if Fail
    /// </summary>
    /// <example>nocode</example>
    public string Code { get; set; } = "nocode";

    /// <summary>
    /// Response Message if Fail
    /// </summary>
    /// <example>some error message</example>
    public string Message { get; set; } = "Somthing went wrong";
}