
class ContactHandlers
{
    static public void ListContacts()
    {
        (bool b, List<Contact> contactList) = WriteToFile.ReadContacts();
        if (b)
        {
            LogContacts(contactList);
        }
        else
        {
            ShowErrorMsg("read");
        }
    }

    static public void FindContacts()
    {
        string searchTerm = Helpers.PromptStringQuestion("Enter search prhase: ");
        searchTerm = searchTerm.ToLower();
        (bool success, List<Contact> contactList) = WriteToFile.ReadContacts();

        if (success)
        {
            List<Contact> foundContact = contactList.Where(
                c => c.Name.Contains(searchTerm) ||
                     c.Address.Contains(searchTerm) ||
                     c.ZipCode.Contains(searchTerm) ||
                     c.Phone.ToString().Contains(searchTerm) ||
                     c.Email.Contains(searchTerm)
            ).ToList();

            if (foundContact.Count == 0)
            {
                Console.WriteLine("No search results.");
            }
            else
            {
                LogContacts(foundContact);
            }

        }
        else
        {
            ShowErrorMsg("read");
        }
    }

    static public void CreateContact()
    {
        (_, List<Contact> contactList) = WriteToFile.ReadContacts();

        long ID = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        string name = Helpers.PromptStringQuestion("Enter name: ");
        string address = Helpers.PromptStringQuestion("Enter address: ");
        string zipCode = Helpers.PromptStringQuestion("Enter zip code: ");
        int phone = Helpers.PromptIntQuestion("Enter phone: ");
        string email = Helpers.PromptStringQuestion("Enter email: ");

        ContactSummary(ID, name, address, zipCode, phone, email);
        bool isCorrect = Helpers.PromptYesNoQuestion("Is this correct [y/n]?");

        while (!isCorrect)
        {
            string correctField = Helpers.PromptStringQuestion($"which field do you wish to correct? ");

            switch (correctField.ToLower())
            {
                case "name": name = Helpers.PromptStringQuestion("Enter name: "); break;
                case "address": address = Helpers.PromptStringQuestion("Enter address: "); break;
                case "zip code": zipCode = Helpers.PromptStringQuestion("Enter zip code: "); break;
                case "phone": phone = Helpers.PromptIntQuestion("Enter phone: "); break;
                case "email": email = Helpers.PromptStringQuestion("Enter email: "); break;
                default: Console.WriteLine("Invalid option"); break;
            }
            ContactSummary(ID, name, address, zipCode, phone, email);
            isCorrect = Helpers.PromptYesNoQuestion("Is this correct [y/n]? ");
        }

        Contact newContact = new(ID, name.ToLower(), address.ToLower(), zipCode.ToUpper(), phone, email.ToLower());
        contactList.Add(newContact);
        LogContacts(contactList);
        WriteToFile.Write(contactList);

    }
    // UpdateContact
    // DeleteContact

    static void ContactSummary(long ID, string name, string address, string zipCode, int phone, string email)
    {
        Console.WriteLine($"\nThis is your new contact, ID: {ID}, Name: {name}, Address: {address}, Zip Code: {zipCode}, Phone: {phone}, Email: {email}");
    }

    private static void LogContacts(List<Contact> contactList)
    {
        foreach (var c in contactList)
        {
            Console.WriteLine($"ID: {c.ID}, Name: {c.Name}, Address: {c.Address}, Zip Code: {c.ZipCode}, Phone: {c.Phone}, Email: {c.Email}");
        }
    }
    private static void ShowErrorMsg(string v)
    {
        Console.WriteLine($"Couldn't {v} contacts");
    }

}