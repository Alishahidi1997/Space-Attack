using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [Header("Destruction")]
    [SerializeField] float timeToDestroy = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    // Update is called once per frame
    
}
