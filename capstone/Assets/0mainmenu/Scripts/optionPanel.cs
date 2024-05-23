using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionPanel : MonoBehaviour
{
    public void optionToggle()
    {
        if(this.gameObject.activeSelf) this.gameObject.SetActive(false);
        else this.gameObject.SetActive(true);
    }
}
