using DG.Tweening;
using UnityEngine;
using System;
public class MouthHandler : MonoBehaviour
{
    [SerializeField] private AudioSource ASS;
    [SerializeField] private float Multiplr;
    [SerializeField] private int RoundUntil;
    private float a;
    private float[] spectrum;
    private void Awake() => spectrum = new float[32];
    private void FixedUpdate()
    {
	ASS.GetOutputData(spectrum, 1);
        foreach (float i in spectrum)
	{
            if (i.Equals(0))
	    {
                a = 0.065f;
	    	break;
	    }
	    else a = Mathf.Clamp((float)Math.Round(i*1,RoundUntil)*Multiplr, 0.03f, 0.1f);
	}
	transform.DOScaleY(a, 0.25f);
    }
}
