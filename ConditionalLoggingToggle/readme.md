# About

This is a companion utility to the project `ConditionalLogging` which allows logging to be disabled from reading a setting in appsettings.json file.

The `appsettings.json` file for `ConditionalLogging` project. By setting `Debug.LogSqlCommand` to `false` turns off logging while `true` enables logging.

```json
{
  "ConnectionsConfiguration": {
    "ActiveEnvironment": "Development",
    "Development": "Data Source=.\\sqlexpress;Initial Catalog=TODO;Integrated Security=True;Encrypt=False",
    "Stage": "Stage connection string goes here",
    "Production": "Prod connection string goes here"
  },
  "Debug": {
    "LogSqlCommand": false
  }
}
```

## Why use this utility?

Anytime someone manually edits a json file opens the door for creating a malformed file so we provide this utility.


## How it works

- Finds the executable folder for `ConditionalLogging` and checks to see if it's appsettings.json file exists
    - If not inform the user the file was not found
    - If found get `Debug.LogSqlCommand`, prompt to toggle
    - Press <kbd>enter</kbd> or <kbd>Y</kbd> will toggle the setting while <kbd>N</kbd> makes no changes

### Real life

- Recommend installing this utility one folder below the parent application and adjust obtaining the path to `appsettings.json`
- Provides instructions to a engineer for the utility and exactly what it does.
- Ensure the person running the utility has proper permissions to edit the file.