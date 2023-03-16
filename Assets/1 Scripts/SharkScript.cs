using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public MSMScript _manager;
    public MoveSharkOnWaypoints  _movement;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindObjectOfType<MSMScript>();
        _movement = FindObjectOfType<MoveSharkOnWaypoints>();
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
            _movement._dead = true;
            Invoke("DestroyShark", .5f);
        }
    }

    void DestroyShark()
    {
        Destroy(gameObject);
    }
}
