using UnityEngine;
using UnityEngine.SceneManagement;

public class Ready : MonoBehaviour
{
    [SerializeField] private int indexscene;
    public void LoadScene()
    {
        SceneManager.LoadScene(indexscene);
    }
}
