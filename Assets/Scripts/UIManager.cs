using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("메인화면 UI")]
    public GameObject mainUI;
    public GameObject depositUI;
    public GameObject withDrawUI;
    public GameObject sendUI;
    public GameObject goldUI;

    [Header("로그인 UI")]
    public GameObject signUpUI;
    public GameObject loginUI;
    public GameObject popupUI;

    [Header("메인화면 TEXT")]
    public TextMeshProUGUI userName;
    public TextMeshProUGUI gold;
    public TextMeshProUGUI bankGold;

    [Header("로그인 TEXT")]
    public TextMeshProUGUI signupWarringText;

    [Header("팝업 TEXT")]
    public TextMeshProUGUI popupText;

    [Header("송금 & 입금 & 출금 입력필드")]
    public TMP_InputField depositInputField;
    public TMP_InputField withInputField;
    public TMP_InputField sendNameInputField;
    public TMP_InputField sendMoneyInputField;

    [Header("로그인 입력필드")]
    public TMP_InputField loginIDField;
    public TMP_InputField loginPWField;

    [Header("SignUP 입력필드")]
    public TMP_InputField signupIDField;
    public TMP_InputField signupNameField;
    public TMP_InputField signupPWField;
    public TMP_InputField signupPWConfirmField;

    public void Start()
    {
        
        Refresh();
        GotoMain();
        GotoLogin();
        OKPopUpUI();
        SignUPUI();
        loginUI.SetActive(true);
    }

    public void CleanUp()
    {
        depositInputField.text = string.Empty;
        withInputField.text = string.Empty;
        sendNameInputField.text = string.Empty;
        sendMoneyInputField.text = string.Empty;
        loginIDField.text = string.Empty;
        loginPWField.text = string.Empty;
        signupIDField.text= string.Empty;
        signupNameField.text= string.Empty;
        signupPWField.text= string.Empty;
        signupPWConfirmField.text= string.Empty;    
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

    public void SignUPUI()
    {
        signUpUI.SetActive(!signUpUI.activeSelf);
    }

    public void OKPopUpUI()
    {
        popupUI.SetActive(false);
    }

    private void PopUpOnText(string text)
    {
        popupText.text = text;
        popupUI.SetActive(true);
    }

    public void GotoLogin()
    {
        goldUI.SetActive(!goldUI.activeSelf);
        mainUI.SetActive(!mainUI.activeSelf);
        loginUI.SetActive(false);
        Refresh();
    }

    public void LoginMainUI()
    {
        if (loginIDField.text.Length == 0)
        {
            PopUpOnText("ID를 입력해주세요");
            return;
        }
        else if (loginPWField.text.Length == 0)
        {
            PopUpOnText("비밀번호를 입력해 주세요");
            return;
        }
        else if (GameManager.Instance.LoadData(loginIDField.text) == null)
        {
            PopUpOnText("등록되지 않은 ID 입니다");
            return;
        }

        UserData userdata = GameManager.Instance.LoadData(loginIDField.text);

        if (loginPWField.text != userdata.userPassword)
        {
            PopUpOnText("비밀번호가 맞지 않습니다");
            return;
        }

        GameManager.Instance.userData = GameManager.Instance.LoadData(loginIDField.text);

        GotoLogin();
    }


    public void SignUp()
    {
        if (signupIDField.text.Length == 0)
        {
            signupWarringText.text = "ID를 입력해 주세요";
            PopUpOnText("잘못된 정보입니다");
            return;
        }
        else if (signupNameField.text.Length == 0)
        {
            signupWarringText.text = "이름을 입력해 주세요";
            PopUpOnText("잘못된 정보입니다");
            return;
        }
        else if(signupPWField.text.Length == 0)
        {
            signupWarringText.text = "비밀번호를 입력해 주세요";
            PopUpOnText("잘못된 정보입니다");
            return;
        }
        else if (signupPWConfirmField.text.Length == 0 || signupPWConfirmField.text != signupPWField.text)
        {
            signupWarringText.text = "동일한 비밀번호를 입력해 주세요";
            PopUpOnText("잘못된 정보입니다");
            return;
        }

        PopUpOnText("회원 가입이 완료되었습니다!");
        GameManager.Instance.NewUserSetting(signupIDField.text, signupNameField.text, signupPWField.text);
        SignUPUI();

    }

    public void DepositMoney(int money)
    {
        if (GameManager.Instance.userData.userGold >= money)
        {
            GameManager.Instance.userData.userGold -= money;
            GameManager.Instance.userData.userBankGold += money;
            GameManager.Instance.SaveData(GameManager.Instance.userData);
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
            GameManager.Instance.SaveData(GameManager.Instance.userData);
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
