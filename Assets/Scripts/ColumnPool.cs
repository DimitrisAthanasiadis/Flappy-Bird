using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int colSize = 4;
    private GameObject[] columns;
    public GameObject columnPrefab;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    public float spawnRate = 4f;
    public float columnMin = 0f;
    public float columnMax = 3.5f;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;

	// Use this for initialization
	void Start () {
        //αρχικοποίηση του συνόλου των κολωνών
        columns = new GameObject[colSize];
        //λούπα μέσα στις κολώνες...
        for (int i = 0; i < colSize; i++)
        {
            //και δημιουργία των μεμονωμένων κολωνών
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            //θέτουμε τυχαία θέση στον άξονα y για την κολώνα
            float spawnYPosition = Random.Range(columnMin, columnMax);
            //μετά βάζουμε την παρούσα κολώνα σε αυτήν την θέση
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            //αυξάνουμε την τιμή της currentColumn . αν το μέγεθος είναι πολύ μεγάλο, το κάνουμε μηδέν
            currentColumn++;
            
            if(currentColumn >= colSize)
            {
                currentColumn = 0;
            }
        }
	}
}
