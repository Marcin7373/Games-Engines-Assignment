﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private Tree tree;
    public Material[] material;
    private Transform player;
    private TreeEditor.TreeData treeData;
    private float prog = 0.01f, speed = 0.01f, randSpeedMin, randSpeedMax, height = 0.2f;
    public float spawnRad = 15.0f;
    private bool startGrow = false;
    int randTargetHeight;
    Vector3 startHeight;

    void Awake()
    {
        tree = GetComponent<Tree>();
        player = GameObject.FindWithTag("Player").transform;
        
    }
    void Start()
    { 
        treeData = tree.data as TreeEditor.TreeData;
        startHeight = new Vector3(transform.position.x, transform.position.y-height+0.1f, transform.position.z);
        transform.position = startHeight;
        randTargetHeight = Random.Range(5,10);
        randSpeedMin = Random.Range(0.05f, 0.2f);
        randSpeedMax = Random.Range(0.5f, 0.8f);

        //treeData.root.seed = Random.Range(0, 999999);
        //treeData.UpdateMesh(tree.transform.worldToLocalMatrix, out material);
    }

    void Update()
    {
        if ((player.position - transform.position).magnitude < spawnRad && (player.position - transform.position).magnitude > spawnRad-3)
        {
            startGrow = true;
        }

        Vector3 direction = new Vector3(player.position.x, player.position.y - randTargetHeight, player.position.z) - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);
        targetRot = Quaternion.Euler(targetRot.eulerAngles.x, targetRot.eulerAngles.y+(Random.Range(0, 60)-30), targetRot.eulerAngles.z);

        if (startGrow) {

            //    slowdown as it goes * half speed
            prog += Time.deltaTime * (1 - prog) * speed;
            if (prog < 0.7f) {
                
                speed = Mathf.Lerp(randSpeedMax, randSpeedMin, prog);
                transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, randSpeedMax+0.2f, 1), prog);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, prog * Time.deltaTime);
                transform.position = Vector3.Lerp(startHeight, new Vector3(startHeight.x, startHeight.y + height, startHeight.z+0.1f), prog);
            }
            else if(prog < 0.9f)
            {
                //speed = randSpeedMax;
                transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, randSpeedMax+0.2f, 1), prog);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, prog * Time.deltaTime * 0.2f);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, prog * Time.deltaTime * 0.03f);
            }

        }
    }
}
