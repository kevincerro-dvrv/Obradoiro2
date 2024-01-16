using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlexGrabInteractable : XRGrabInteractable
{
    public List<string> acceptedTags;

    public override bool IsHoverableBy(IXRHoverInteractor interactor)
    {
        InteractorIdentifier iId = ((MonoBehaviour)interactor).GetComponent<InteractorIdentifier>();

        if (iId != null) {
            if (acceptedTags.Contains(iId.InteractorTag)) {
                return true;
            }
        }

        return false;
    }

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        InteractorIdentifier iId = ((MonoBehaviour)interactor).GetComponent<InteractorIdentifier>();

        if (iId != null) {
            if (acceptedTags.Contains(iId.InteractorTag)) {
                return true;
            }
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
