# About

A code sample which writes logs to a Microsoft SQL-Server database via [Serilog.Sinks.MSSqlServer](https://www.nuget.org/packages/Serilog.Sinks.MSSqlServer/5.7.1?_src=template) NuGet package.

Here is what is logged, in this case informational.

```
Id	Message	Level	Timestamp	Exception	LogEvent
1	Hello "PayneK" from thread 1	Information	2022-09-05 14:29:45.703	NULL	{"Timestamp":"2022-09-05T14:29:45.7025739","Level":"Information","Message":"Hello \"PayneK\" from thread 1","Properties":{"Name":"PayneK","ThreadId":1}}
```

One of the columns contains json for the log entry

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


# Notes

- This sample comes from [here](https://github.com/serilog-mssql/serilog-sinks-mssqlserver/tree/dev/sample/CombinedConfigDemo) under 
Serilog MSSQL [repository](https://github.com/serilog-mssql). Karen Payne change from `netcoreapp3.1` to `net6.0`
- When considering using a database for logging make sure that the choosen database is up 24x7 else logs may be lost.

