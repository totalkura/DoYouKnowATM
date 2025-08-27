using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject depositUI;
    public GameObject withDrawUI;
    public GameObject sendUI;

    public TextMeshProUGUI userName;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI bankGold;

    public void Start()
    {
        Refresh();
        GotoMain();
    }

    public void Refresh()
    {
        userName.text = GameManager.Instance.userData.userName;
        gold.text = GameManager.Instance.userData.userGold.ToString();
        bankGold.text = GameManager.Instance.userData.userBankGold.ToString();
    }

    public void GotoMain()
    {
        mainUI.SetActive(true);
        depositUI.SetActive(false);
        withDrawUI.SetActive(false);
        sendUI.SetActive(false);
    }

    public void GotoDepositUI()
    {
        mainUI.SetActive(false);
        depositUI.SetActive(true);
        withDrawUI.SetActive(false);
        sendUI.SetActive(false);
    }
    public void GotoWithDrawUI()
    {
        mainUI.SetActive(false);
        depositUI.SetActive(false);
        withDrawUI.SetActive(true);
        sendUI.SetActive(false);
    }

    public void GotoSendUI()
    {
        mainUI.SetActive(false);
        depositUI.SetActive(false);
        withDrawUI.SetActive(false);
        sendUI.SetActive(true);
    }
}
