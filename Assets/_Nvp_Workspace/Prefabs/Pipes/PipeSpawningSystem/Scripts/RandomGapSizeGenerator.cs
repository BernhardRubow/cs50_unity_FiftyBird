using UnityEngine;
public class RandomGapSizeGenerator : IGapSizeGenerator
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private float _intialGapSize;
    private float _lastGapSize;

    public float GetNextGap()
    {
        _lastGapSize += Random.Range(-2f, 2f);
        _lastGapSize = Mathf.Clamp(_lastGapSize, 3.9f, 4.5f);

        Debug.LogFormat("last gap size: {0}", _lastGapSize);
        return _lastGapSize;
    }

    public void SetInitialGap(float initialGap)
    {
        _intialGapSize = initialGap;
        _lastGapSize = initialGap;
    }
}
