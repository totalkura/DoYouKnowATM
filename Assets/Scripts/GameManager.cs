using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string filePath;

    [SerializeField]
    public UserData userData;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            filePath = "C:\\Users\\USER\\Downloads\\unity\\Solo_four\\DoYouKnowATM\\Assets\\SaveData\\";
            //userData = new UserData("진돗개", "Dog", "asd", 50000, 100000);
        }
    }

    public void SaveData(UserData userdata)
    {
        string saveJson = JsonUtility.ToJson(userdata);
        string saveFilePath = filePath + userdata.userID + ".json";

        File.WriteAllText(saveFilePath, saveJson);
    }

    public UserData LoadData(string userid)
    {
        string saveFilePath = filePath + userid + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.Log("로드 할 파일이 없음");
            return null;
        }

        string loadFile = File.ReadAllText(saveFilePath);
        UserData userdata = JsonUtility.FromJson<UserData>(loadFile);
        return userdata;
    }

    public void NewUserSetting(string id, string name, string pw)
    {
        userData = new UserData(id, name, pw, 50000, 100000);
        SaveData(userData);
    }

}
