using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] GameObject Slippers1,Slippers2,Slippers3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Shooting.bulletNumber == 3)
        {
            Slippers3.SetActive(true);
            Slippers2.SetActive(true);
            Slippers1.SetActive(true);
        }
        else if (Shooting.bulletNumber == 2)
        {
            Slippers3.SetActive(false);
            Slippers2.SetActive(true);
            Slippers1.SetActive(true);
        }
        else if (Shooting.bulletNumber == 1)
        {
            Slippers3.SetActive(false);
            Slippers2.SetActive(false);
            Slippers1.SetActive(true);
        }
        else if (Shooting.bulletNumber == 0)
        {
            Slippers3.SetActive(false);
            Slippers2.SetActive(false);
            Slippers1.SetActive(false);
        }
    }
}
