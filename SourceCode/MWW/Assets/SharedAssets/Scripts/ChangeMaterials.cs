using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{
    private MeshRenderer Mesh; 
    [SerializeField] private Material[] NewMaterials;
    private void Awake()
    {
        Mesh = GetComponent<MeshRenderer>(); 
    }

    public void Change() => Mesh.materials = NewMaterials;
    public void Change(Material[] mats) => Mesh.materials = mats;
}
