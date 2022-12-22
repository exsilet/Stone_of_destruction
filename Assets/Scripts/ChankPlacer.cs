using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChankPlacer : MonoBehaviour
{
    public Transform _player;
    public Chank[] _chankPrefab;
    public Chank FirstChank;

    private List<Chank> spawnedShank = new List<Chank>();

    private void Start()
    {
        spawnedShank.Add(FirstChank);
    }

    private void Update()
    {
        if (_player.position.z > spawnedShank[spawnedShank.Count - 1].transform.position.z - 500)
        {
            SpanwChunk();
        }
    }

    private void SpanwChunk()
    {
        Vector3 position = Vector3.zero;
        if (spawnedShank.Count > 0)
            position = spawnedShank[spawnedShank.Count - 1].transform.position + new Vector3(0, 0, 484);

        Chank newChunk = Instantiate(_chankPrefab[Random.Range(0, _chankPrefab.Length)]);
        newChunk.transform.position = position;
        spawnedShank.Add(newChunk);

        if (spawnedShank.Count >= 4)
        {
            Destroy(spawnedShank[0].gameObject);
            spawnedShank.RemoveAt(0);
        }
    }

    //private Chank GetRandomChank()
    //{
    //    List<float> chances = new List<float>();

    //    for (int i = 0; i < _chankPrefab.Length; i++)
    //    {
    //        chances.Add(_chankPrefab[i].ChansFromDistance.Evaluate(_player.transform.position.z));
    //    }

    //    float value = Random.Range(0, chances.Sum());
    //    float sum = 0;

    //    for (int i = 0; i < chances.Count; i++)
    //    {
    //        sum += chances[i];

    //        if (value < sum)
    //        {
    //            return _chankPrefab[i];
    //        }
    //    }

    //    return _chankPrefab[_chankPrefab.Length - 1];
    //}
}
