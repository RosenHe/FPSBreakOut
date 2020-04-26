using System.Collections;
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
    GameObject prefabBox1;
    GameObject prefabBox2;
    GameObject prefabBox3;

    [SerializeField] private int width = 9;
    [SerializeField] private int depth = 3;
    [SerializeField] private int height = 3;
    private int boxNumBlue;
    private int boxNumYellow;
    private int boxNumRed;

    private List<GameObject> boxList = new List<GameObject>();
    private GameObject[,,] boxWall;
    [SerializeField] private int difficulty = 0;
 
    private void Awake()
    {
        
        prefabBox1 = Resources.Load("Boxes/box_1") as GameObject;
        prefabBox2 = Resources.Load("Boxes/box_2") as GameObject;
        prefabBox3 = Resources.Load("Boxes/box_3") as GameObject;
    }


    private void Start()
    { 

        SetDifficulty();
        MakeBoxes();
        
    }

    private void MakeBoxes()
    {

        //after getting the number of boxes we need we create that amount and add to an array
        for (int a = 0; a < boxNumBlue; a++){
            GameObject blueBox = Instantiate(prefabBox3) as GameObject;
            blueBox.transform.SetParent(transform, false);
            boxList.Add(blueBox);
        }
        for (int b = 0; b < boxNumBlue; b++)
        {
            GameObject ylwBox = Instantiate(prefabBox2) as GameObject;
            ylwBox.transform.SetParent(transform, false);
            boxList.Add(ylwBox);
        }
        for (int c = 0; c < boxNumBlue; c++)
        {
            GameObject redBox = Instantiate(prefabBox1) as GameObject;
            redBox.transform.SetParent(transform, false);
            boxList.Add(redBox);
        }

        for (int i = 0; i < boxList.Count; i++)
        {
            boxList[i].transform.position = new Vector3(0,0, boxList[i].transform.position.z + (i * 1.5f));
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
