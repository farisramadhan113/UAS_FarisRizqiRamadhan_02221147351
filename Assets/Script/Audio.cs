using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource backgroundMusic;

    void Start()
    {
        // Memulai pemutaran audio saat game dimulai
        backgroundMusic.Play();
    }
}
