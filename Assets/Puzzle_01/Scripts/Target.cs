using UnityEngine;

public enum CrateColor
{
    Red,
    Blue,
    Yellow,
}

public class Target : MonoBehaviour
{
    public CrateColor color;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.CrateTag) && other.GetComponent<Crate>().color == color)
        {
            Puzzle.Instance.AddCrate();
        }
        else
        {
            Debug.Log("Wrong crate");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.CrateTag) && other.GetComponent<Crate>().color == color)
        {
            Puzzle.Instance.RemoveCrate();
        }
    }
}
