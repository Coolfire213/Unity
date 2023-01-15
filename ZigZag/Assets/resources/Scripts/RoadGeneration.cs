using UnityEngine;

public class RoadGeneration : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 endCoord;
    public float offset = 0.7071f;
    private int count = 12;

    private void Awake()
    {
        endCoord = this.transform.GetChild(11).position;
    }

    public void StartCreating()
    {
        InvokeRepeating("CreateRoadChunks", 1f, 0.5f);
    }

    public void CreateRoadChunks()
    {
        Vector3 startCoord = Vector3.zero;
        float rand = Random.Range(0f, 100f);
        if (rand < 50)
            startCoord = new Vector3(endCoord.x + offset, endCoord.y, endCoord.z + offset);
        else
            startCoord = new Vector3(endCoord.x - offset, endCoord.y, endCoord.z + offset);

        GameObject temp = Instantiate(roadPrefab, startCoord, Quaternion.Euler(0, 45, 0), this.transform);
        endCoord = temp.transform.position;
        count++;
        if (count % 5 == 0)
        {
            temp.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
