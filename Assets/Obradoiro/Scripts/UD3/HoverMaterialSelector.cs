using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverMaterialSelector : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material hoverMaterial;
    private Material normalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        normalMaterial = meshRenderer.material;
    }

    public void SetHoverMaterial(HoverEnterEventArgs args)
    {
        if (!(args.interactorObject is XRRayInteractor)) {
            meshRenderer.material = hoverMaterial;
        }
    }

    public void SetNormalMaterial(HoverExitEventArgs args)
    {
        if (!(args.interactorObject is XRRayInteractor)) {
            meshRenderer.material = normalMaterial;
        }
    }
}
