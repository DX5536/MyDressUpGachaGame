using UnityEngine;


public class SoundManager: MonoBehaviour
{
    //Make Sound Manager a singleton
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Tooltip("Insert soundScriptableObject to get AudioClip")]
    [SerializeField]
    private SoundScriptableObject soundScriptableObject;

    [Header("Children AudioSource of SoundManager")]
    [SerializeField]
    private AudioSource BGM_AudioSource;

    [SerializeField]
    private AudioSource confirmedClickSFX_AudioSource;

    [SerializeField]
    private AudioSource backClickSFX_AudioSource;

    [SerializeField]
    private AudioSource gachaClick_AudioSource;

    [SerializeField]
    private AudioSource equipItem_AudioSource;

    private void Start()
    {
        BGM_AudioSource.clip = soundScriptableObject.BackgroundMusic;

        confirmedClickSFX_AudioSource.clip = soundScriptableObject.ConfirmedClick_SFX;
        backClickSFX_AudioSource.clip = soundScriptableObject.BackClick_SFX;
        gachaClick_AudioSource.clip = soundScriptableObject.GachaClick_SFX;
        equipItem_AudioSource.clip = soundScriptableObject.EquipItem_SFX;

        //Reset all volume back to 1 if no playerPref
        //Load the Music saved values from PlayerPref
        //CheckPlayerPref_NewGame();
        //At start play BGM
        PlayBGM();
    }

    //All public methods to access from other scripts
    public void PlayBGM()
    {
        BGM_AudioSource.Play();
    }

    public void StopBGM()
    {
        BGM_AudioSource.Stop();
    }

    public void PlayConfirmedClickSFX()
    {
        if (confirmedClickSFX_AudioSource.isPlaying)
        {
            return;
        }
        else
        {
            confirmedClickSFX_AudioSource.PlayOneShot(confirmedClickSFX_AudioSource.clip, 1);
        }

    }

    //Walking
    public void PlayBackClickSFX()
    {
        if (backClickSFX_AudioSource.isPlaying)
        {
            return;
        }
        else
        {
            backClickSFX_AudioSource.Play();
        }
    }


    public void PlayGachaClick()
    {
        if (gachaClick_AudioSource.isPlaying)
        {
            gachaClick_AudioSource.Stop();
            gachaClick_AudioSource.Play();
            return;
        }
        else
        {
            gachaClick_AudioSource.Play();
        }
    }

    public void PlayEquipItem()
    {
        if (equipItem_AudioSource.isPlaying)
        {
            return;
        }
        else
        {
            equipItem_AudioSource.Play();
        }
    }


    /*private void CheckPlayerPref_NewGame()
    {
        //If doesn't have  ANY of the key => Volume = 1
        if (!PlayerPrefs.HasKey("masterVolume") ||
            !PlayerPrefs.HasKey("BGMVolume") ||
            !PlayerPrefs.HasKey("SFXVolume") ||
            !PlayerPrefs.HasKey("confirmedClickSFXVolume"))
        {
            AudioListener.volume = 1;
            BGM_AudioSource.volume = 1;
            backClickSFX_AudioSource.volume = 1;
            item_AudioSource.volume = 1;
            confirmedClickSFX_AudioSource.volume = 1;

            Debug.Log("No PlayerPref -> Reset all volume to 1");
        }

        else
        {
            LoadVolumeValue();
        }

    }*/

    //For option scene -> Changing the volumes
    //Master volume is all the sounds
    public void ChangeMasterVolume(float volumeValue)
    {
        PlayerPrefs.SetFloat("masterVolume", volumeValue);
        AudioListener.volume = volumeValue;
    }

    public void ChangeBGMVolume(float volumeValue)
    {
        PlayerPrefs.SetFloat("BGMVolume", volumeValue);
        BGM_AudioSource.volume = volumeValue;
    }

    public void ChangeSFXVolume(float volumeValue)
    {
        PlayerPrefs.SetFloat("SFXVolume", volumeValue);
        backClickSFX_AudioSource.volume = volumeValue;
        confirmedClickSFX_AudioSource.volume = volumeValue;
        backClickSFX_AudioSource.volume = volumeValue;
        gachaClick_AudioSource.volume = volumeValue;
        equipItem_AudioSource.volume = volumeValue;
    }

    /*public void ChangeconfirmedClickSFXVolume(float volumeValue)
    {
        PlayerPrefs.SetFloat("confirmedClickSFXVolume", volumeValue);
        //Typing is rather loud as default
        //So we make custom volume by multiple with volumeValue
        confirmedClickSFX_AudioSource.volume = volumeValue;
    }

    //This method will load from PlayerPref
    //And set the volumeValue as saved
    private void LoadVolumeValue()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
        BGM_AudioSource.volume = PlayerPrefs.GetFloat("BGMVolume");

        var _SFX_SavedValue = PlayerPrefs.GetFloat("SFXVolume");
        backClickSFX_AudioSource.volume = _SFX_SavedValue;
        item_AudioSource.volume = _SFX_SavedValue;

        confirmedClickSFX_AudioSource.volume = PlayerPrefs.GetFloat("confirmedClickSFXVolume");
        //In case there is no speaker/Dialogue System
        //Set default AudioClip to Lilly
        confirmedClickSFX_AudioSource.clip = soundScriptableObject.LillySFX;
    }*/
}