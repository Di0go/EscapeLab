using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreakParticles : MonoBehaviour
{
    public float cubeSize = 20f;
    public int cubesInRow = 5;


    void Start()
    {

    }

    
    void Update()
    {
        if(Input.GetKey("a"))
        {
            explode();
        }
    }

    public void explode() {
        Destroy(gameObject);

        //creates wall pieces
        for (int x = 0; x < cubesInRow; x++){
            for(int y = 0; y < cubesInRow; y++){
                for (int z = 0; z < cubesInRow; z++){
                    float r = Random.Range(1, 100);
                    float c;
                    if (r < 22) c = 1;
                    else c = 2;
                    createPiece(x, y, z, c);
                }
            }
        }
    }

    void createPiece(int x, int y, int z, float c) { //magic

        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z);
        piece.transform.localScale = new Vector3(cubeSize + 1.5f, cubeSize + 1.5f, cubeSize + 1.5f);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = 20f;

        if(c == 1) piece.GetComponent<MeshRenderer>().material.color = new Color32(2, 0, 14, 255);
        else piece.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
    }
}
