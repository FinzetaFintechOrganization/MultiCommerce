using System;
using System.Collections.Generic;

public class ErrorResponseDto
{
    public string ErrorCode { get; set; }  
    public string Message { get; set; }    
    public int StatusCode { get; set; }     
    public string TraceId { get; set; }  
    public DateTime Timestamp { get; set; } 
    public Dictionary<string, List<string>> Errors { get; set; }
}
