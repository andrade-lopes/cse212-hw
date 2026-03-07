public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN
        // 1. Create a new array of doubles with size equal to 'length'.
        // 2. Use a loop that goes from index 0 up to length - 1.
        // 3. For each index, calculate the multiple of the number.
        // 4. The first value should be number * 1, the second number * 2, etc.
        // 5. Store each calculated value in the array.
        // 6. After the loop is finished, return the array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN
        // 1. Determine the starting index of the elements that will move to the front.
        //    This index is data.Count - amount.
        // 2. Use GetRange() to copy the last 'amount' elements into a new list.
        // 3. Remove those elements from the original list using RemoveRange().
        // 4. Insert the copied elements at the beginning of the list using InsertRange().
        // 5. The list will now be rotated to the right.

        int startIndex = data.Count - amount;

        List<int> slice = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, slice);
    }
}
