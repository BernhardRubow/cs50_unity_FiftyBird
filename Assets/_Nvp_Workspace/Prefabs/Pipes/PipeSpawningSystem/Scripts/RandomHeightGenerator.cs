using UnityEngine;

public class RandomHeightGenerator : IHeightGenerator
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Vector3 _position;
    float _lastPosition;



    public Vector3 GetNextSpawnPosition()
    {
        var y = Random.Range(50f, -50f);
        _position.y += y;
        _position.y = Mathf.Clamp(_position.y, -215, 215);

        return _position;
    }

    public void SetStartPosition(Vector3 pos)
    {
        _position = pos;
    }
}
