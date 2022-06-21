using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public float backgroundSize;
    public float backgroundSpeed;
    public List<GameObject> backgroundTiles;

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < backgroundTiles.Count; x++)
        {
            backgroundTiles[x].transform.position = new Vector3((backgroundTiles[x].transform.position.x + backgroundSpeed * Time.deltaTime), 0);
            if(backgroundTiles[x].transform.position[0] >= backgroundSize/2)
            {
                backgroundTiles[x].transform.position = new Vector3((backgroundTiles[x].transform.position.x - backgroundSize/2), 0);
            }
        }
    }
}
