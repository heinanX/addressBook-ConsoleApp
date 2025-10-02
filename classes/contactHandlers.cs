
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

    static public void FindContacts(string criteria)
    {
        (bool b, List<Contact> contactList) = WriteToFile.ReadContacts();
        if (b)
        {

            List<Contact> foundContact = contactList.Where(
                c => c.Name.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                     c.Address.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                     c.ZipCode.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                     c.Phone.ToString().Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                     c.Email.Contains(criteria, StringComparison.OrdinalIgnoreCase)
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
            ShowErrorMsg("find");
        }
    }
    // FindContact
    // CreateContact
    // UpdateContact
    // DeleteContact

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