using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private MeshRenderer _objRenderer;

    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material SelectedMaterial;

    void Start()
    {
        _objRenderer = GetComponent<MeshRenderer>();
    }
    
    public void SetMaterial(Material material)
    {
        _objRenderer.material = material;
    }

    void OnMouseEnter()
    {
        SetMaterial(SelectedMaterial);
    }

    void OnMouseExit()
    {
        SetMaterial(normalMaterial);
    }

    // public void Select()
    // {
    //     
    // }
}
