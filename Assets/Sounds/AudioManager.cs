using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips; 
    public AudioMixer audioMixer;
 
    public void SetMasterVolume (float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
 
    public void SetMusicVolume (float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
 
    public void SetSoundEffectVolume (float volume)
    {
        audioMixer.SetFloat("SoundEffectVolume", volume);
    }
    public void HighlightedButton()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }

    public void PressedButton()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }
}