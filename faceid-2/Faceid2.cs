using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public bool Equals(FacialFeatures obj) => obj != null && EyeColor == obj.EyeColor && PhiltrumWidth == obj.PhiltrumWidth ? true : false;

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public bool Equals(Identity obj) => obj != null && Email == obj.Email && FacialFeatures.Equals(obj.FacialFeatures) ? true : false;
   
    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    public IDictionary<int, Identity> Identities {get;set;} = new Dictionary<int, Identity>{};

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));

    public bool Register(Identity identity)
    {
        if(this.IsRegistered(identity))
            return false;

        Identities.Add(identity.GetHashCode(), identity);
        return true;
    }

    public bool IsRegistered(Identity identity) => Identities.ContainsKey(identity.GetHashCode());

    public static bool AreSameObject(Identity identityA, Identity identityB) => Object.ReferenceEquals(identityA, identityB);
}
