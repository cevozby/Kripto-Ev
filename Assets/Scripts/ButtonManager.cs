using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("AudioVolume"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Salon");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        Debug.Log("Volume: " + volume);
        PlayerPrefs.SetFloat("AudioVolume", volume);
        audioMixer.SetFloat("volume", volume);
    }

}
