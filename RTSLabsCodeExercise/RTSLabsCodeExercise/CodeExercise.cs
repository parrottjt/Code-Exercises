namespace RTSLabsCodeExercise;

public static class CodeExercise
{
    //Simple Option of going through list linearly is fine for small data sets
    //However sorting and using a binary approach will greatly increase use at larger datasets
    public static string AboveBelow(List<int> list, int compareValue)
    {
        var sortedList = HelperMethods.QuickSort(list);
        var first = 0;
        var last = sortedList.Count - 1;
        var splitBelow = 0;
        var splitAbove = 0;
        var foundSplits = false;

        while (foundSplits == false)
        {
            var midPoint = (first + last) / 2;
            if (splitBelow == midPoint || splitAbove == midPoint)
            {
                foundSplits = true;
            }
            if (sortedList[midPoint] < compareValue)
            {
                first = midPoint + 1;
                splitBelow = midPoint;
            }
            else if (sortedList[midPoint] > compareValue)
            {
                last = midPoint - 1;
                splitAbove = midPoint;
            }
            else last += 1;
        }

        var aboveString = "[Above : 0]";
        var belowString = "[Above : 0]";
        
        if (sortedList[^1] != compareValue)
            aboveString = $"[Above : {sortedList.GetRange(splitAbove, sortedList.Count - splitAbove).Count}]";

        if (sortedList[0] != compareValue) 
            belowString = $"[Below : {sortedList.GetRange(0, splitBelow + 1).Count}]";

        return aboveString + ", " + belowString;
    }
    
    public static string StringRotation(string originalString, int rotationAmount)
    {
        //This is to ensure that rotation still happens even if rotation amount is larger than string size
        if (rotationAmount > originalString.Length)
        {
            rotationAmount %= originalString.Length;
        }

        var stringFromRotationPoint = originalString.Substring(originalString.Length - rotationAmount);
        var stringToRotationPoint = originalString.Substring(0, originalString.Length - rotationAmount);

        var rotatedString = stringFromRotationPoint + stringToRotationPoint;
        return rotatedString;
    }
}