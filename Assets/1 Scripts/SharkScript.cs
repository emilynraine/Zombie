using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public MSMScript _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<MSMScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "harpoon")
        {
            print("shark hit");
            _manager.IncreaseScore();
            Invoke("DestroyShark", 2.0f);
        }
    }

    void DestroyShark()
    {
        Destroy(gameObject);
    }
}
