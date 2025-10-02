static class WriteToFile
{
    static private string fileName = @"E:\dotnet\contactlist\contactlist.txt";

    static public (bool success, List<Contact> contacts) ReadContacts()
    {
        List<Contact> list = new();
        try
        {
            using (StreamReader reader = new(fileName))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    ConvertToListItem(list, line);
                }
                return (true, list);
            }
        }
        catch (Exception exp)
        {
            Console.Write(exp.Message);
            return (false, list);
        }
    }

    static List<Contact> ConvertToListItem(List<Contact> list, string listItem)
    {
        var parts = listItem.Split(',');
        Contact person = new(
            int.Parse(parts[0].Trim()), parts[1], parts[2], parts[3], int.Parse(parts[4].Trim()), parts[5]
        );
        list.Add(person);
        return list;
    }


    static public bool Write(List<Contact> list)
    {
        try
        {
            using (StreamWriter writer = new(fileName))
            {
                foreach (var item in list)
                {
                    writer.WriteLine($"{item.ID}, {item.Name}, {item.Address}, {item.ZipCode}, {item.Phone}, {item.Email}");
                }
                return true;
            }
        }
        catch (Exception exp)
        {
            Console.Write(exp.Message);
            return false;
        }
    }
}