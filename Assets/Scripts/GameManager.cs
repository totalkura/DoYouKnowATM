using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;



    [SerializeField]
    public UserData userData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            userData = new UserData("Áøµ¾°³", "Dog", "asd", 1000, 10);
        }
    }


}
