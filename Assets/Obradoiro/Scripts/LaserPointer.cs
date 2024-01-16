using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {
    [Header("Debug")]
    public GameObject debugBallPrefab;
    public bool debug;
    private GameObject debugBall;
    [Header("LaserRay")]
    public GameObject laserRayGO;
    public LineRenderer laserBeam;

    void Update() {
        RaycastHit hit;

        if(Physics.Raycast(laserRayGO.transform.position, transform.up, out hit)) {
            if(debug) {
                if(debugBall == null) {
                    debugBall = Instantiate(debugBallPrefab);
                }
                debugBall.transform.position = hit.point;
            }

            laserBeam.SetPosition(laserBeam.positionCount-1, laserRayGO.transform.InverseTransformPoint(hit.point));
        }
    }

    public void ActivateRay(bool activate){
        laserRayGO.SetActive(activate);
    }
}
