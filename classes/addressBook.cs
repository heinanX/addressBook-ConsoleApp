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
        if (num > 0)
        {
            //ContactHandler.ListContacts();
            //ContactHandlers.FindContacts();
            //ContactHandlers.CreateContact();
            ContactHandlers.UpdateContact();
        }
        ReturnToMainMenu();
    }

    public bool ReturnToMainMenu()
    {
        bool active = Helpers.PromptYesNoQuestion("Return to main menu?");
        if (!active)
        {
            Thread.Sleep(150);
            Console.WriteLine("Closing application");
        }

        return active;
    }
}