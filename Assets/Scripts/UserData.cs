
public class UserData 
{
    public string userName { get; private set; }
    public string userID { get; private set; }
    public string userPassword { get; private set; }
    public int userGold { get; private set; }
    public int userBankGold { get; private set; }

    public UserData(string username, string userid, string userpassword, int usergold, int userbankGold)
    {
        userName = username;
        userID = userid;
        userPassword = userpassword;
        userGold = usergold;
        userBankGold = userbankGold;
    }
}
