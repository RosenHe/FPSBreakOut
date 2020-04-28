using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public List<GameObject> boxList = new List<GameObject>();
    public Text textRef;

    [SerializeField] private int difficulty = 0;
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
    private float distance;


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
            GameObject color3Box = Instantiate(prefabBox3) as GameObject;
            color3Box.transform.SetParent(transform, false);
            color3Box.name = "box-" + a.ToString();
            boxList.Add(color3Box);
        }

        buffer = boxList.Count;
        for (int b = 0; b < boxNumYellow; b++)
        {
            GameObject color4Box = Instantiate(prefabBox2) as GameObject;
            color4Box.transform.SetParent(transform, false);
            color4Box.name = "box-" + (buffer + b).ToString();
            boxList.Add(color4Box);
        }

        buffer = boxList.Count;
        for (int c = 0; c < boxNumRed; c++)
        {
            GameObject color5Box = Instantiate(prefabBox1) as GameObject;
            color5Box.transform.SetParent(transform, false);
            color5Box.name = "box-" + (buffer + c).ToString();
            boxList.Add(color5Box);
        }
        //Debug.Log(boxList.Count);
        //then we randomly sort them
        boxList = FYShuffler(boxList);

        buffer = 0;
        int dim = 0;

        float diffMultiplier = 2*( 1 - difficulty);

        //now we organize them into a wall!
        for (int row = 0; row < width + diffMultiplier; row++)
        {
            for (int col = 0; col < depth; col++)
            {
                for (dim = 0; dim < height ; dim++)
                {
                    boxList[buffer].transform.position = new Vector3(boxList[buffer].transform.position.y + ((row) * 1.5f), boxList[buffer].transform.position.y + ((dim) * 1.5f), boxList[buffer].transform.position.z + ((col) * 1.5f));
                    buffer++;
                    //Debug.Log(buffer);


                };
            }

        }
        for (; buffer < boxList.Count; buffer++)
        {
            Destroy(boxList[buffer]);
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
