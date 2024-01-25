using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void optionToggle()
    {
        if(this.gameObject.activeSelf) this.gameObject.SetActive(false);
        else this.gameObject.SetActive(true);
    }
}
