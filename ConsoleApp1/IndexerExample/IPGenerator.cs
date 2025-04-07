namespace ConsoleApp1.IndexerExample;

public class IpGenerator
{
    private int[] _ipsSegmants;
    
    public IpGenerator(string iP)
    {
        this._ipsSegmants = new int[4];
        var ipSegmants = iP.Split(".");

        for (int i = 0; i < this._ipsSegmants.Length; i++)
        {
            this._ipsSegmants[i] = Convert.ToInt32(ipSegmants[i]);
        }
    }

    public int this[int index]
    {
        get { return _ipsSegmants[index]; }
        set { _ipsSegmants[index] = value; }
    }
    
}