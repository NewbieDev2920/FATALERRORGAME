using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private AudioSource audioSource;
    
    // Diccionario para almacenar los clips de sonido según el nombre del evento.
    private Dictionary<string, AudioClip> audioClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClips = new Dictionary<string, AudioClip>();
        
        audioClips["pickPistol"] = Resources.Load<AudioClip>("Audio/pistol pick up");
        audioClips["firePistol"] = Resources.Load<AudioClip>("Audio/pistol firing");
        audioClips["reloadPistol"] = Resources.Load<AudioClip>("Audio/pistol reloading");
        audioClips["pickShotgun"] = Resources.Load<AudioClip>("Audio/shotgun pick up 1");
        audioClips["fireShotgun"] = Resources.Load<AudioClip>("Audio/shotgun firing");
        audioClips["reloadShotgun"] = Resources.Load<AudioClip>("Audio/shotgun reloading");
        audioClips["selectButton"] = Resources.Load<AudioClip>("Audio/button selection 2");
        audioClips["waveComplete"] = Resources.Load<AudioClip>("Audio/wave cleared 2");
    }
    
    // Método para reproducir el audio en función del evento
    public void Play(string eventName)
    {
        if (audioClips.ContainsKey(eventName))
        {
            audioSource.clip = audioClips[eventName];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning($"The audio event '{eventName}' doesnt have a clip assigned.");
        }
    }
}
