using DG.Tweening;
using UnityEngine;
public class MouthHandler : MonoBehaviour
{
    private Transform Transform;
    private void Awake()
    {
       Transform = transform;
    }
    private void FixedUpdate()
    {
        Transform.DOScaleY(Random.Range(0.065f, 0.1f), 0.1f);
    }
}
