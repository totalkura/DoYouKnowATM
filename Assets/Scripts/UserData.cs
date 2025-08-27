
[System.Serializable]
public class UserData 
{
    public string userName;
    public string userID;
    public string userPassword;
    public int userGold;
    public int userBankGold;

    public UserData(string username, string userid, string userpassword, int usergold, int userbankGold)
    {
        userName = username;
        userID = userid;
        userPassword = userpassword;
        userGold = usergold;
        userBankGold = userbankGold;
    }

}
