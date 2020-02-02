using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerOnStore : MonoBehaviour
{
    public GameObject playerPrefab;
    public List<PlayerDiagnosticInfo> playerDiagnosticInfos;
    static SpawnPlayerOnStore singleton;
    public static float initialY;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        singleton = this;
        StopAllCoroutines();
        initialY = this.transform.position.y;
        StartCoroutine(SpawnPlayerEveryFiveSeconds());
        Debug.Log("Loaded");
    }

    private IEnumerator SpawnPlayerEveryFiveSeconds()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            SpawnPlayerOnStore.VerifyIfCanSpawnAndSpawn();
            if (ChairController.ThereIsAnyFreeChairToGet())
            {
                audioSource.PlayOneShot(audioClip);
            }
            yield return new WaitForSeconds(2);
        }
    }


    static void SpawnNewPlayer()
    {
        try
        {
            ChairController.UpdateAllPlayersToNextChair();
            PlayerDiagnosticInfo playerDiagnosticInfo = GetRandomPlayerDiagnosticInfo();
            Chair freeChair = ChairController.GetFirstChairFree();
            GameObject player = Instantiate(singleton.playerPrefab, singleton.transform);
            Player spawned = player.GetComponent<Player>();
            spawned.UpdateValuesAndDraw(playerDiagnosticInfo);
            freeChair.SitOnItAndAnimateFadeInPlayerAndUpdatePosition(spawned);
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
        freeChair.SitOnIt(spawned);
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
