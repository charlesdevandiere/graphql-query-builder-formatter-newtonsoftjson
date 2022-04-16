using System;
using System.Reflection;
using Xunit;

namespace GraphQL.Query.Builder.Formatter.NewtonsoftJson.UnitTests;

public class NewtonsoftJsonPropertyNameFormatterTests
{
    [Fact]
    public void Format_ShouldReturnAttributeValue()
    {
        PropertyInfo? property = typeof(Car).GetProperty(nameof(Car.Identifier));
        string value = NewtonsoftJsonPropertyNameFormatter.Format.Invoke(property);

        Assert.Equal("id", value);
    }

    [Fact]
    public void Format_ShouldThrowIfPropertyIfNull()
    {
        Assert.Throws<ArgumentNullException>(() => NewtonsoftJsonPropertyNameFormatter.Format.Invoke(null));
    }

    [Fact]
    public void Format_ShouldReturnPropertyNameIfThereIsNoAttribute()
    {
        PropertyInfo? property = typeof(Car).GetProperty(nameof(Car.Speed));
        string value = NewtonsoftJsonPropertyNameFormatter.Format.Invoke(property);

        Assert.Equal(nameof(Car.Speed), value);
    }
}
