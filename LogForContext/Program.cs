﻿using LogForContext.Classes;
using LogForContext.Models;

namespace LogForContext;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Hello[/]");
        SetupLogging.Development();


        Customer.DoSomething();
        Person.DoSomething();
        Person.SomethingElse();


    }
}