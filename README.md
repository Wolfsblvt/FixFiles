# FixFiles
Fix common file errors, problems and coding guidelines for phpBB extension files.

![FixFiles Console Output](http://i.imgur.com/gBvL8by.png)

## Installation
To install this tool, you need to build the project and use the generated `FixFiles.exe`.
Otherwise you can take the latest exe from https://github.com/Wolfsblvt/FixFiles/releases

You should use the executable in your **Extension path** (So at `.\phpBB\ext`), or you have to specify the correct folder with `--folder` everytime you run the tool.
To run it, you can simply click on the file and it will open and ask what you want to do, or you can call it via command line and add parameters.

## Help
Following Parameters are allowed

| Parameter | Help Text |
| --------- | --------- |
| --help | Displays this help |
| --folder `your/folder` | Specify the folder in wich all files (recursive) should be fixed |
| --filetypes `*.xxx,*.xxx` | Specify the filetypes wich should be fixed |
| --guidelines | If this parameter is set, some general coding guidelines will be done automatically (like formatting tabs and empty lines) |
| --force | Force execution without interruption |

**Please note:** When you run this tool, the files will be changed automatically. You should keep a backup of your files just to prevent lost data. (For example on GitHub)
Also note that all files in this directory will be adjusted to add UTF8 without BOM, no matter if anything other will be changed or not. So GitHub will show all files as changed (last modified date has changed).

## Possible Uses Cases
1. **I want to fix all files of my extension and choose the options**<br />
=> `FixFiles`
2. **I want to fix files for extension xy**<br />
=> `FixFiles --folder author\extensionname --force`
