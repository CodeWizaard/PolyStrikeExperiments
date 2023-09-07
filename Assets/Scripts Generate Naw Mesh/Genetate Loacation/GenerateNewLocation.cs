using UnityEngine;


public class GenerateNewLocation : MonoBehaviour
{
    public Location[] LocationPrefab;
    public int index = 0;
    private Quaternion SetRotation(int ExitNumber) {
        Quaternion SpawnPointRotation = GetComponent<Location>().End[ExitNumber].transform.rotation;
        Quaternion LocationRotation = gameObject.transform.rotation;
        Quaternion Rotation = new Quaternion(SpawnPointRotation.x + LocationRotation.x,
            SpawnPointRotation.y + LocationRotation.y,
            SpawnPointRotation.z + LocationRotation.z,
            SpawnPointRotation.w + LocationRotation.w);
        return Rotation;

    }

    private void Start()
    {
        Debug.Log("Созданная локация повернута на  "+ RotationMeasurement(gameObject));
    }
    public void InitializeLocationOnLeft(int ExitNumber)
    {
        float GlobalRotationLocation = RotationMeasurement(gameObject);
        Debug.Log(GlobalRotationLocation);
        switch (GlobalRotationLocation)
        {
            case 0:
                CreationLocationOnLeft(ExitNumber);
                Debug.Log("0");
                break;
            case 90:
                CreationLocationBefore(ExitNumber);
                Debug.Log("90");
                break;
            case 180:
                CreationLocationOnRight(ExitNumber);
                Debug.Log("180");
                break;
            case 270:
                CreationLocationBack(ExitNumber);
                Debug.Log("270");
                break;
            default:
                CreationLocationOnLeft(ExitNumber);

                break;
        }
    }
    public void InitializeLocationOnRight(int ExitNumber)
    {
        float GlobalRotationLocation = RotationMeasurement(gameObject);
        Debug.Log(GlobalRotationLocation);
        switch (GlobalRotationLocation)
        {
            case 0:
                CreationLocationOnRight(ExitNumber);
                Debug.Log("0");
                break;
            case 90:
                CreationLocationBack(ExitNumber);
                Debug.Log("90");
                break;
            case 180:
                CreationLocationOnLeft(ExitNumber);
                Debug.Log("180");
                break;
            case 270:
                CreationLocationBefore(ExitNumber);
                Debug.Log("270");
                break;
            default:
                CreationLocationOnRight(ExitNumber);
                break;
        }
    }
    public void InitializeLocationBefore(int ExitNumber)
    {
        float GlobalRotationLocation = RotationMeasurement(gameObject);
        Debug.Log(GlobalRotationLocation);
        switch (GlobalRotationLocation)
        {
            case 0:
                CreationLocationBefore(ExitNumber);

                Debug.Log("0");
                break;
            case 90:
                CreationLocationOnRight(ExitNumber);

                Debug.Log("90");
                break;
            case 180:
                CreationLocationBack(ExitNumber);
                Debug.Log("180");
                break;
            case 270:
                CreationLocationOnLeft(ExitNumber);
                Debug.Log("270");
                break;
            default:
                CreationLocationBefore(ExitNumber);
                break;
        }
    }
    public void InitializeLocationBack(int ExitNumber) {
        float GlobalRotationLocation = RotationMeasurement(gameObject);
        Debug.Log(GlobalRotationLocation);
        switch (GlobalRotationLocation)
        {
            case 0:
                CreationLocationBack(ExitNumber);
                Debug.Log("0");
                break;
            case 90:
                CreationLocationOnLeft(ExitNumber);
                Debug.Log("90");
                break;
            case 180:
                CreationLocationBefore(ExitNumber);
                Debug.Log("180");
                break;
            case 270:
                CreationLocationOnRight(ExitNumber);
                Debug.Log("270");
                break;
            default:
                CreationLocationBack(ExitNumber);
                break;
        }
    }


    public void CreationLocationBefore(int ExitNumber) { 
        Location NewLocation = Instantiate(GetRandomLocation(LocationPrefab),transform.position,Quaternion.identity);
        NewLocation.transform.rotation = SetRotation(ExitNumber); 
        //NewLocation.transform.rotation = GetComponent<Location>().End[ExitNumber].transform.rotation;
        Vector3 EndOldLocation = GetPositionEndOldLocation(ExitNumber);
        Vector3 StartNewLocation = NewLocation.Start.localPosition;
        Vector3 NewPos = new Vector3(EndOldLocation.x - StartNewLocation.x,
                                     EndOldLocation.y - StartNewLocation.y,
                                     EndOldLocation.z - StartNewLocation.z);
        MovingLocation(NewLocation, NewPos);
    }
    public void CreationLocationOnRight(int ExitNumber)
    {
        Location NewLocation = Instantiate(GetRandomLocation(LocationPrefab), transform.position, Quaternion.identity);
        NewLocation.transform.rotation = SetRotation(ExitNumber);
        Vector3 EndOldLocation = GetPositionEndOldLocation(ExitNumber);
        Vector3 StartNewLocation = NewLocation.Start.localPosition;
        Vector3 NewPos = new Vector3(EndOldLocation.x + StartNewLocation.z,
                                     EndOldLocation.y - StartNewLocation.y,
                                     EndOldLocation.z + StartNewLocation.x);
        MovingLocation(NewLocation, NewPos);
    }
    public void CreationLocationOnLeft(int ExitNumber)
    {
        Location NewLocation = Instantiate(GetRandomLocation(LocationPrefab), transform.position, Quaternion.identity);
        NewLocation.transform.rotation = SetRotation(ExitNumber);
        Vector3 EndOldLocation = GetPositionEndOldLocation(ExitNumber);
        Vector3 StartNewLocation = NewLocation.Start.localPosition;
        Vector3 NewPos = new Vector3(EndOldLocation.x + StartNewLocation.z,
                                     EndOldLocation.y - StartNewLocation.y,
                                     EndOldLocation.z - StartNewLocation.x);
        MovingLocation(NewLocation, NewPos);
    }
    public void CreationLocationBack(int ExitNumber)
    {
            Location NewLocation = Instantiate(GetRandomLocation(LocationPrefab), transform.position, Quaternion.identity);
            NewLocation.transform.rotation = SetRotation(ExitNumber);
            Vector3 EndOldLocation = GetPositionEndOldLocation(ExitNumber);
            Vector3 StartNewLocation = NewLocation.Start.localPosition;
            Vector3 NewPos = new Vector3(EndOldLocation.x + StartNewLocation.x,
                                     EndOldLocation.y - StartNewLocation.y,
                                     EndOldLocation.z + StartNewLocation.z);
            MovingLocation(NewLocation, NewPos);
    }

    private Vector3 GetPositionEndOldLocation(int ExitNumber)
    {
       return GetComponent<Location>().End[ExitNumber].transform.position;
    }
    private void MovingLocation(Location Location,Vector3 Position) {

        Location.transform.position = Position;
    }
    private float RotationMeasurement(GameObject Object)
    {
        
        Quaternion Q_Rotation = Object.transform.rotation;
        float Rotation = Q_Rotation.eulerAngles.y;
        if (Rotation == 359) return 360;

        if (CheckingRange(0, Rotation, 90)) return 0;
        if (CheckingRange(90, Rotation, 180)) return 90;
        if (CheckingRange(180, Rotation, 270)) return 180;
        if (CheckingRange(270, Rotation, 360)) return 270;
        return 0;
    }
    private bool CheckingRange(float StartNumber, float Rotation, float EndNumber)
    {
        if (StartNumber <= Rotation && Rotation < EndNumber)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private Location GetRandomLocation(Location[] Locations) {
        System.Random rnd = new System.Random();
        return Locations[rnd.Next(0, Locations.Length)];
        ///UnityEngine.Random(123);
        ///Переделать с Random range
    }

    private void Logging(string Text) {
    #if UNITY_EDITOR
        Debug.Log(Text);
    #endif
        
    }
}
