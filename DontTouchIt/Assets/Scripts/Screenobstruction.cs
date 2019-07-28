using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenobstruction : MonoBehaviour
{
    public float minimumTimeBetweenStains = 2f;

    [SerializeField] private GameObject[] obstructions;
    private ArrayList screenobstructions;
    private Canvas displayCanvas;
    private float timeSinceLastStain = 0f;

    public void AddRandomObstruction()
    {
        GameObject image = obstructions[Random.Range(0, obstructions.Length)];
        Resolution screenRes = Screen.currentResolution;
        AddObstruction(image, new Vector2(Random.Range(0, screenRes.width), Random.Range(0, screenRes.height)));
    }

    private void Start()
    {
        screenobstructions = new ArrayList();
        displayCanvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        AddObstructionWhileWalking();
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Moved)
                {
                    CleanScreenAt(touch.position);
                }
            }
        }
    }

    private void CleanScreenAt(Vector2 position)
    {
        IEnumerator obstructionEnumerator = screenobstructions.GetEnumerator();
        ArrayList elementsToRemove = new ArrayList();

        while (obstructionEnumerator.MoveNext())
        {
            GameObject currentObstruction = (GameObject)obstructionEnumerator.Current;
            Vector2 offsetFromMid = new Vector2(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2);
            RectTransform rectTransform = currentObstruction.GetComponent<RectTransform>();
            Vector3 dirtPos = rectTransform.anchoredPosition + offsetFromMid;
            if (Vector2.Distance(position, dirtPos) < 100f)
            {
                elementsToRemove.Add(currentObstruction);
            }
        }

        foreach (GameObject obstacle in elementsToRemove)
        {
            screenobstructions.Remove(obstacle);
            Destroy(obstacle);
        }
    }

    private void AddObstructionWhileWalking()
    {
        if (Time.time > (timeSinceLastStain + minimumTimeBetweenStains))
        {
            timeSinceLastStain = Time.time;
            AddRandomObstruction();
        }
    }

    private void AddObstruction(GameObject screenImage, Vector2 position)
    {
        GameObject obstruction = Instantiate(screenImage);
        RectTransform rectTransform = obstruction.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        obstruction.transform.SetParent(displayCanvas.transform);
        screenobstructions.Add(obstruction);

    }
}
