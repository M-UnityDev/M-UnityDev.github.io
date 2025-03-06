using System.Collections; using UnityEngine; using Unity.Burst; 
[BurstCompile] public class DialGiver : MonoBehaviour
{
    [SerializeField] private GameObject DialogPanel;
    [SerializeField] private string[] DialogPartsToUse; 
    [SerializeField] private AudioClip[] TextSoundsToUse;
    private void GiveDial()
    {
        DialogPanel.GetComponent<Dial>().DialogPartsF = DialogPartsToUse;
        DialogPanel.GetComponent<Dial>().TextSoundF = TextSoundsToUse;
        DialogPanel.SetActive(true);
        StartCoroutine(DialogPanel.GetComponent<Dial>().Dialog());
    }
    public IEnumerator StartDialAndWaitUntilEnd()
    {
        GiveDial();
        yield return new WaitUntil(() => DialogPanel.GetComponent<Dial>().IsEndedF);
        DialogPanel.GetComponent<Dial>().IsEndedF = false;
        yield return true;
    }							
}
