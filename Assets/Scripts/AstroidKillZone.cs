using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidKillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Asteroid"))
        {
            other.GetComponent<Animator>().SetTrigger("FadeOut");
            Destroy(other.gameObject,10f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
