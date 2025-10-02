static class WriteToFile
{
    static private string fileName = @"E:\dotnet\contactlist\contactlist.txt";

    /// <summary>
    /// Writes text to the file.
    /// </summary>
    /// <param name="txt">The text to write into the file.</param>
    /// <param name="b">If true, appends to the file; if false, overwrites the file.</param>
    /// <returns>True if writing succeeds, false otherwise.</returns>
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
                // foreach (var item in list)
                // {
                //     Console.WriteLine(item.Name);
                // }
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

    // static public bool Update(string name)
    // {
    //     try
    //     {
    //         (bool success, List<Contact> contactsList) = ReadContacts();

    //         return true;
    //     }
    //     catch (Exception exp)
    //     {
    //         Console.Write(exp.Message);
    //         return false;
    //     }
    // }

}