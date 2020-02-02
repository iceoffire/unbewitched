using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerOnStore : MonoBehaviour
{
    public GameObject playerPrefab;
    public List<PlayerDiagnosticInfo> playerDiagnosticInfos;
    static SpawnPlayerOnStore singleton;

    private void Awake()
    {
        singleton = this;
        StopAllCoroutines();
        StartCoroutine(SpawnPlayerEveryFiveSeconds());
    }

    private IEnumerator SpawnPlayerEveryFiveSeconds()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            SpawnPlayerOnStore.VerifyIfCanSpawnAndSpawn();
            yield return new WaitForSeconds(2);
        }
    }


    static void SpawnNewPlayer()
    {
        try
        {
            PlayerDiagnosticInfo playerDiagnosticInfo = GetRandomPlayerDiagnosticInfo();
            Chair freeChair = ChairController.GetFirstChairFree();
            GameObject player = Instantiate(singleton.playerPrefab, singleton.transform);
            Player spawned = player.GetComponent<Player>();
            spawned.UpdateValuesAndDraw(playerDiagnosticInfo);
            freeChair.SitOnItAndUpdatePlayer(spawned);
            DontDestroyOnLoad(spawned);
        }
        catch
        {
        }
    }

    public static void VerifyIfCanSpawnAndSpawn()
    {
        if (ChairController.ThereIsAnyFreeChairToGet())
        {
            SpawnNewPlayer();
        }
    }

    internal static void SpawnInChairWithoutAnimation(Chair freeChair, PlayerDiagnosticInfo playerDiagnosticInfo)
    {
        GameObject player = Instantiate(singleton.playerPrefab, singleton.transform);
        Player spawned = player.GetComponent<Player>();
        spawned.UpdateValuesAndDraw(playerDiagnosticInfo);
        spawned.transform.position = freeChair.chairGameObject.transform.position;
    }

    public static void StopCoroutines()
    {
        singleton.StopAllCoroutines();
    }

    static PlayerDiagnosticInfo GetRandomPlayerDiagnosticInfo()
    {
        return singleton.playerDiagnosticInfos[new System.Random().Next(0, singleton.playerDiagnosticInfos.Count)];
    }
}
