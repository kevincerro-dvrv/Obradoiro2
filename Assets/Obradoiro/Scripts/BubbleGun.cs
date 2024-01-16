using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGun : MonoBehaviour {
    public GameObject bubblePrefab;
    public Transform bubbleSpawnPoint;
    private bool bubbleGunOn;

    private Vector3 windVelocity;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnBubbles());
        bubbleGunOn = false;

        //Establecemos aleatoriamente a velocidade do vento
        windVelocity = Random.insideUnitCircle;
        windVelocity.z = windVelocity.y;
        windVelocity.y = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(bool active) {
        bubbleGunOn = active;

    }

    private IEnumerator SpawnBubbles() {
        while(true) {
            if(bubbleGunOn) {
                GameObject bubbleGO = Instantiate(bubblePrefab, bubbleSpawnPoint.position, Quaternion.identity);
                bubbleGO.GetComponent<Bubble>().SetVelocity(windVelocity);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
