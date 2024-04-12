using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : GameBehaviour
{
    
    [SerializeField] List<GameObject> cars;
    GameObject currentCar;
    [SerializeField] float movementSpeed;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    void Start()
    {
        SpawnCars();
    }

    
    void Update()
    {
        //moves the current car forward
        if(currentCar != null)
        {
            currentCar.transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
    }

    void SpawnCars()
    {
        //To flip the cars the correct way around
        Quaternion newRotation = new Quaternion (0, 180, 90, 0);
        currentCar = Instantiate(cars[Random.Range(0, cars.Count)], gameObject.transform.position, newRotation);
        //After x amount of seconds, will call next code which is DeleteCar()
        ExecuteAfterSeconds(Random.Range(minTime, maxTime), ()=> DeleteCar());

    }

    void DeleteCar()
    {
        Destroy(currentCar);
        SpawnCars();
    }


}
