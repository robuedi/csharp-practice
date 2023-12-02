using System;

public static class TelemetryBuffer
{
    private static int _bufferSize = 8;
    private static int _prefixSize = 256;

    public static byte[] ToBuffer(long reading)
    {
        if(reading <= -2_147_483_649L)
        {
            return getByteArray(reading, 8, 256-8);
        }
        else if(reading <= -32_769L)
        {
            return getByteArray(reading, 4, 256-4);
        }
        else if(reading <= -1)
        {
            return getByteArray(reading, 2, 256-2);
        }
        else if(reading <= 65_535)
        {
            return getByteArray(reading, 2, 2);
        }
        else if(reading <= 2_147_483_647L)
        {
            return getByteArray(reading, 4, 256-4);
        }
        else if(reading <= 4_294_967_295L)
        {
            return getByteArray(reading, 4, 4);
        }
        else
        {
            return getByteArray(reading, 8, 256-8);
        }

        return null;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte type = buffer[0];

        if(type != 256-8 && type!=256-4 && type!=256-2 && type!=2 && type!=4)
            return 0;

        if(type==248)
            return BitConverter.ToInt64(buffer,1);
        else if (type==256-4)
            return BitConverter.ToInt32(buffer,1);
        else if(type==256-2)
            return BitConverter.ToInt16(buffer,1);
        else if(type==2)
            return BitConverter.ToUInt16(buffer,1);
        else 
            return BitConverter.ToUInt32(buffer,1);
        
    }

    private static byte[] getByteArray(long reading, int byteSize, byte header)
    {
        byte[] byteData = BitConverter.GetBytes(reading);
        byte[] fullData = new byte[9];
        fullData[0] = header;

        for(int i=0; i<byteSize; i++)
        {
            fullData[i+1] = byteData[i];
        }

        return fullData;
    }
}
