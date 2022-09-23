// See https://aka.ms/new-console-template for more information

var pb = new PersonBuilder();
var person = pb.Called("Dmitri").WorksAsA("Programmer").Build();

public class Person
{
    public string Name, Position;
}

public sealed class PersonBuilder
{
    public readonly List<Action<Person>> Actions
        = new List<Action<Person>>();

    public PersonBuilder Called(string name)
    {
        Actions.Add(p => { p.Name = name; });
        return this;
    }

    public Person Build()
    {
        var p = new Person();
        Actions.ForEach(a => a(p));
        return p;
    }
}

public static class PersonBuilderExtensions
{
    public static PersonBuilder WorksAsA
        (this PersonBuilder builder, string position)
    {
        builder.Actions.Add(p => { p.Position = position; });
        return builder;
    }
}