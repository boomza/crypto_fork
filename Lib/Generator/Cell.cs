using UnityEngine;
public class Cell : MonoBehaviour
{
    public Sprite liveImg, deadImg;
    private SpriteRenderer sr;
    public bool aliveNow = false, aliveNextGen = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // migrate next state to current
    public void Evolve()
    {
        aliveNow = aliveNextGen;
        aliveNextGen = false;
        Repaint();
    }

    private void OnMouseUpAsButton()
    {
        aliveNow = !aliveNow;
        Repaint();
    }

    void Repaint()
    {
        sr.sprite = aliveNow ? liveImg : deadImg;
    }

    public override string ToString()
    {
        return "" + aliveNow;
    }
}
