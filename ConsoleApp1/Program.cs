
using System.Reflection;

int m = 10, n = 10;
var matrix = new int[m, n];
var points = fill(matrix, m, n);
print(matrix, m, n);
solve(matrix, m, n, points);
Console.WriteLine();


void print(int[,] matrix, int m, int n) {
    Console.WriteLine("\n\n");
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            Console.Write($" {matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

(int x1, int x2, int y1, int y2) fill(int[,] matrix, int m, int n) {
    var rand = new Random();
    var oneposibility = 0.5;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            matrix[i, j] = (int)(rand.NextDouble() + oneposibility);
        }
    }
    (int, int) x = (rand.Next(m), rand.Next(n));
    (int, int) y = (rand.Next(m), rand.Next(n));
    matrix[x.Item1, x.Item2] = 2;
    matrix[y.Item1, y.Item2] = 4;

    return (x.Item1, x.Item2, y.Item1, y.Item2);
}

void solve(int[,] matrix, int m, int n, (int x1, int x2, int y1, int y2) points) {
    var traveledpoints = new Queue<List<(int, int)>>();
    traveledpoints.Enqueue(new List<(int, int)>() { (points.x1, points.x2) });
    while (true) {
        foreach (var item in traveledpoints) {

            if (item.Last().Item1 - 1 > 0 && matrix[item.Last().Item1 - 1, item.Last().Item2] == 1 ) {
                matrix[item.Last().Item1 - 1, item.Last().Item2] = 3;
                
            }
        }
    }

}