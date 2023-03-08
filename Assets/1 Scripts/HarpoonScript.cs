using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonScript : MonoBehaviour
{
    public HarpoonTipScript _harpoonTip;
    // Start is called before the first frame update
    void Start()
    {
        _harpoonTip = FindObjectOfType<HarpoonTipScript>();
        _harpoonTip.SetParent(this);
       
    }

    // Update is called once per frame
    void Update()
    {
        _harpoonTip.SetParentTransform(transform);
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
