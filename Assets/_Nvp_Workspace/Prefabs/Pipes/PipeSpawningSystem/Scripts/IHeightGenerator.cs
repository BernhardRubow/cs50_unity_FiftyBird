using UnityEngine;

public interface IHeightGenerator
{
    void SetStartPosition(Vector3 pos);

    Vector3 GetNextSpawnPosition();
}
