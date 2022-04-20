using System;
using Networking;

[Serializable]
public class GetFlightByID : Request
{
    private int flightID;
    
    public GetFlightByID(int fl)
    {
        this.flightID = fl;
    }
    
    public virtual int fl
    {
        get { return flightID; }
    }
    
}