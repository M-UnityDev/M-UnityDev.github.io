using UnityEngine;
using Unity.Burst;
[BurstCompile] public class SpeakHandler : MonoBehaviour
{
    [SerializeField] private AudioClip[] VoiceSounds;
    private AudioSource Voice;
    private void Awake()
    {
    	Voice = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        Voice.PlayOneShot(VoiceSounds[Random.Range(0,VoiceSounds.Length)]);
    }
}
