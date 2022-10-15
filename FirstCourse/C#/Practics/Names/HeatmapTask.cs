using System;

namespace Names
{
    internal static class HeatmapTask
    {
        private const int Days = 30;
        private const int Months = 12;
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var xLabels = GetLabel(2, Days);
            var yLabels = GetLabel(2, Months);
            var heatMap = new double[Days,Months];

            foreach (var person in names)
            {
                if (person.BirthDate.Day != 1)
                    heatMap[person.BirthDate.Day-2, person.BirthDate.Month-1] += 1;
            }
            return new HeatmapData(
                "Тепловая карта", heatMap, xLabels, yLabels);
        }

        private static string[] GetLabel(int start, int end)
        {
            var label = new string[end]; 
            for (var i = 0; i < end; i++)
                label[i] = Convert.ToString(i + start);
            return label;
        }
    }
}