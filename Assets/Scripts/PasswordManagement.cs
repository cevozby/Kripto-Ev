using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PasswordManagement : MonoBehaviour
{
    public List<GameObject> digits;
    public List<TextMeshProUGUI> digitsText;

    public GameObject warningMessage;
    public TextMeshProUGUI warningText;
    static bool levelCheck = false;


    int i = 0;

    int[] passwordTry = new int[4], passwordSecond = new int[4]; 
    int[,]    password = { { 2, 4, 7, 1 }, { 1, 5, 4, 2 }, { 1, 3, 2, 9 } };

    //int password = 1542;

    // Start is called before the first frame update
    void Start()
    {
        
        
        for(int x = 0; x<4; x++)
        {
            passwordSecond[x] = password[PlayerManagement.level, x];
            Debug.Log("Password: " + passwordSecond[x]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelCheck && PlayerManagement.level<2 )
        {
            PlayerManagement.level++;
            SceneManager.LoadScene("Salon");
            warningMessage.SetActive(true);
            warningText.text = "Level " + PlayerManagement.level + 1.ToString();
            levelCheck = false;
        }
        if (PlayerManagement.level == 2 && levelCheck)
        {
            warningMessage.SetActive(true);
            warningText.text = "BUTUN LEVELLERI TAMAMLADINIZ";
            levelCheck = false;
            PlayerManagement.level++;
        }
    }

    public void Button1()
    {
        if(i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "1";
            passwordTry[i] = 1;
            i++;
        }
    }

    public void Button2()
    {
        if (i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "2";
            passwordTry[i] = 2;
            i++;
        }
    }

    public void Button3()
    {
        if (i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "3";
            passwordTry[i] = 3;
            i++;
        }
    }

    public void Button4()
    {
        if (i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "4";
            passwordTry[i] = 4;
            i++;
        }
    }

    public void Button5()
    {
        if (i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "5";
            passwordTry[i] = 5;
            i++;
        }
    }

    public void Button6()
    {
        if (i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "6";
            passwordTry[i] = 6;
            i++;
        }
    }

    public void Button7()
    {
        if (i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "7";
            passwordTry[i] = 7;
            i++;
        }
    }

    public void Button8()
    {
        if (i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "8";
            passwordTry[i] = 8;
            i++;
        }
    }

    public void Button9()
    {
        if (i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "9";
            passwordTry[i] = 9;
            i++;
        }
    }

    public void Button0()
    {
        if (i >= 0 && i <= 3)
        {
            digits[i].SetActive(true);
            digitsText[i].text = "0";
            passwordTry[i] = 0;
            i++;
        }
    }

    public void ButtonBack()
    {
        if (i >= 0 && i <= 4)
        {
            i--;
            digits[i].SetActive(false);
            
        }
    }

    public void ButtonEnter()
    {
        for (int j = 0; j <= 3; j++)
        {
            if (passwordTry[j] == passwordSecond[j])
            {
                warningMessage.SetActive(true);
                warningText.text = "PAROLA DOGRU";
                StartCoroutine(TextMissing());
                
                
                levelCheck = true;
            }
            else
            {
                warningMessage.SetActive(true);
                warningText.text = "PAROLA YANLIS";
                StartCoroutine(TextMissing());
            }
        }
    }

    IEnumerator TextMissing()
    {
        yield return new WaitForSeconds(1.5f);
        warningMessage.SetActive(false);
    }
}
