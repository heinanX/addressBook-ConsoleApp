class AddressBook
{
    public void InitInstructions()
    {
        string[] options = ["List", "Create", "Update", "Delete", "Find", "Close"];

        Console.WriteLine("\nChoose an action by entering a number.");
        for (int i = 0; i < options.Length; i++)
        {
            string msg = options[i] != "Close" ? "contact" : "app";
            Console.WriteLine($"{i + 1}. {options[i]} {msg}");
        }

        string response = Console.ReadLine() ?? "";
        MeddlingKid(response);
    }

    void MeddlingKid(string a)
    {
        if (int.Parse(a) > 0)
        {
            //ContactHandler.ListContacts();
            ContactHandlers.FindContacts("55");
        }
    }
}