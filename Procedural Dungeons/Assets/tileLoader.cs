using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tileLoader : MonoBehaviour
{
    public Vector3 camPos;
    public Quaternion camRot;
    public Canvas canvas;

    public GameObject[] sidePrefabs = new GameObject[2];
    public GameObject[] cornerPrefabs = new GameObject[2];
    public GameObject[] midPrefabs = new GameObject[2];

    public Transform[] sideTransforms = new Transform[8];
    public Transform[] midTransforms = new Transform[4];
    public Transform[] cornerTransforms = new Transform[4];

    public Camera cam;
    public playerSpawn ps;

    public bool spawned = true;

    public Transform SideTiles, MidTiles, CornerTiles;

    void Start()
    {
        buildMap();
        canvas.enabled = true;
        camPos = cam.transform.position;
        camRot = cam.transform.rotation;
    }

    private void buildMap()
    {
        spawnCorners();
        spawnMids();
        spawnSides();
    }

    private void spawnSides()
    {
        foreach (Transform side in sideTransforms)
        {
            Instantiate(sidePrefabs[UnityEngine.Random.Range(0, sidePrefabs.Length)], side.position, side.rotation, SideTiles.transform);
        }
    }

    private void spawnMids()
    {
        foreach (Transform mid in midTransforms)
        {
            Instantiate(midPrefabs[UnityEngine.Random.Range(0, midPrefabs.Length)], mid.position, mid.rotation, MidTiles.transform);
        }
    }

    private void spawnCorners()
    {
        foreach (Transform corner in cornerTransforms)
        {
            Instantiate(cornerPrefabs[UnityEngine.Random.Range(0, cornerPrefabs.Length)], corner.position, corner.rotation, CornerTiles.transform);
        }
    }


    public void refreshMap()
    {
        foreach (Transform _child in SideTiles.transform)
        {
            spawned = false;
            Destroy(_child.gameObject); //Destroy each child of the Tiles GameObject
        }

        foreach (Transform _child in MidTiles.transform)
        {
            spawned = false;
            Destroy(_child.gameObject); //Destroy each child of the Tiles GameObject
        }

        foreach (Transform _child in CornerTiles.transform)
        {
            spawned = false;
            Destroy(_child.gameObject); //Destroy each child of the Tiles GameObject
        }

        buildMap();
        spawned = true;
    }

    public void startGame()
    {
        Destroy(cam.gameObject);
        ps.startGame();
        canvas.enabled = false;
    }
}
