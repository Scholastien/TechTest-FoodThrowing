using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableSpawner : SingletonMonobehaviour<ThrowableSpawner>
{

    [SerializeField] private Rect _spawnRange;

    private List<GameObject> _spawnedGameObject;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => Player.Instance != null);
        Player.Instance.throwableSpawner = this;
        EventHandler.CallToStartSpawningBehaviour();
    }

    private void OnDestroy()
    {
        Player.Instance.throwableSpawner = null;
        EventHandler.CallToStopAllSpawningBehaviour();
    }


    /// <summary>
    /// Spawn Objects in the Spawn Range
    /// </summary>
    /// <param name="quantity">how many to spawn</param>
    /// <param name="objToSpawn">List of object in which they will be selected at random</param>
    public void Spawn(int quantity, List<GameObject> objToSpawn)
    {
        if (_spawnedGameObject == null)
        {
            _spawnedGameObject = new List<GameObject>();
        }

        for (int i = 0; i < quantity; i++)
        {
            GameObject go = GameObject.Instantiate(objToSpawn[Random.Range(0, objToSpawn.Count - 1)]);
            _spawnedGameObject.Add(go);
            go.transform.SetParent(transform);

            PositionObject(go);
        }
    }

    /// <summary>
    /// Position an object to a valid position, in bound with the environment
    /// </summary>
    public void PositionObject(GameObject go)
    {
        float x = Random.Range(_spawnRange.x, _spawnRange.width);
        float z = Random.Range(_spawnRange.y, _spawnRange.height);
        go.transform.position = new Vector3(x, 1f, z) + transform.position;
    }
}
