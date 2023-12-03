using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string idVal = id != null ? $"[{id}] - " : "";
        string departmentVal = department == null ? "OWNER" : $"{department.ToUpper()}";
        return $"{idVal}{name} - {departmentVal}";
    }
}
