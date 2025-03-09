using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    private bool isSliced = false;

    private void Start()
    {
        StartCoroutine(FruitTimeout());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CreateSlidedFruit();
        }
    }

    public void CreateSlidedFruit()
    {
        isSliced = true;
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        FindAnyObjectByType<GameManager>().PlayRandomSliceSounds();
        Rigidbody[] rigidbodiesOnSliced = inst.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody body in rigidbodiesOnSliced)
        {
            body.transform.rotation = Random.rotation;
            body.AddExplosionForce(Random.Range(200, 1000), transform.position, 5f);
        }

        FindFirstObjectByType<GameManager>().IncreaseScore(3);

        Destroy(inst.gameObject, 6);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return;
        }
        CreateSlidedFruit();
    }

    private IEnumerator FruitTimeout()
    {
        yield return new WaitForSeconds(4);

        if (!isSliced)
        {
            Debug.Log("Fruit missed! Losing a life...");
            FindFirstObjectByType<GameManager>().LoseLife();
            Destroy(gameObject);
        }
    }



}
