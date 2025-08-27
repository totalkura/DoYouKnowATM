
[System.Serializable]
public class UserData 
{
    public string userID;
    public string userName;
    public string userPassword;
    public int userGold;
    public int userBankGold;

    public UserData(string userid, string username, string userpassword, int usergold, int userbankGold)
    {
        userID = userid;
        userName = username;
        userPassword = userpassword;
        userGold = usergold;
        userBankGold = userbankGold;
    }

}
