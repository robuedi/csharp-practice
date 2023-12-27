using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        using var databaseResource = database;
        databaseResource.BeginTransaction();
        databaseResource.Write(data);
        databaseResource.EndTransaction();
    }

    public bool WriteSafely(string data)
    {
        try
        {
            Write(data);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
