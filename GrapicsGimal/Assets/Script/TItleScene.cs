using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TItleScene : MonoBehaviour
{
    public AudioSource ButtonSound;

    public void StartGame() {
        SceneManager.LoadScene("MainGame");
    }
    public void How_to_Play() {
        ButtonSound.Play();
        GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);
    }

    public void ExitPanel()
    {
        ButtonSound.Play();
        GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(false);
    }

    public void Exit()
    {
        ButtonSound.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
