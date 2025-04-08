using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;
    public float left;
    public float right;

    void Start()
    {
        StartCoroutine(SpawnRandomObject());
    }

    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(1);

        while (FindObjectOfType<GameManager>().gameIsOver == false)
        {
            // Spawn a random object
            InstantiateRandomObject();
            yield return new WaitForSeconds(RandomRepeatRate());
        }
        {
            InstantiateRandomObject();
            yield return new WaitForSeconds(RandomRepeatRate());

        }
    }

    private void InstantiateRandomObject()
    {
        int objectIndex = Random.Range(0, objects.Length);

        GameObject obj = Instantiate(objects[objectIndex], 
            transform.position, objects[objectIndex].transform.rotation);
    
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
           rb.AddForce(RandomVector() * RandomForce(), ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("Spawned object has no rigbidbody component.");
        }

        obj.transform.rotation = Random.rotation;
    }

    private float RandomForce()
    {
        float force = Random.Range(14f, 16f);
        return force;
    }

    private float RandomRepeatRate()
    {
        float repeatRate = Random.Range(0.5f, 3f);
        return repeatRate;
    }

    private Vector2 RandomVector()
    {
        Vector2 moveDirection = new Vector2(Random.Range(left, right), 1).normalized;
        return moveDirection;
    }

}
