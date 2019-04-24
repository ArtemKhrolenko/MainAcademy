namespace Hello_Class_stud
{
    //Define interface IMorse_crypt with two methods  
    //crypt - to crypt the string
    //decrypt - to decrypt array of strings
    public interface Imorse_crypt
    {
        string crypt(string stringItem);

        string decrypt(string[] stringArray);
    }

}
