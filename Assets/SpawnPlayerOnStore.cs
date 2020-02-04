using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPlayerOnStore : MonoBehaviour
{
    public Player playerPrefab;
    public RectTransform spawnOrigin;
    static SpawnPlayerOnStore singleton;
    public List<PlayerDiagnosticInfo> playerDiagnosticInfos;
    public static float initialY;

    void Awake()
    {
        singleton = this;
        StartSpawningPlayerOnStore();
        initialY = spawnOrigin.transform.position.y;
    }

    private void StartSpawningPlayerOnStore()
    {
        StartCoroutine(SpawnPlayerEveryFiveSeconds());
    }

    private IEnumerator SpawnPlayerEveryFiveSeconds()
    {
        yield return new WaitForSeconds(2);
        while(true)
        {
            VerifyIfCanSpawnAndSpawn();
            yield return new WaitForSeconds(5);
        }
    }

    public static void VerifyIfCanSpawnAndSpawn()
    {
        if (ThereIsAnyFreeChair())
        {
            Player player = SpawnPlayerAndSetOriginPosition();
            Chair freeChair = ChairController.GetFirstChairFree();
            singleton.StartCoroutine(WaitHalfSecondAnsSitOnTheChair(player,freeChair));
        }
    }

    private static IEnumerator WaitHalfSecondAnsSitOnTheChair(Player player, Chair freeChair)
    {
        yield return new WaitForSeconds(0.5f);
        freeChair.SitOnIt(player);
    }

    private static bool ThereIsAnyFreeChair()
    {
        return ChairController.ThereIsAnyFreeChairToGet();
    }

    static Player SpawnPlayerAndSetOriginPosition()
    {
        singleton.StartCoroutine(singleton.AnimateDoor());
        Player player = InstantiatePlayer();
        player.transform.localPosition = singleton.spawnOrigin.localPosition;
        return player;
    }

    private static Player InstantiatePlayer()
    {
        Player player = Instantiate(singleton.playerPrefab, singleton.transform).GetComponent<Player>();
        return player;
    }

    public static PlayerDiagnosticInfo GetRandomPlayerDiagnosticInfo()
    {
        int amountPlayerDiagnosticInfo = singleton.playerDiagnosticInfos.Count;
        int randomIndex = new System.Random().Next(0,amountPlayerDiagnosticInfo);
        return singleton.playerDiagnosticInfos[randomIndex];
    }

    private IEnumerator AnimateDoor()
    {
        Door.Open();
        yield return new WaitForSeconds(1);
        Door.Close();
    }

    static bool CanSpawn()
    {
        return false;
    }
}
