using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipespawns : MonoBehaviour
{
    [SerializeField]private GameObject pipeprefab;
    [SerializeField] private GameObject altpipeprefab;
    [SerializeField] private birdboy birdboy;
    //parameters
    private float spawnrate = 1f;
    [SerializeField] private float minheight;
    [SerializeField]private float maxheight;

    private void OnEnable()
    {
        
        if (birdboy.altworld == true)
        {
            Debug.Log("altworld trigered");
            InvokeRepeating(nameof(initaltpipe), spawnrate, spawnrate);
        }
        else if (birdboy.altworld == false)
        {
            Debug.Log("altworld not trigered");
            InvokeRepeating(nameof(initpipe), spawnrate, spawnrate);
        }
    }

    private void OnDisable()
    {

        if (birdboy.altworld == true)
        {
            Debug.Log("cancelAltpipe");
            CancelInvoke(nameof(initaltpipe));
        }
        else if (birdboy.altworld == false)
        {
            Debug.Log("cancelPipe");
            CancelInvoke(nameof(initpipe));
        }


    }

    private void initpipe() {
        GameObject pipe = Instantiate(pipeprefab, transform.position,Quaternion.identity);
        pipe.transform.position += Vector3.up * Random.Range(minheight,maxheight);
        
    }

    private void initaltpipe() {
        GameObject altpipe = Instantiate(altpipeprefab, transform.position, Quaternion.identity);
        altpipe.transform.position += Vector3.up * Random.Range(minheight, maxheight);
    }

}
