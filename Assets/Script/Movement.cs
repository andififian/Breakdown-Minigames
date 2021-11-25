﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //[SerializeField] private Slider healthBar;
    private Vector3 PosA;
    private Vector3 posB;
    private Vector3 nextpos;
    [SerializeField]private float speed;
    [SerializeField]private Transform childTransform;
    [SerializeField]private Transform transformB;
    // Start is called before the first frame update
    void Start()
    {
        posB = childTransform.localPosition;
        posB = transformB.localPosition;
        nextpos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextpos, speed * Time.deltaTime);
        if(Vector3.Distance(childTransform.localPosition, nextpos)<= 0.1)
        {
            changePos();
        }
    }
    private void changePos()
    {
        nextpos = nextpos != PosA ? PosA : posB;

    }
    
}
