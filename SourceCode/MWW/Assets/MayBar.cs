using UnityEngine;
using System.Collections;
using TMPro;
public class MayBar : MonoBehaviour
{
    [SerializeField] private TMP_Text timtxt;
    private void Update()
    {
        timtxt.text = System.DateTime.Now.ToString("HH:mm");
    }
}
