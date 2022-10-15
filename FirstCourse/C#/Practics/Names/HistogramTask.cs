using System;

namespace Names
{
    internal static class HistogramTask
    {
        private const int Days = 31;
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var xLabels = new string[Days];
            var yValues = new double[Days];
            for (var i = 0; i < Days; i++)
                xLabels[i] = Convert.ToString(i + 1);
            foreach (var person in names)
            {
                if (person.Name == name && person.BirthDate.Day != 1)
                    yValues[person.BirthDate.Day-1] += 1;
            }
            return new HistogramData($"Рождаемость людей с именем '{name}'", xLabels, yValues);
        }
    }
}