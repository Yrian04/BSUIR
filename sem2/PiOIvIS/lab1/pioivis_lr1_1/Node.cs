namespace pioivis_lr1_1
{
    internal class Node : IComparable<Node>
    {
        public string Id { get; }

        public List<Node> Neighbours { get; }

        
        public Node(string id, params Node[] neighbours)
        {
            Id = id;
            Neighbours = neighbours.ToList();
            Neighbours.Sort();
        }

        public bool AddNeighbour(Node neighbour)
        {
            if (Neighbours.Contains(neighbour))
            {
                return false;
            }
            Neighbours.Add(neighbour);
            Neighbours.Sort();
            return true;
        }

        public bool RemoveNeighbour(Node neighbour)
        {
            return Neighbours.Remove(neighbour);
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Node)
            {
                return obj.ToString()!.Equals(Id);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int CompareTo(Node? other)
        {
            if(other is null)
            {
                return -1;
            }
            return Id.CompareTo(other.Id);
        }
    }
}