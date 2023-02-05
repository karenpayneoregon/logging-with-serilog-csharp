# About

A code sample which writes logs to a Microsoft SQL-Server database via [Serilog.Sinks.MSSqlServer](https://www.nuget.org/packages/Serilog.Sinks.MSSqlServer/5.7.1?_src=template) NuGet package.

![Figure1](assets/figure1.png)

Here is what is logged, in this case informational.

```
Id	Message	Level	Timestamp	Exception	LogEvent
1	Hello "PayneK" from thread 1	Information	2022-09-05 14:29:45.703	NULL	{"Timestamp":"2022-09-05T14:29:45.7025739","Level":"Information","Message":"Hello \"PayneK\" from thread 1","Properties":{"Name":"PayneK","ThreadId":1}}
```

One of the columns contains json for the log entry which can be read from EF Core 7 if so desire.

```json
{
  "Timestamp": "2022-09-05T14:29:45.7025739",
  "Level": "Information",
  "Message": "Hello \"PayneK\" from thread 1",
  "Properties": {
    "Name": "PayneK",
    "ThreadId": 1
  }
}
```


