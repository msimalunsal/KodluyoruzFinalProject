using PathCreation;
using PathCreation.Examples;
using UnityEngine;

public abstract class SpawnerBase : MonoBehaviour
{
    public GameObject parentObj;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(Spawner);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(Spawner);
    }

    private GameObject GetRandomObj()
    {
        int rand = Random.Range(0, parentObj.transform.childCount);
        GameObject obj = parentObj.transform.GetChild(rand).gameObject;        
        return obj;
    }

    private void SetObje()
    {
        var obj = GetRandomObj();
        if (obj != null)
        {
            //Transform process
            obj.transform.SetParent(this.transform);
            obj.transform.position = this.transform.position;
            obj.SetActive(true);

            //Path process
            obj.GetComponent<PathFollower>().enabled = true;
            PathFollower follower = obj.GetComponent<PathFollower>();
            follower.pathCreator = transform.GetChild(0).GetComponent<PathCreator>();
            follower.enabled = true;
        }
    }

    private void Spawner()
    {
        if (LevelManager.Instance.IsLevelStarted)
        {
            SetObje();
            GetRandomObj();

            this.Wait(3f, () => { Spawner(); });
        }
    }
}
