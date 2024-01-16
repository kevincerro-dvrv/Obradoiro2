using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {
    public GameObject lightGO;

    public void SwitchLight() {
        lightGO.SetActive( ! lightGO.activeSelf);
    }
}
