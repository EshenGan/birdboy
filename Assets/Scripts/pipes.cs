using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipes : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float leftbound;
    // Start is called before the first frame update
    void Start()
    {
        leftbound = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftbound) {

            Destroy(gameObject);
        }
    }
}
