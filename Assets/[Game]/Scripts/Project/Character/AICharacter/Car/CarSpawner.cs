using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    #region SerializeField
    public static Transform vehiclesAll;
    [SerializeField] GameObject carEnable;
    #endregion

    #region Private Field
    float delay;
    bool isSpawn;
    int rand;
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(Spawner);
        rand = Random.Range(0, 7);
        Debug.Log(rand);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(Spawner);

    }

    private GameObject GetRandomCar()
    {
        GameObject car = vehiclesAll.GetChild(rand).gameObject;
        car.transform.parent = carEnable.transform;///arabayı yukarıda parent'a taşı.
        car.GetComponent<Cars>().addToTarget(this.gameObject); //arabanın hangi yolu kullanacağını belirlemek için addToTarget'ı çağır.
        car.transform.position = this.transform.position;//arabanın pozisyonunu spawn ettiğimiz yere eşitliyoruz.
        car.SetActive(true);
        EventManager.OnCarCreate.Invoke();
        return car;
    }
    void Spawner()
    {
        GetRandomCar();
        StartCoroutine(ExampleCoroutine());
    }
    #endregion

    #region IEnumerator
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Spawner();
    }
    #endregion
}
