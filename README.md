# Newtonsoft.Json Formatter for GraphQL Query Builder

![logo](https://raw.githubusercontent.com/charlesdevandiere/graphql-query-builder-formatter-newtonsoftjson/master/logo.png)

A Newtonsoft.Json property name formatter for [GraphQL.Query.Builder](https://github.com/charlesdevandiere/graphql-query-builder-dotnet).

This formatter returns the [JsonPropertyAttribute](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonPropertyAttribute.htm) value.

[![Build Status](https://dev.azure.com/charlesdevandiere/charlesdevandiere/_apis/build/status/charlesdevandiere.graphql-query-builder-formatter-newtonsoftjson?branchName=master)](https://dev.azure.com/charlesdevandiere/charlesdevandiere/_build/latest?definitionId=3&branchName=master)
![Coverage](https://img.shields.io/azure-devops/coverage/charlesdevandiere/charlesdevandiere/6/master)
[![Nuget](https://img.shields.io/nuget/v/GraphQL.Query.Builder.Formatter.NewtonsoftJson.svg?color=blue&logo=nuget)](https://www.nuget.org/packages/GraphQL.Query.Builder.Formatter.NewtonsoftJson)
[![Downloads](https://img.shields.io/nuget/dt/GraphQL.Query.Builder.Formatter.NewtonsoftJson.svg?logo=nuget)](https://www.nuget.org/packages/GraphQL.Query.Builder.Formatter.NewtonsoftJson)

## Install

```console
> dotnet add package GraphQL.Query.Builder.Formatter.NewtonsoftJson
```

## Usage

```csharp
public class Human
{
    [JsonProperty("firstName")]
    public string? FirstName { get; set; }
    
    [JsonProperty("lastName")]
    public string? LastName { get; set; }
}

// Initialize the options
QueryOptions options = new()
{
    Formatter = SystemTextJsonPropertyNameFormatter.Format
};

// Create the query with the options
var query = new Query<Human>("humans", options)
    .AddArguments(new { id = "uE78f5hq" })
    .AddField(h => h.FirstName)
    .AddField(h => h.LastName);

Console.WriteLine("{" + query.Build() + "}");
// Output:
// {humans(id:"uE78f5hq"){firstName lastName}
```
