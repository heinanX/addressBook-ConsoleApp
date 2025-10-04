# addressBook-ConsoleApp

A simple C# console application that lets users manage a list of contacts.
The app supports the full range of CRUD operations — Create, Read, Update, Delete, as well as Find/Search — all handled through an interactive console interface.

Contacts are stored in a text file and loaded dynamically for each operation. The application reads from and writes to this file using the FileHandler class.

Before running the program, update the file path inside FileHandler.cs:

**static private string fileName = @"[C:\SET FILE PATH HERE]";**

This ensures the app can properly access and save contact data.

Build artifacts (bin/ and obj/ folders) are excluded from version control via .gitignore.
