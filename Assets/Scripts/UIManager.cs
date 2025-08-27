using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI bankGold;

    public void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        userName.text = GameManager.Instance.userData.userName;
        gold.text = GameManager.Instance.userData.userGold.ToString();
        bankGold.text = GameManager.Instance.userData.userBankGold.ToString();
    }
}
