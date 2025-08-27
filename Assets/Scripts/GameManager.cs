using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string filePath;

    [SerializeField]
    public UserData userData;

    public JsonSave jsonsave;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            filePath = "C:\\Users\\USER\\Downloads\\unity\\Solo_four\\DoYouKnowATM\\Assets\\SaveData\\";
            userData = new UserData("Áøµ¾°³", "Dog", "asd", 50000, 100000);
        }
    }


}
