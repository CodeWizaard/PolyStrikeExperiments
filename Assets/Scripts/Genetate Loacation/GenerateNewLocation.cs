using UnityEngine;



public class GenerateNewLocation : MonoBehaviour
{
    public Location[] LocationPrefab;
    public int index = 0;
    private Quaternion SetRotation(int exitNumber) {
        Quaternion spawnPointRotation = GetComponent<Location>().End[exitNumber].transform.rotation;
        Quaternion locationRotation = gameObject.transform.rotation;
        Quaternion rotation = new Quaternion(spawnPointRotation.x + locationRotation.x,
            spawnPointRotation.y + locationRotation.y,
            spawnPointRotation.z + locationRotation.z,
            spawnPointRotation.w + locationRotation.w);
        return rotation;

    }

    private void Start()
    {
        Debug.Log("Созданная локация повернута на  "+ RotationMeasurement(gameObject));
    }
    public void InitializeLocationOnLeft(int exitNumber)
    {
        float globalRotationLocation = RotationMeasurement(gameObject);
        Debug.Log(globalRotationLocation);
        switch (globalRotationLocation)
        {
            case 0:
                CreationLocationOnLeft(exitNumber);
                Debug.Log("0");
                break;
            case 90:
                CreationLocationBefore(exitNumber);
                Debug.Log("90");
                break;
            case 180:
                CreationLocationOnRight(exitNumber);
                Debug.Log("180");
                break;
            case 270:
                CreationLocationBack(exitNumber);
                Debug.Log("270");
                break;
            default:
                CreationLocationOnLeft(exitNumber);

                break;
        }
    }

    public void InitializeLocationOnRight(int exitNumber)
    {
        float globalRotationLocation = RotationMeasurement(gameObject);
        Debug.Log(globalRotationLocation);
        switch (globalRotationLocation)
        {
            case 0:
                CreationLocationOnRight(exitNumber);
                Debug.Log("0");
                break;
            case 90:
                CreationLocationBack(exitNumber);
                Debug.Log("90");
                break;
            case 180:
                CreationLocationOnLeft(exitNumber);
                Debug.Log("180");
                break;
            case 270:
                CreationLocationBefore(exitNumber);
                Debug.Log("270");
                break;
            default:
                CreationLocationOnRight(exitNumber);
                break;
        }
    }

    public void InitializeLocationBefore(int exitNumber)
    {
        float globalRotationLocation = RotationMeasurement(gameObject);
        Debug.Log(globalRotationLocation);
        switch (globalRotationLocation)
        {
            case 0:
                CreationLocationBefore(exitNumber);

                Debug.Log("0");
                break;
            case 90:
                CreationLocationOnRight(exitNumber);

                Debug.Log("90");
                break;
            case 180:
                CreationLocationBack(exitNumber);
                Debug.Log("180");
                break;
            case 270:
                CreationLocationOnLeft(exitNumber);
                Debug.Log("270");
                break;
            default:
                CreationLocationBefore(exitNumber);
                break;
        }
    }

    public void InitializeLocationBack(int exitNumber) {
        float globalRotationLocation = RotationMeasurement(gameObject);
        Debug.Log(globalRotationLocation);
        switch (globalRotationLocation)
        {
            case 0:
                CreationLocationBack(exitNumber);
                Debug.Log("0");
                break;
            case 90:
                CreationLocationOnLeft(exitNumber);
                Debug.Log("90");
                break;
            case 180:
                CreationLocationBefore(exitNumber);
                Debug.Log("180");
                break;
            case 270:
                CreationLocationOnRight(exitNumber);
                Debug.Log("270");
                break;
            default:
                CreationLocationBack(exitNumber);
                break;
        }
    }

    public void CreationLocationBefore(int exitNumber) { 
        Location newLocation = Instantiate(GetRandomLocation(LocationPrefab),transform.position,Quaternion.identity);
        newLocation.transform.rotation = SetRotation(exitNumber); 
        //NewLocation.transform.rotation = GetComponent<Location>().End[ExitNumber].transform.rotation;
        Vector3 endOldLocation = GetPositionEndOldLocation(exitNumber);
        Vector3 startNewLocation = newLocation.Start.localPosition;
        Vector3 newPos = new Vector3(endOldLocation.x - startNewLocation.x,
                                     endOldLocation.y - startNewLocation.y,
                                     endOldLocation.z - startNewLocation.z);
        MovingLocation(newLocation, newPos);
    }

    public void CreationLocationOnRight(int exitNumber)
    {
        Location newLocation = Instantiate(GetRandomLocation(LocationPrefab), transform.position, Quaternion.identity);
        newLocation.transform.rotation = SetRotation(exitNumber);
        Vector3 endOldLocation = GetPositionEndOldLocation(exitNumber);
        Vector3 startNewLocation = newLocation.Start.localPosition;
        Vector3 newPos = new Vector3(endOldLocation.x - startNewLocation.z,
                                     endOldLocation.y - startNewLocation.y,
                                     endOldLocation.z + startNewLocation.x);
        MovingLocation(newLocation, newPos);
    }

    public void CreationLocationOnLeft(int exitNumber)
    {
        Location newLocation = Instantiate(GetRandomLocation(LocationPrefab), transform.position, Quaternion.identity);
        newLocation.transform.rotation = SetRotation(exitNumber);
        Vector3 endOldLocation = GetPositionEndOldLocation(exitNumber);
        Vector3 startNewLocation = newLocation.Start.localPosition;
        Vector3 newPos = new Vector3(endOldLocation.x + startNewLocation.z,
                                     endOldLocation.y - startNewLocation.y,
                                     endOldLocation.z - startNewLocation.x);
        MovingLocation(newLocation, newPos);
    }

    public void CreationLocationBack(int exitNumber)
    {
            Location newLocation = Instantiate(GetRandomLocation(LocationPrefab), transform.position, Quaternion.identity);
            newLocation.transform.rotation = SetRotation(exitNumber);
            Vector3 endOldLocation = GetPositionEndOldLocation(exitNumber);
            Vector3 startNewLocation = newLocation.Start.localPosition;
            Vector3 newPos = new Vector3(endOldLocation.x + startNewLocation.x,
                                     endOldLocation.y - startNewLocation.y,
                                     endOldLocation.z + startNewLocation.z);
            MovingLocation(newLocation, newPos);
    }


    private Vector3 GetPositionEndOldLocation(int exitNumber)
    {
       return GetComponent<Location>().End[exitNumber].transform.position;
    }
    private void MovingLocation(Location location,Vector3 position) {

        location.transform.position = position;
    }
    private float RotationMeasurement(GameObject Object)
    {
        Quaternion q_Rotation = Object.transform.rotation;
        float rotation = q_Rotation.eulerAngles.y;

      

        if (IsRange(0, rotation, 90)) return 0;
        if (IsRange(90, rotation, 180)) return 90;
        if (IsRange(180, rotation, 270)) return 180;
        if (IsRange(270, rotation, 360)) return 270;
        return 0;
    }
    private bool IsRange(float startNumber, float rotation, float endNumber)
    {
        return (startNumber <= rotation && rotation < endNumber);
    }

    private Location GetRandomLocation(Location[] locations) {
        System.Random rnd = new System.Random();
        return locations[rnd.Next(0, locations.Length)];
        ///UnityEngine.Random(123);
        ///Переделать с Random range
    }

    private void Logging(string text) {
    #if UNITY_EDITOR
        Debug.Log(text);
    #endif
        
    }
}
