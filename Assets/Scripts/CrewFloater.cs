using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CrewFloater : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    private bool[] crewStates = new bool[12];
    private float timer = 0.5f;
    private float distance = 9f;

    private void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            SpawnFloatingCrew((PlayerColorType)Random.Range(0, 12), distance);
            timer = 1f;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnFloatingCrew((PlayerColorType)Random.Range(0, 12), distance);
            timer = 1f;
        }
    }

    public void SpawnFloatingCrew(PlayerColorType playerColorType, float dist)
    {
        if (!crewStates[(int) playerColorType])
        {
            crewStates[(int) playerColorType] = true;
            
            float angle = Random.Range(0f, 360f);
            Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * distance;
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            float floatingSpeed = Random.Range(1f, 4f);
            float rotateSpeed = Random.Range(-3f, 3f);

            var crew = Instantiate(prefab, spawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
            crew.SetFloatingCrew(sprites[Random.Range(0, sprites.Count)], playerColorType, direction, floatingSpeed, rotateSpeed, Random.Range(0.5f, 1f));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var crew = other.GetComponent<FloatingCrew>();
        if (crew != null)
        {
            crewStates[(int) crew.playerColorType] = false;
            Destroy(crew.gameObject);
        }
    }
}
