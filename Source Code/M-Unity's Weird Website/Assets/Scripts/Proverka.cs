using UnityEngine;

public class Proverka : MonoBehaviour
{
    [SerializeField] private GameObject krovat;
    [SerializeField] private GameObject creslo; 
    [SerializeField] private GameObject cover; 
    [SerializeField] private GameObject polka; 
    [SerializeField] private GameObject readybutton;

    void Update()
    {
        if (AreAllObjectsVisible())
        {
            readybutton.SetActive(true);
        }
        else
        {
            readybutton.SetActive(false);
        }
    }

    private bool AreAllObjectsVisible()
    {
        return krovat.activeInHierarchy && creslo.activeInHierarchy && cover.activeInHierarchy && polka.activeInHierarchy;
    }
}


