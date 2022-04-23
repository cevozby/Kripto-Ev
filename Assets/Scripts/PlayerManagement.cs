using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManagement : MonoBehaviour
{
    public GameObject passwordPanel;
    public GameObject fButton;
    public GameObject passwordText;
    public GameObject warningMessage;
    public TextMeshProUGUI warningText;
    public List<GameObject> levelTexts;
    bool paperCheck;

    static bool salonCheck;
    public static bool levelCheck = true;
    public static int level = 0;
    static int levelControl = -1;
    public static Vector2 characterPos;

    static Vector2 playerPos;

    public static PlayerManagement player;

    private void Awake()
    {
        player = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Level: " + level);
        if (salonCheck)
        {
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"));
            Debug.Log("Player Get Pos X: " + PlayerPrefs.GetFloat("PlayerPosX") + "\nPlayer Get Pos Y: " + PlayerPrefs.GetFloat("PlayerPosY"));
            Debug.Log("Transform X: " + transform.position.x + "\nTransform Y: " + transform.position.y);
            salonCheck = false;
        }

        for(int i = 0; i<3; i++)
        {
            levelTexts[i].SetActive(false);
        }

        if(levelControl != level)
        {
            warningMessage.SetActive(true);
            warningText.text = "Level " + (level + 1).ToString();
            StartCoroutine(TextMissing());
            levelControl++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //OpenPaper();
    }

    //void OpenPaper()
    //{
    //    if (paperCheck && Input.GetKeyDown(KeyCode.F))
    //    {
    //        passwordText.SetActive(true);
    //    }
    //    else if(!paperCheck)
    //    {
    //        passwordText.SetActive(false);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Salon"))
        {
            
            SceneManager.LoadScene("Salon");
            salonCheck = true;
        }
        if (collision.gameObject.CompareTag("Banyo"))
        {
            SceneManager.LoadScene("Banyo");
            playerPos = new Vector2(transform.position.x - 0.25f, transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);
        }
        if (collision.gameObject.CompareTag("Mutfak"))
        {
            SceneManager.LoadScene("Mutfak");
            playerPos = new Vector2(transform.position.x + 0.25f, transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);
        }
        if (collision.gameObject.CompareTag("YatakOdasi"))
        {
            playerPos = new Vector2(transform.position.x, transform.position.y - 0.25f);
            Debug.Log("Player Pos X: " + playerPos.x + "\nPlayer Pos Y: " + playerPos.y);
            PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);

            Debug.Log("PlayerPref Pos X: " + PlayerPrefs.GetFloat("PlayerPosX") + "\nPlayerPref Pos Y: " + PlayerPrefs.GetFloat("PlayerPosY"));
            SceneManager.LoadScene("YatakOdasi");
            
        }
        if (collision.gameObject.CompareTag("Balkon"))
        {
            SceneManager.LoadScene("Balkon");
            playerPos = new Vector2(transform.position.x, transform.position.y + 0.25f);
            PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);
        }
        if (collision.gameObject.CompareTag("Password"))
        {
            passwordPanel.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Paper"))
        {
            passwordText.SetActive(true);
            levelTexts[level].SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Password"))
        {
            passwordPanel.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Paper"))
        {
            passwordText.SetActive(false);
            levelTexts[level].SetActive(false);
        }
    }

    IEnumerator TextMissing()
    {
        yield return new WaitForSeconds(1.5f);
        warningMessage.SetActive(false);
    }

}
