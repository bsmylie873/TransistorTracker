using System.Diagnostics.CodeAnalysis;
using TransistorTracker.Api.Extensions;

namespace TransistorTracker.Api;

[ExcludeFromCodeCoverage] 
public static class EnvironmentVariables
{
    private static string DbConnectionStringKey => "DbConnectionString";

    public static string? DbConnectionString => DbConnectionStringKey.GetValue("Server=localhost;Port=5432;Database=transistor-tracker;User Id=transistor-tracker;Password=password1;");
}