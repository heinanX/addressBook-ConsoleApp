class AddressBook
{
    string[] options = ["List", "Create", "Update", "Delete", "Find", "Close"];

    public void InitAddressBookApp()
    {
        bool closeAddressBook = false;
        Console.WriteLine("Opening Address Book");
        while (!closeAddressBook)
        {
            MainMenu();
            closeAddressBook = Helpers.PromptYesNoQuestion("\nReturn to main menu [y/n]? ");
        }
        CloseApp();
    }
    public void MainMenu()
    {
        Console.WriteLine($"\n-- Choose an action by entering a number [1-{options.Length}] :");
        for (int i = 0; i < options.Length; i++)
        {
            string msg = options[i] != "close" ? "contact" : "app";
            Console.WriteLine($"{i + 1}. {options[i]} {msg}");
        }

        Console.WriteLine("");
        bool success = int.TryParse(Console.ReadLine(), out int num);
        if (success)
        {
            num = num - 1;
            MeddlingKid(num, options[num]);
        }
    }

    void MeddlingKid(int num, string action)
    {
        Console.WriteLine($" \n----- {action} contact:");
        if (num >= 0 && num < options.Length)
        {
            switch (num)
            {
                case 0: ContactHandlers.ListContacts(); break;
                case 1: ContactHandlers.CreateContact(); break;
                case 2: ContactHandlers.UpdateContact(); break;
                case 3: ContactHandlers.DeleteContact(); break;
                case 4: ContactHandlers.FindContacts(); break;
                case 5: CloseApp(); break;
            }
        }
        else
        {
            CloseApp();
        }
    }

    static void CloseApp()
    {
        Thread.Sleep(200);
        Console.WriteLine(".");
        Thread.Sleep(200);
        Console.WriteLine("..");
        Thread.Sleep(200);
        Console.WriteLine("...");
        Thread.Sleep(200);
        Console.WriteLine("Closing application");
    }
}