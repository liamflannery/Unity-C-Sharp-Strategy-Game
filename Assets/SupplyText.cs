using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SupplyText : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text; 
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ResourceManager.Instance.getResources().ToString());
        text.text = ResourceManager.Instance.getResources().ToString();
    }
}
