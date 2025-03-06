using System.Collections; using TMPro; using UnityEngine; using DG.Tweening; using Unity.Burst;

[BurstCompile] public class Dial : MonoBehaviour
{
    [SerializeField] private TMP_Text DialogText;
    [SerializeField] private string[] DialogParts;
    public string[] DialogPartsF {set{DialogParts = value;}}
    [SerializeField] private AudioClip ButtonSound;
    [SerializeField] private AudioSource AudioSour; 
    [SerializeField] private AudioClip[] TextSound;
    public AudioClip[] TextSoundF {set{TextSound = value;}}
    private bool IsEnded = false;
    public bool IsEndedF {get => IsEnded; set => IsEnded = value;}
    public IEnumerator Dialog()
    {
        DialogText.text = null;
        yield return new WaitForSeconds(0.5f);
        foreach (string TextPart in DialogParts)
        {
            DialogText.text = null;
            foreach(char a in TextPart)
            {
                AudioSour.PlayOneShot(TextSound[Random.Range(0, TextSound.Length)]);
                DialogText.text += a;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(5f);
            AudioSour.PlayOneShot(ButtonSound);
        }
        IsEnded = true;
        DialogText.text = null;
    }
}
