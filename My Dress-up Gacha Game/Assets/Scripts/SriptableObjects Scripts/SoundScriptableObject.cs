using UnityEngine;

[CreateAssetMenu(fileName = "Sound_SO", menuName = "ScriptableObject/SoundClips", order = 4)]
public class SoundScriptableObject: ScriptableObject
{
    [Header("BGM")]
    [SerializeField]
    private AudioClip backgroundMusic;

    public AudioClip BackgroundMusic
    {
        get
        {
            return backgroundMusic;
        }
        set
        {
            backgroundMusic = value;
        }
    }

    [Header("SFX")]
    [SerializeField]
    private AudioClip confirmedClick_SFX;

    public AudioClip ConfirmedClick_SFX
    {
        get
        {
            return confirmedClick_SFX;
        }
        set
        {
            confirmedClick_SFX = value;
        }
    }

    [SerializeField]
    private AudioClip backClick_SFX;

    public AudioClip BackClick_SFX
    {
        get
        {
            return backClick_SFX;
        }
        set
        {
            backClick_SFX = value;
        }
    }

    [SerializeField]
    private AudioClip gachaClick_SFX;

    public AudioClip GachaClick_SFX
    {
        get
        {
            return gachaClick_SFX;
        }
        set
        {
            gachaClick_SFX = value;
        }
    }

    [SerializeField]
    private AudioClip equipItem_SFX;

    public AudioClip EquipItem_SFX
    {
        get
        {
            return equipItem_SFX;
        }
        set
        {
            equipItem_SFX = value;
        }
    }

}
