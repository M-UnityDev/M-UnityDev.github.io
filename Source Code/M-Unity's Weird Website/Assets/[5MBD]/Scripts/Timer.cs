using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Burst;
using TMPro;
[BurstCompile]
public class Timer : MonoBehaviour
{
    private int time = 300;
    [SerializeField] private TMP_Text timtxt;
    [SerializeField] private DarkDirector drk;
    private void Awake() => StartCoroutine(nameof(Time));
    private IEnumerator Time()
    {
        while(time !< 0 || time != 0)
        {
            yield return new WaitForSeconds(1);
            time -= 1;
            timtxt.text = (time/60%60).ToString() + ":" + (time%60 < 10 ? "0" : null) +(time%60).ToString();
        }
        drk.Dark();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("[5MBD]Cutscene");
    }
}