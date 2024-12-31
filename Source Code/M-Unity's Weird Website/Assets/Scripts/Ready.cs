using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ready : MonoBehaviour
{
    [SerializeField] private DarkDirector drk;
    public void LoadScene(string scene)
    {
        StartCoroutine(Loadscn(scene));
    }
    private IEnumerator Loadscn(string scene)
    {
        drk.Dark();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
