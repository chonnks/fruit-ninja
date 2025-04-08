using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bombs : MonoBehaviour
{
    private float rotationForce = 200;
    public ParticleSystem explosionParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
