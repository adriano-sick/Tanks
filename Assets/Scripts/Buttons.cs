using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{    
    public GameObject mainCanvas;
    public GameObject instructionCanvas;
    public GameObject configurationCanvas;
    public string button;

    // Start is called before the first frame update
    private void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        if (button == "PlayButton")
        {
            PlayButton();
        }

        else if (this.button == "ExitButton")
        {
            QuitButton();
        }

        else if (button == "InstructionButton")
        {
            InstructionButton();
        }

        else if (this.button == "ConfigButton")
        {
            ConfigButton();
        }

        else if (this.button == "BackButton")
        {
            BackButton();
        }
    }

   
    void PlayButton()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    void QuitButton()
    {
        Application.Quit();
    }

    void InstructionButton()
    {        
        mainCanvas.SetActive(false);
        configurationCanvas.SetActive(false);
        instructionCanvas.SetActive(true);
    }

    void ConfigButton()
    {
        mainCanvas.SetActive(false);
        instructionCanvas.SetActive(false);        
        configurationCanvas.SetActive(true);
    }

    void BackButton()
    {
        instructionCanvas.SetActive(false);
        configurationCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
