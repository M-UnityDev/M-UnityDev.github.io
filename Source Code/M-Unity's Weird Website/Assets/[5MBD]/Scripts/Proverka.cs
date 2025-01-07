using UnityEngine;
using UnityEngine.UI;

public class Proverka : MonoBehaviour
{
    [SerializeField] private GameObject krovat;
    [SerializeField] private GameObject creslo; 
    [SerializeField] private GameObject cover; 
    [SerializeField] private GameObject polka; 
    [SerializeField] private Button readybutton;

    private void Update()
    {
        readybutton.interactable = AreAllObjectsVisible();
    }

    private bool AreAllObjectsVisible()
    {
        return krovat.activeInHierarchy && creslo.activeInHierarchy && cover.activeInHierarchy && polka.activeInHierarchy;
    }
}


