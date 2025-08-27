using System.IO;
using UnityEngine;

public class JsonSave : MonoBehaviour
{

    public void SaveData(UserData userdata)
    {
        string saveJson = JsonUtility.ToJson(userdata);
        string saveFilePath = GameManager.Instance.filePath + userdata.userID + ".json";

        File.WriteAllText(saveFilePath, saveJson);
    }

    public UserData LoadData(string userid)
    {
        string saveFilePath = GameManager.Instance.filePath + userid + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.Log("로드 할 파일이 없음");
            return null;
        }

        string loadFile = File.ReadAllText(saveFilePath);
        UserData userdata = JsonUtility.FromJson<UserData>(loadFile);
        return userdata;
    }

    public UserData NewUser(string id,string name,string pw)
    {
        UserData userData = new UserData(id, name, pw, 50000, 100000);

        return userData;
    }
}
