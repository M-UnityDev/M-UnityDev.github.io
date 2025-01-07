using UnityEngine;
using UnityEngine.UI;
public class ObjectSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject originalObject; 
    [SerializeField] private GameObject blackVariant; 
    [SerializeField] private GameObject whiteVariant; 
    [SerializeField] private Button blackButton; 
    [SerializeField] private Button whiteButton; 

    private void Start()
    {
        blackButton.onClick.AddListener(OnBlackButtonClick);
        whiteButton.onClick.AddListener(OnWhiteButtonClick);
        
        blackVariant.SetActive(false);
        whiteVariant.SetActive(false);
        
        blackButton.gameObject.SetActive(false);
        whiteButton.gameObject.SetActive(false);
    }

    public void SetObjectToSwitch(GameObject newObject)
    {
        originalObject = newObject;
        
        if (originalObject != null)
        {
            blackButton.gameObject.SetActive(true);
            whiteButton.gameObject.SetActive(true);
        }
    }

    private void OnBlackButtonClick()
    {
        SwitchToVariant(blackVariant);
    }

    private void OnWhiteButtonClick()
    {
        SwitchToVariant(whiteVariant);
    }

    private void SwitchToVariant(GameObject newVariant)
    {
        originalObject.SetActive(false);
        
        blackVariant.SetActive(false);
        whiteVariant.SetActive(false);
        
        newVariant.SetActive(true);
        
        blackButton.gameObject.SetActive(false);
        whiteButton.gameObject.SetActive(false);
    }
}


