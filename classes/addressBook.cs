class AddressBook
{
    string[] options = ["List", "Create", "Update", "Delete", "Find", "Close"];

    public void InitInstructions()
    {
        Console.WriteLine("\nChoose an action by entering a number.");
        for (int i = 0; i < options.Length; i++)
        {
            string msg = options[i] != "Close" ? "contact" : "app";
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
                case 5: CloseMainMenu(); break;
            }
        }
        else
        {
            CloseMainMenu();
        }
        ReturnToMainMenu();
    }

    public bool ReturnToMainMenu()
    {
        bool active = Helpers.PromptYesNoQuestion("\nReturn to main menu [y/n]? ");
        if (!active)
        {
            CloseMainMenu();
        }

        return active;
    }

    static void CloseMainMenu()
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