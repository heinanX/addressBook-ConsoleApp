class Contact
{
    public string Name;
    public string Address;
    public string ZipCode;
    public int Phone;
    public string Email;
    public int ID;

    public Contact(int _num, string _name, string _address, string _zipCode,
    int _phone, string _email)
    {
        ID = _num;
        Name = _name;
        Address = _address;
        ZipCode = _zipCode;
        Phone = _phone;
        Email = _email;
    }

}