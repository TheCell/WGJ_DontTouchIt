using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float spawnRadius = 30f;
    [SerializeField] private GameObject player;
    private int gridsize = 2;
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

    // Update is called once per frame
    private void Update()
    {
        int playerX = (int)(Mathf.Floor(player.transform.position.x / gridsize) * gridsize);
        int playerZ = (int)(Mathf.Floor(player.transform.position.z / gridsize) * gridsize);
        Vector2 playerpos = new Vector2(playerX, playerZ);
        FillRadiusWithObstacles(playerpos);
    }

    private void FillRadiusWithObstacles(Vector2 playerXZ)
    {
        int gridPointsInCircle = (int) ((spawnRadius * 2) / gridsize);
        int pointsInRadius = gridPointsInCircle / 2;

        for (int y = 0; y < gridPointsInCircle; y++)
        {
            for (int x = 0; x < gridPointsInCircle; x++)
            {
                Vector2 spawnPos = new Vector2(playerXZ.x + (x * gridsize) - pointsInRadius * gridsize, playerXZ.y + (y * gridsize) - pointsInRadius * gridsize);
                //CheckpositionAndSpawn((int)spawnPos.x, (int)spawnPos.y);

                if (Vector2.Distance(playerXZ, spawnPos) < spawnRadius)
                {
                    CheckpositionAndSpawn((int)spawnPos.x, (int)spawnPos.y);
                }
            }
        }

        RemoveUnused(playerXZ);
    }

    private void CheckpositionAndSpawn(int x, int z)
    {
        Obstacle currentObstacle;
        currentObstacle.position = new Vector2(x, z);
        currentObstacle.obstacle = null;

        if (!obstacleList.Contains(currentObstacle))
        {
            GameObject randomObj = RandomObstacle();
            currentObstacle.obstacle = Instantiate(randomObj);
            currentObstacle.obstacle.transform.parent = this.gameObject.transform;
            currentObstacle.obstacle.transform.position = new Vector3(currentObstacle.position.x, 0f, currentObstacle.position.y);
            obstacleList.Add(currentObstacle);
        }
    }

    private void RemoveUnused(Vector2 playerPos)
    {
        ArrayList elementsToRemove = new ArrayList();
        IEnumerator obstacleIterator = obstacleList.GetEnumerator();

        while (obstacleIterator.MoveNext())
        {
            Obstacle currentObst = (Obstacle)obstacleIterator.Current;
            if (Vector2.Distance(playerPos, currentObst.position) > spawnRadius)
            {
                elementsToRemove.Add(currentObst);
            }
        }

        foreach(Obstacle outOfRangeObstacle in elementsToRemove)
        {
            obstacleList.Remove(outOfRangeObstacle);
            Destroy(outOfRangeObstacle.obstacle);
        }
    }

    private GameObject RandomObstacle()
    {
        GameObject gameObj;

        if (Random.Range(0f, 1f) > 0.9)
        {
            gameObj = Instantiate(obstacles[Random.Range(0, obstacles.Length)]);
        }
        else
        {
            gameObj = new GameObject();
        }

        gameObj.transform.parent = this.gameObject.transform;
        return gameObj;
    }
}