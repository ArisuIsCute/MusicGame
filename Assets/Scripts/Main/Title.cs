using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Title : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TryPlay());
    }

    private IEnumerator TryPlay()
    {
        yield return new WaitUntil(() => LoadSongList.instance.newSongs.Count != 0);
        Music.instance.PlayMusicForTitle(LoadSongList.instance.newSongs[Random.Range(0, LoadSongList.instance.newSongs.Count - 1)].song);
        yield break;
    }
}
