using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioSource;
    
    // Diccionario para almacenar los clips de sonido según el nombre del evento.
    private Dictionary<string, AudioClip> audioClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClips = new Dictionary<string, AudioClip>();
        
        // Cargar clips de audio desde los archivos en la carpeta Resources
        // (los archivos deben estar en una carpeta llamada "Resources").
        audioClips["pickWeapon"] = Resources.Load<AudioClip>("Audio/pistol pick up");
        audioClips["fireWeapon"] = Resources.Load<AudioClip>("Audio/pistol firing 1");
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
            Debug.LogWarning($"El evento de audio '{eventName}' no tiene un clip asignado.");
        }
    }
}
