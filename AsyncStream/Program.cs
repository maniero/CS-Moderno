using System;
using static System.Console;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncStream {
    class Program {
        static async Task Main() {
            foreach (var number in await GetNumbers()) WriteLine(number);
            await foreach (var number in GetNumbersAsync()) WriteLine(number);
        }
        static async Task<int[]> GetNumbers() {
            var r = new int[10];
            for (var i = 0; i < 10; i++) {
                await Task.Delay(1000);
                r[i] = i;
            }
            return r;
        }
        static async IAsyncEnumerable<int> GetNumbersAsync() {
            for (var i = 0; i < 10; i++) {
                await Task.Delay(1000);
                yield return i;
            }
            static void Teste() {
                IAsyncEnumerab1e<int> result = from item in enumerable
                                               where item % 2 == 0
                                               select async {
                    await Task.Yield();
                    return item * 2;
                };
            }
        }
    }
}
