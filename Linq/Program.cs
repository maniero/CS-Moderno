using static System.Console;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main(string[] args) {
        foreach (var item in new int[] { 5, 4, 8, 7, 3, 6, 2, 5, 9, 4, 1, 8 }.Where(x => x > 3).Even().OrderBy(x => x)) WriteLine(item);
    }
}

static class EnumerableExt {
    public static IEnumerable<int> Even(this IEnumerable<int> items) {
        foreach (var item in items) if (item % 2 == 0) yield return item;
    }
}