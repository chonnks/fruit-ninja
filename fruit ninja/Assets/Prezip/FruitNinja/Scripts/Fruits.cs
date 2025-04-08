using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private GameManager gm;
    public GameObject slicedFruit;
    public GameObject fruitJuice;
    private float rotationForce = 200;
    private Rigidbody rb;
    
    public int scorePoints;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }

    private void InstantiateSlicedFruit()
    {
        GameObject instantiatedFruit = Instantiate(slicedFruit, transform.position, transform.rotation);
        GameObject instantiatedJuice = Instantiate(fruitJuice, new Vector3(transform.position.x, transform.position.y, 0), fruitJuice.transform.rotation);

        Rigidbody[] slicedRb = instantiatedFruit.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody srb in slicedRb)
        {
            srb.AddExplosionForce(130f, transform.position, 10);
            srb.linearVelocity = rb.linearVelocity * 1.2f;
        }

        Destroy(instantiatedFruit, 5);
        Destroy(instantiatedJuice, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            gm.UpdateTheScore(scorePoints);
            InstantiateSlicedFruit();
            Destroy(gameObject);
        }

        if (other.tag == "BottomTrigger")
        {
            gm.UpdateLives();
            Destroy(gameObject);
        }
    }
}
