using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudscript : MonoBehaviour
{

    private float _speed = 2;
    private float _endPosX;

    void Start()
    {
        
    }


    public void StartFloating(float speed, float endPosX)
    {

        _speed = speed;
        _endPosX = endPosX;


    }
    
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _speed));


        if(transform.position.x > _endPosX)
        {
            Destroy(gameObject);

        }


    }
}
