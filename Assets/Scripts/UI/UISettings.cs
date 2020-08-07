using Complete;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    public GameManager m_GameManager;
    public GameObject tank;
    public GameObject shell;
    public GameObject mainCamera;
    public AudioMixer masterMixer;    

    private Dropdown dropdown;
    private TankShooting tankShooting;
    private TankHealth tankHealth;
    private ShellExplosion tankDamage;
    private Slider slider;
    private float sfxLevel;
    private float bgsLevel;


    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        tankShooting = tank.GetComponent<TankShooting>();
        tankHealth = tank.GetComponent<TankHealth>();
        tankDamage = shell.GetComponent<ShellExplosion>();
        slider = gameObject.GetComponent<Slider>();

        if (gameObject.name == "SFXSlider")
        {
            masterMixer.GetFloat("SFXVol", out sfxLevel);
            slider.value = sfxLevel;
        }

        if (gameObject.name == "BGSSlider")
        {
            masterMixer.GetFloat("MusicVol", out bgsLevel);
            slider.value = bgsLevel;
        }        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "RoundsDropdown")
        {
            RoundsNumber();           
        }

        if (gameObject.name == "MaxLaunchDropdown")
        {
            TankShooting();
        }

        if (gameObject.name == "MaxHealthDropdown")
        {
            TankHealth();
        }

        if (gameObject.name == "MaxDamageDropdown")
        {
            TankDamage();
        }

        if (gameObject.name == "SFXSlider")
        {
            SFXVol();
        }

        if (gameObject.name == "BGSSlider")
        {
            BGSVol();
        }
    }

    void RoundsNumber()
    {
        if (dropdown.value == 0)
        {
            m_GameManager.m_NumRoundsToWin = 3;
        }

        if (dropdown.value == 1)
        {
            m_GameManager.m_NumRoundsToWin = 5;
        }

        if (dropdown.value == 2)
        {
            m_GameManager.m_NumRoundsToWin = 7;
        }

        if (dropdown.value == 3)
        {
            m_GameManager.m_NumRoundsToWin = 10;
        }
    }

    void TankShooting()
    {
        if (dropdown.value == 0)
        {
            tankShooting.m_MaxLaunchForce = 30;
        }

        if (dropdown.value == 1)
        {
            tankShooting.m_MaxLaunchForce = 15;
        }

        if (dropdown.value == 2)
        {
            tankShooting.m_MaxLaunchForce = 60;
        }
    }

    void TankHealth()
    {
        if (dropdown.value == 0)
        {
            tankHealth.m_StartingHealth = 100;
        }

        if (dropdown.value == 1)
        {
            tankHealth.m_StartingHealth = 50;
        }

        if (dropdown.value == 2)
        {
            tankHealth.m_StartingHealth = 200;
        }
    }

    void TankDamage()
    {
        if (dropdown.value == 0)
        {
            tankDamage.m_MaxDamage = 100;
        }

        if (dropdown.value == 1)
        {
            tankDamage.m_MaxDamage = 10;
        }

        if (dropdown.value == 2)
        {
            tankDamage.m_MaxDamage = 200;
        }
    }

    void SFXVol()
    {
        sfxLevel = slider.value;
        masterMixer.SetFloat("SFXVol", sfxLevel);
        masterMixer.SetFloat("DrivingVol", sfxLevel);
    }

    void BGSVol()
    {
        bgsLevel = slider.value;
        masterMixer.SetFloat("MusicVol", bgsLevel);
    }
}
