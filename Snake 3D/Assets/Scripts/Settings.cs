using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource sfxSource;
    
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", sfxSource.volume);
    }

    public void OnVolumeChanged()
    {
        AudioManager.Instance.ChangeVolume(sfxSource, volumeSlider.value);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
