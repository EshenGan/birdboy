using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdboy : MonoBehaviour
{
    [SerializeField]private Vector3 direction;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float altgravity = 9.8f;
    [SerializeField] public bool altworld = false;
    [SerializeField] private float pulse = 5f;

    private SpriteRenderer spriterenderer;
    private int spriteindex;
    [SerializeField]private Sprite[] sprite;
    [SerializeField] private Sprite[] altsprite;
    //[SerializeField] private int counter=0;
    [SerializeField] private int randnum;

    private void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        altworld = false;
        //counter = 0;
    }

    private void Start()
    {
        //counter = 0;
            //altworld = false;
            InvokeRepeating(nameof(animateflyingbirdboy),0.2f,0.2f);//nameof method converts methodName to strings which invokeRepeating requires
        
    }

    // Update is called once per frame
    void Update()
    {
        if (altworld == true) {
            InvokeRepeating(nameof(animateflyingbirdboy),0.2f,0.2f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction = Vector3.down * pulse;
            }

            direction.y += altgravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;

        }
        else if (altworld == false) {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction = Vector3.up * pulse;
            }

            direction.y += gravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        randnum = Random.Range(1,4);
        if (collision.gameObject.CompareTag("bluepipes") || collision.gameObject.CompareTag("pipes") || collision.gameObject.CompareTag("ground")) {

            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collision.gameObject.CompareTag("pointzone")) {
            FindObjectOfType<GameManager>().scoreinc();
            //counter++;
            if (randnum == 3) {
                Debug.Log("testing1");
                altworld = true;
            }
            else if(randnum == 1 || randnum ==2){
                Debug.Log("testing2");
                altworld = false;
            }

            //if (counter == 1)
            //{
            //    Debug.Log("testing1");
            //    altworld = true;
            //}
            //else if ( counter == 3 )
            //{
            //    Debug.Log("testing2");
            //    altworld = false;
            //}
        }
    }

    private void animateflyingbirdboy() {

        spriteindex++;
        if (spriteindex >= sprite.Length)
        {
            spriteindex = 0;
        }

        if (altworld == false) {
            spriterenderer.sprite = sprite[spriteindex];
        }
        else if (altworld == true) {
            spriterenderer.sprite = altsprite[spriteindex];
        }
        
    }

    private void OnEnable()
    {
        transform.position = new Vector3(0,0,1f);
        direction = Vector3.zero;
        //counter = 0;
        altworld = false;
    }

}
