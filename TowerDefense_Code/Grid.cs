using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public int size_x;
    public int size_y;
    public int node_size = 1;
    private Node[,] grid;



    private void Awake()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        grid = new Node[(int)size_x, (int)size_y];

        for (int i = 0; i < size_x; i++)
        {
            for (int j = 0; j < size_y; j++)
            {
                Vector3 nodePosition = new Vector3(node_size * 0.5f + i * node_size, node_size * 0.5f + j * node_size, 0);
                Vector2 worldNodePosition = transform.position + nodePosition;

                Collider[] colliders = Physics.OverlapSphere(worldNodePosition, node_size * 0.5f);

                
                bool isTransitable = true;
                bool isConstruible = false;

                for (int k = 0; k < colliders.Length; k++)
                {
                    if (colliders[k].tag == "Camino")
                    {
                        isTransitable = false;
                    }
                    if(colliders[k].tag == "construible")
                    {
                        isConstruible = true;
                    }
                    //isTransitable &= (colliders[k].tag)
                }

                grid[i, j] = new Node(i, j, node_size, worldNodePosition, isTransitable,isConstruible);

            }
        }
    }

    private void OnDrawGizmos()
    {

        if (grid != null)
        {
                           

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Vector3 scale = new Vector3(node_size, node_size, node_size);

                    //Gizmos.DrawCube(grid[i,j].worldPosition, scale);

                    //Gizmos.DrawWireSphere(grid[i, j].worldPosition, node_size * 0.5f);

                    if (grid[i,j].isTransistable)
                    {
                        Gizmos.color = Color.green;

                    }
                    else if (grid[i,j].isConstruible)
                    {
                        Gizmos.color = Color.blue;
                    }
                    else
                    {
                        Gizmos.color = Color.red;

                    }
                }
            }
        }

    }

    public Node GetNodeContainingPosition(Vector3 worldPosition)
    {
        Vector3 localPosition = worldPosition - transform.position;
        int x = Mathf.FloorToInt(localPosition.x / node_size);
        int y = Mathf.FloorToInt(localPosition.y / node_size);


        if (x < size_x && x >= 0 && y < size_y && y >= 0)
        {
            return grid[x, y];
        }

        return null;
    }


    public Node GetNode(int x,int y)
    {
        if(x<0 || y>0 || x<28 || y>31)
        {
            Debug.Log("No se puede acceder al vecino(nodo)");
        }
        return null;
    }

    public List<Node> GetNeighboursExtended(Node nodo,bool extended)
    {

     List<Node> listaDeNodosADevolver= new List<Node>();

        for(int i =-1; i <= 1; i++)
        {
            for(int j = -1; j<= 1; j++)
            {

                if (!extended)
                {
                    if(Mathf.Abs(i)== Mathf.Abs(j))
                    {
                        continue;
                    }
                }
                else
                {
                    if(i==0 && j ==0)
                    {
                        continue;
                    }
                }

                Node vecino = grid[nodo.gridPositionX + i, nodo.gridPositionY + j];

                if (vecino != null)
                {
                    listaDeNodosADevolver.Add(vecino);
                }
            }
        }
        return listaDeNodosADevolver;

    }


}




public class Node
{
    public int gridPositionX;
    public int gridPositionY;
    public int size;
    public Vector3 worldPosition;
    public bool isTransistable = true;
    public bool isConstruible = true;
    public Node() { }

    public Node(int _gridPositionX, int _gridPositionY, int _size, Vector3 _worldPosition, bool _isTransistable, bool _isConstruible)
    {
        gridPositionX = _gridPositionX;
        gridPositionY = _gridPositionY;
        size = _size;
        worldPosition = _worldPosition;
        isTransistable = _isTransistable;
        isConstruible = _isConstruible;
    }
}

