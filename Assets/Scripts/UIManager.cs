using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject depositUI;
    public GameObject withDrawUI;
    public GameObject sendUI;
    public GameObject goldUI;

    public GameObject popupUI;

    public TextMeshProUGUI userName;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI bankGold;
    public TextMeshProUGUI popupText;

    public TMP_InputField depositInputField;
    public TMP_InputField withInputField;
    public TMP_InputField sendNameInputField;
    public TMP_InputField sendMoneyInputField;

    public void Start()
    {
        Refresh();
        GotoMain();
        OKPopUpUI();
    }

    public void CleanUp()
    {
        depositInputField.text = string.Empty;
        withInputField.text = string.Empty;
        sendNameInputField.text = string.Empty;
        sendMoneyInputField.text = string.Empty;
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
        CleanUp();
    }

    public void GotoDepositUI()
    {
        mainUI.SetActive(false);
        depositUI.SetActive(true);
        withDrawUI.SetActive(false);
        sendUI.SetActive(false);
        CleanUp();
    }
    public void GotoWithDrawUI()
    {
        mainUI.SetActive(false);
        depositUI.SetActive(false);
        withDrawUI.SetActive(true);
        sendUI.SetActive(false);
        CleanUp();
    }

    public void GotoSendUI()
    {
        mainUI.SetActive(false);
        depositUI.SetActive(false);
        withDrawUI.SetActive(false);
        sendUI.SetActive(true);
        CleanUp();
    }

    public void OKPopUpUI()
    {
        popupUI.SetActive(false);
    }

    public void DepositMoney(int money)
    {
        if (GameManager.Instance.userData.userGold >= money)
        {
            GameManager.Instance.userData.userGold -= money;
            GameManager.Instance.userData.userBankGold += money;
        }
        else
        {
            popupText.text = "잔액이 부족합니다";
            popupUI.SetActive(true);
        }
        Refresh();
    }

    public void WithMoney(int money)
    {
        if (GameManager.Instance.userData.userBankGold >= money)
        {
            GameManager.Instance.userData.userBankGold -= money;
            GameManager.Instance.userData.userGold += money;
        }
        else
        {
            popupText.text = "잔액이 부족합니다";
            popupUI.SetActive(true);
        }
        Refresh();
    }

    public void DepositMoneyWrite()
    {
        int money = int.Parse(depositInputField.text);

        DepositMoney(money);
    }

    public void WithMoneyWrite()
    {
        int money = int.Parse(withInputField.text);

        WithMoney(money);
    }
}
