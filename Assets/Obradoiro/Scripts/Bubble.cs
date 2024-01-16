using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
    private Vector3 velocity;

    private float timeToLive;
    private Vector3 startScale;
    private Vector3 finalScale;

    //Variable para controlar o Lerp da escala
    private float t;

    public int id;

    // Start is called before the first frame update
    void Start() {
        id = Random.Range(0, 1000000000);

        timeToLive = Random.Range(5.0f, 10.0f);
        Destroy(gameObject, timeToLive);

        startScale = transform.localScale;
        //A escala final é a inicial mutiplicada por un valor entre 2 e 2.5, aleatorio
        finalScale = startScale * Random.Range(2.5f, 3f);

        t = 0;
    }




    // Update is called once per frame
    void Update() {
        Vector3 newPosition = transform.position;
        newPosition += velocity * Time.deltaTime;
        transform.position = newPosition;

        //Facemos que a burbulla medre
        t += Time.deltaTime / timeToLive;
        transform.localScale = Vector3.Lerp(startScale, finalScale, t);
    }


    public void SetVelocity(Vector3 velocity) {
        this.velocity = velocity * Random.Range(0.95f, 1.05f) + (Vector3)Random.insideUnitCircle * 0.2f;
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("Bubble OnCollisionEnter");
        if(other.gameObject.CompareTag("Bubble")) {
            if(this.id < other.GetComponent<Bubble>().id) {
                Destroy(other.gameObject);
                startScale *= 1.5f;
                finalScale *= 1.5f;
            }
        } else if( ! other.gameObject.CompareTag("BubbleGun")) {
            Destroy(gameObject);
        }
    }
}
