using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManeger.isGameWin)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Anima.instance.transform.position.z - 6f);
        }
    }
}
