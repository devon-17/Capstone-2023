using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacementHelper : MonoBehaviour
{
    Dictionary<PlacementType, HashSet<Vector2Int>>
        tileByTile = new Dictionary<PlacementType, HashSet<Vector2Int>>();

    HashSet<Vector2Int> roomFloorNoCorridor;

    public ItemPlacementHelper(HashSet<Vector2Int> roomFloor,
        HashSet<Vector2Int> roomFloorNoCorridor)
    {
        Graph graph = new Graph(roomFloor);
        this.roomFloorNoCorridor = roomFloorNoCorridor;

       /* foreach(var position in roomFloorNoCorridor)
        {
            int neighboursCount8Dir = graph.GetNeighbours8Directions(position).Count;
            PlacementType type = neighboursCount8Dir < 8 ? PlacementType.NearWall : PlacementType

            if (tileByTile.ContainsKey(type) == false) 
                tileByTile[type] = new HashSet<Vector2Int>();

            if (type == PlacementType.NearWall && graph.GetNeighbours4Directions(position).Count
                continue;
            tileByTile[type].Add(position);
        }*/
    }

    public enum PlacementType
    {
        OpenSpace,
        NearWall
    }
}
