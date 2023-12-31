using System.Collections.Generic;

namespace VHon
{
    public static class Lists
    {
        //===============================================================================================================================
        // RIGHT
        // list.Shift(1);
        // LEFT
        // list.Shift(-2);
        //===============================================================================================================================
        public static void Shift<T>(this List<T> list, int offset)
        {
            if (list.Count > 0)
            {
                int count = list.Count;
                int effectiveOffset = offset % count; // Get the effective offset considering list length
                if (effectiveOffset < 0) effectiveOffset += count; // Adjust negative offset

                if (effectiveOffset == 0) return; // No need to shift if offset is 0

                List<T> removedItems = list.GetRange(count - effectiveOffset, effectiveOffset);
                list.RemoveRange(count - effectiveOffset, effectiveOffset);
                list.InsertRange(0, removedItems);
            }            
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}