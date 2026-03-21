using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] AudioSource sfxSource;

    [Header("Clips")]
    public AudioClip walk;
    public AudioClip apple;

    public static AudioManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        ChangeVolume(sfxSource, savedVolume);
    }

    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.pitch = Random.Range(0.9f, 1.1f);
        sfxSource.PlayOneShot(audioClip);
    }
    public void ChangeVolume(AudioSource source, float amount)
    {
        source.volume = amount;
    }
}
