using UnityEngine;
using UnityEngine.UI;

public class SimRunner : MonoBehaviour {

    private int rows = 10, cols = 10;
	public Text msgText;

	private int generation = 0;

    private bool running = false;
    private Cell [,] cells;

    void Start()
    {
        cells = new Cell[rows,cols];
        // map game 
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                GameObject go = GameObject.Find("Cell-" + i + j);
                cells[i,j] = go.GetComponent<Cell>();
            }

        msgText.text = "Generation: 0";
    }

    public void Next()
    {
        msgText.text = "Generation: " + ++generation;
        msgText.text = "Generation: " + Generator.Generator.Mult(10,100);
        Generator.Generator.Evolve(cells);
    }

    public void Loop()
    {
        if (running)
            return;

        InvokeRepeating("Next", 2f, 2f);
        running = true;
    }
    
}
