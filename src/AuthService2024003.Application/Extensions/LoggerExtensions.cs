using System;
using Microsoft.Extensions.Logging;
 
namespace AuthService2024003.Application.Extensions;
 
public static partial class LoggerExtensions
{
    [LoggerMessage(
        EventId = 1001,
        Level = LogLevel.Information,
        Message = "User {Username} registered successfuly"
    )]
    public static partial void LogUserRegistered(this ILogger logger, string username);
 
 
    [LoggerMessage(
        EventId = 1002,
        Level = LogLevel.Information,
        Message = "User login succes"
    )]
    public static partial void LogUserLoggedIn(this ILogger logger);
 
    [LoggerMessage(
        EventId = 1003,
        Level = LogLevel.Warning,
        Message = "Failed login attempt"
    )]
    public static partial void LogFailedLoginAttempt(this ILogger logger);
 
 
    [LoggerMessage(
        EventId = 1004,
        Level = LogLevel.Information,
        Message = "Registration rejected: email already exists"
    )]
    public static partial void LogRegistrationWithExistingEmail(this ILogger logger);
 
 
    [LoggerMessage(
        EventId = 1005,
        Level = LogLevel.Information,
        Message = "User login succes"
    )]
    public static partial void LogRegistrationWithExistingUsername(this ILogger logger);
 
 
    [LoggerMessage(
        EventId = 1006,
        Level = LogLevel.Error,
        Message = "Error uploading profile image"
    )]
    public static partial void LogImageUploadError(this ILogger logger);
 
 
   
 
}
 