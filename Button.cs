using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private int butt = -1;
    public GameManager gm;

    // Use this for initialization
    void Start()
    {
        if (this.gameObject.tag == "RedButt")
        {
            butt = 0;
        }
        else if (this.gameObject.tag == "BlueButt")
        {
            butt = 1;
        }
        else
        {
            butt = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (butt == 0)
            {
                gm.redBlock();
            }
            if (butt == 1)
            {
                gm.blueBlock();
            }
            else
            {
                gm.greenBlock();
            }

        }
    }
}
