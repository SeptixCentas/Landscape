using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour {

    public float speed = 5;
    public Transform waypoint1;
    public Transform waypoint2;
 
    IEnumerator Start()
    {
        Transform target = waypoint1;
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.position) <= 0)
            {
                target = target == waypoint1 ? waypoint2 : waypoint1;
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }
    }
}
