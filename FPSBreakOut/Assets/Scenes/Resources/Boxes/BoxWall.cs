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

    private GameObject[,,] boxWall; 
    [SerializeField] private enum difficulty { Na, Easy, Medium, Hard};
    private difficulty diff;
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
        GameObject box1 = Instantiate(prefabBox1) as GameObject;
        GameObject box2 = Instantiate(prefabBox2) as GameObject;
        GameObject box3 = Instantiate(prefabBox3) as GameObject;
    }

    private void MakeBoxes()
    {

    }

    private void SetDifficulty() //set the number of box types based on difficulty and size of wall
    {
        
        switch (diff)
        {
            case difficulty.Hard:
                {
                    boxNumBlue = width * 2;
                    boxNumYellow = width * 2;
                    boxNumRed = width * 5;


                    break;
                }
            case difficulty.Medium:
                {
                    boxNumBlue = width * 3;
                    boxNumYellow = width * 3;
                    boxNumRed = width * 3;
                    break;
                }
            default :
                {
                    boxNumBlue = width * 5;
                    boxNumYellow = width * 2;
                    boxNumRed = width * 2;
                    break;
                }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
