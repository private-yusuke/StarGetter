using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGUI : MonoBehaviour {
    public GameObject howToCanvas;
    public GameObject page1;
    public GameObject page2;

    int page = 0;

    public void OnClickStart() {
    	Debug.Log("start clicked");
        SceneManager.LoadScene("main");
    }
    public void OnClickHowTo() {
        switch(page) {
            case 0:
                howToCanvas.SetActive(true);
                page1.SetActive(true);
                break;
            case 1:
                page1.SetActive(false);
                page2.SetActive(true);
                break;
            case 2:
                page2.SetActive(false);
                howToCanvas.SetActive(false);
                break;
            default:
                break;

        }
        page = (page + 1) % 3;
    }
    public void OnClickQuit() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
