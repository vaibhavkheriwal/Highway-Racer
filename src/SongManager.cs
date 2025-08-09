using System.Collections;
using UnityEngine;
public class SongManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clip = new AudioClip[10];
    AudioClip temp;
    void Start()
    {
        StartCoroutine(PlaySong());
    }
    IEnumerator PlaySong()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            temp = clip[Random.Range(0, 10)];
            audioSource.clip = temp;
            audioSource.Play();
            yield return new WaitForSeconds(temp.length);
            StartCoroutine(PlaySong());
        }   
    }
}