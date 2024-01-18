using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachSelector : MonoBehaviour
{
    public List<string> tagList;
    public List<Transform> attachList;
    public Transform defaultAttach;
    private XRGrabInteractable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAttach(SelectEnterEventArgs args)
    {
        SetCustomAttach(args);
    }

    public void SetAttach(HoverEnterEventArgs args)
    {
        SetCustomAttach(args);
    }


    private void SetCustomAttach(BaseInteractionEventArgs args)
    {
        if(interactable != null) {
            InteractorIdentifier iId = ((MonoBehaviour)args.interactorObject).GetComponent<InteractorIdentifier>();
            if (iId == null) {
                interactable.attachTransform = defaultAttach;
            } else {
                if (tagList.Contains(iId.InteractorTag)) {
                    //interactable.attachTransform
                    int index = tagList.IndexOf(iId.InteractorTag);
                    interactable.attachTransform = attachList[index];
                } else {
                    interactable.attachTransform = defaultAttach;
                }
            }
        }
    }
}
