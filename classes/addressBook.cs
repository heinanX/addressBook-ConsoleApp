class AddressBook
{
    string[] options = ["List", "Create", "Update", "Delete", "Find", "Close"];
    List<Contact> contactList = [];

    public AddressBook(string filePath)
    {
        WriteToFile.SetFilePath(filePath);
    }

    public void RunAddressBookApp()
    {
        bool openAddressBook = true;
        OpenCloseApp(true);
        while (openAddressBook)
        {
            int choice = MainMenu();
            openAddressBook = MeddlingKid(choice);
        }
        OpenCloseApp(false);
    }

    public int MainMenu()
    {

        Console.WriteLine($"\n-- Choose an action by entering a number [1-{options.Length}]:");
        for (int i = 0; i < options.Length; i++)
        {
            string msg = options[i] != "Close" ? "contact" : "app";
            Console.WriteLine($"{i + 1}. {options[i]} {msg}");
        }
        int index = Helpers.PromptIntQuestion("");
        while (index > options.Length)
        {
            index = Helpers.PromptIntQuestion($"Not a valid number. Enter a number between [1-{options.Length}]:");
        }

        index--;

        return index;
    }

    bool MeddlingKid(int num)
    {
        (bool getContacts, contactList) = WriteToFile.ReadContacts();
        if (!getContacts) return false;

        if (options[num] != "Close") Console.WriteLine($" \n----- {options[num]} contact:");
        if (num >= 0 && num < options.Length && num != 5)
        {
            switch (num)
            {
                case 0: ContactHandlers.ListContacts(contactList); break;
                case 1: ContactHandlers.CreateContact(contactList); break;
                case 2: ContactHandlers.UpdateContact(contactList); break;
                case 3: ContactHandlers.DeleteContact(contactList); break;
                case 4: ContactHandlers.FindContacts(contactList); break;
            }
            return Helpers.PromptYesNoQuestion("\nReturn to main menu [y/n]? ");
        }
        else
        {
            return false;
        }
    }

    void OpenCloseApp(bool open)
    {
        string msg = open ? "Opening" : " Closing";
        Console.Write("\n.");
        Thread.Sleep(200);
        Console.Write(".");
        Thread.Sleep(200);
        Console.Write(".");
        Thread.Sleep(200);
        Console.ForegroundColor = open ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.Write($"{msg} application\n");
        Console.ResetColor();
        if (open) Thread.Sleep(200);
    }
}