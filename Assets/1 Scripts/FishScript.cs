using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    PlayerShootScript _pSScript;
    // Start is called before the first frame update
    void Start()
    {
        _pSScript = FindObjectOfType<PlayerShootScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "harpoon")
        {
            print("fish hit");
            _pSScript._hasUnlimited = true;
            Destroy(gameObject);
        }

            
        
    }
}
