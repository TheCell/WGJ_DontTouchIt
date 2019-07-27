using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float spawnRadius = 30f;
    [SerializeField] private GameObject player;
    private int gridsize = 4;
    private ArrayList obstacleList = new ArrayList();

    private struct Obstacle
    {
        public Vector2 position;
        public GameObject obstacle;

        public Obstacle(Vector2 pos, GameObject obstacle)
        {
            this.position = pos;
            this.obstacle = Instantiate(obstacle);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Obstacle))
            {
                return false;
            }
            Obstacle obst = (Obstacle)obj;
            return obst.position.Equals(this.position);
        }

        public override int GetHashCode()
        {
            return this.position.GetHashCode();
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        int playerX = (int)(Mathf.Floor(player.transform.position.x / gridsize) * gridsize);
        int playerZ = (int)(Mathf.Floor(player.transform.position.z / gridsize) * gridsize);
        //Debug.Log("float " + Mathf.PerlinNoise(player.transform.position.x, player.transform.position.z));
        //Debug.Log("int " + Mathf.PerlinNoise(playerX, playerZ));
        CheckpositionAndSpawn(playerX, playerZ);
    }

    private void CheckpositionAndSpawn(int x, int z)
    {
        Obstacle currentObstacle;
        currentObstacle.position = new Vector2(x, z);
        currentObstacle.obstacle = null;

        if (!obstacleList.Contains(currentObstacle))
        {
            Debug.Log("not yet in list!");
            currentObstacle.obstacle = Instantiate(RandomObstacle());
            currentObstacle.obstacle.transform.position = new Vector3(currentObstacle.position.x, 0f, currentObstacle.position.y);
            obstacleList.Add(currentObstacle);
        }
    }

    private void RemoveUnused()
    {

    }

    private GameObject RandomObstacle()
    {
        return obstacles[Random.Range(0, obstacles.Length - 1)];
    }
}