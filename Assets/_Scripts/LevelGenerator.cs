using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameController GameController;
    public GameObject[] PlatformPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBetweenPlatforms;
    public Transform FinishPlatform;
    public Transform Cylinder;
    public int LevelLength;

    private void Awake()
    {
        SetLevel(GameController.LevelIndex);
    }

    private void SetLevel(int LevelIndex)
    {
        if (LevelIndex==0) CustomLevel(5,20f);
        else if (LevelIndex == 1) CustomLevel(7, 180f);
        else if (LevelIndex == 2) CustomLevel(3, 30f);
        else if (LevelIndex == 3) CustomLevel(0, 15f);
        else if (LevelIndex == 4) CustomLevel(8, 180f);
        else if (LevelIndex == 5) CustomLevel(6, 30f);
        else if (LevelIndex == 6) CustomLevel(4, 60f);
        else if (LevelIndex == 7) CustomLevel(1, 180f);
        else if (LevelIndex == 8) CustomLevel(2, 15f);
        else RandomLevel();
    }

    private void CustomLevel(int PrefIndex, float rotation)
    {
        for (int i = 0; i < LevelLength; i++)
        {
            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[PrefIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i > 0) platform.transform.localRotation = Quaternion.Euler(0, rotation * i, 0);
        }
        FinishPlatform.localPosition = CalculatePlatformPosition(LevelLength);
        Cylinder.localScale = new Vector3(1, LevelLength * DistanceBetweenPlatforms, 1);
    }

    private void RandomLevel()
    {
        int platformsCount = UnityEngine.Random.Range(MinPlatforms, MaxPlatforms + 1);
        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = UnityEngine.Random.Range(0, PlatformPrefabs.Length);
            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if(i>0) platform.transform.localRotation = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360f), 0);
        }
        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);
        Cylinder.localScale = new Vector3(1, platformsCount * DistanceBetweenPlatforms, 1);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatforms * platformIndex, 0);
    }
}
