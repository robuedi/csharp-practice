using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch(shirtNum)
        {
            case 1:
                return "goalie";

            case 2:
                return "left back";

            case 3:
            case 4:
                return "center back";

            case 5:
                return "right back";

            case 6:
            case 7:
            case 8:
                return "midfielder";

            case 9:
                return "left wing";

            case 10:
                return "striker";

            case 11:
                return "right wing";

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch(report)
        {
            case int intVal:
                return $"There are {intVal} supporters at the match.";

            case string stringVal:
                return stringVal;

            case Incident incidentEvent when incidentEvent is Injury:
                return $"Oh no! {incidentEvent.GetDescription()} Medics are on the field.";;

            case Incident incidentEvent:
                return incidentEvent.GetDescription();

            case Manager managerType when managerType.Club == null:
                    return managerType.Name;

            case Manager managerType when managerType.Club != null:
                    return $"{managerType.Name} ({managerType.Club})";

            default:
                throw new ArgumentException();
        }
    }
}
