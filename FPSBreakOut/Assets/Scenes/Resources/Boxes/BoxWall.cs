﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWall : MonoBehaviour
{   /*
        This script creates a box wall that moves away from the player
        It makes a default wall of 3x3x9 boxes = 81 boxes
        it can make three level types: easy, medium,  hard
        The level changes the distribution of the number of blocks
        Easy : 45 bl, 18 yl, 18 red
        Medium: 27 bl, 27 yl, 27 red
        Hard: 18 bl, 18 yl, 45 red
    */
    [SerializeField] Transform playerT;
    GameObject prefabBox1;
    GameObject prefabBox2;
    GameObject prefabBox3;

    private int width = 9;
    private int depth = 3;
    private int height = 3;

    private int boxNumBlue;
    private int boxNumYellow;
    private int boxNumRed;

    private List<GameObject> boxList = new List<GameObject>();
    [SerializeField] private int difficulty = 0;
 
    private void Awake()
    {
        
        prefabBox1 = Resources.Load("Boxes/box_3") as GameObject;
        prefabBox2 = Resources.Load("Boxes/box_4") as GameObject;
        prefabBox3 = Resources.Load("Boxes/box_5") as GameObject;

        
    }


    private void Start()
    {
        transform.position = new Vector3(-6, 0, 16);
        SetDifficulty();
        MakeBoxes();
        
    }

    private void MakeBoxes()
    {
        int buffer = 0;

        //after getting the number of boxes we need we create that amount and add to a list
        for (int a = 0; a < boxNumBlue; a++)
        {
            GameObject blueBox = Instantiate(prefabBox3) as GameObject;
            blueBox.transform.SetParent(transform, false);
            blueBox.name = "box-" + a.ToString();
            boxList.Add(blueBox);
        }

        buffer = boxList.Count;
        for (int b = 0; b < boxNumYellow; b++)
        {
            GameObject ylwBox = Instantiate(prefabBox2) as GameObject;
            ylwBox.transform.SetParent(transform, false);
            ylwBox.name = "box-" + (buffer + b).ToString();
            boxList.Add(ylwBox);
        }

        buffer = boxList.Count;
        for (int c = 0; c < boxNumRed; c++)
        {
            GameObject redBox = Instantiate(prefabBox1) as GameObject;
            redBox.transform.SetParent(transform, false);
            redBox.name = "box-" + (buffer + c).ToString();
            boxList.Add(redBox);
        }
        Debug.Log(boxList.Count);
        //then we randomly sort them
        boxList = FYShuffler(boxList);

        buffer = 0;
        int dim = 0;
        //now we organize them into a wall!
        for (int row = 0; row < width; row++)
        {
            for (int col = 0; col < depth; col++)
            {
                for (dim = 0; dim < height; dim++)
                {
                    boxList[buffer].transform.position = new Vector3(boxList[buffer].transform.position.y + ((row) * 1.5f), boxList[buffer].transform.position.y + ((dim) * 1.5f), boxList[buffer].transform.position.z + ((col) * 1.5f));
                    buffer++;
                    //Debug.Log(buffer);


                };
            }

        }
    }

    private void SetDifficulty() //set the number of box types based on difficulty and size of wall
    {
        
        switch (difficulty)
        {
            case 3: //hard
                {
                    boxNumBlue = width * 2;
                    boxNumYellow = width * 2;
                    boxNumRed = width * 5;
                    break;
                }
            case 2: //medium
                {
                    boxNumBlue = width * 3;
                    boxNumYellow = width * 3;
                    boxNumRed = width * 3;
                    break;
                }
            case 1 : //easy
                {
                    boxNumBlue = width * 5;
                    boxNumYellow = width * 2;
                    boxNumRed = width * 2;
                    break;
                }
            default:
                {
                    Debug.LogError("difficulty not set");
                    boxNumBlue = 0;
                    boxNumYellow = 0;
                    boxNumRed = 0;
                    break;
                }

        }
    }


    private float distance;

    // Update is called once per frame
    void Update()
    {
    
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //have to set the collision distance dynamically for smoothness
            distance = transform.position.z - other.gameObject.transform.position.z;
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            //Debug.Log("entered the collider trigger");

            //only moves wall when player is moving towards it and colliding
            if (!Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, (col.gameObject.transform.position.z + distance));
            }
        }
        
    }


    //Fisher-Yates-Random-Shuffler
    public static List<GameObject> FYShuffler(List<GameObject> aList)
    {

        System.Random _random = new System.Random();

        GameObject myGO;

        int n = aList.Count;
        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }

        return aList;
    }
}
