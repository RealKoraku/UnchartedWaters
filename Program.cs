namespace Uncharted2 {
    internal class Program {
        static void Main(string[] args) {
            int z;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            int[,,] data = GetSatelliteData();
            GetSubRatio(data);
            Console.WriteLine("\nSURFACE: ");
            DisplaySlice(data, z = 0);
            Console.ForegroundColor= ConsoleColor.Gray;
            Console.WriteLine("\nUNDERWATER: ");
            DisplaySlice(data, z = 1);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nDEEPWATER: ");
            DisplaySlice(data, z = 2);
            Console.ForegroundColor = ConsoleColor.White;

        }//end main

        static int[,,] GetSatelliteData() {
            Random rand = new Random();
            int[,,] data = new int[10, 10, 3];

            for (int z = 0; z < data.GetLength(2); z++) {
                for (int y = 0; y < data.GetLength(1); y++) {
                    for (int x = 0; x < data.GetLength(0); x++) {
                        if (rand.Next(0, 101) < 25) {
                            data[x, y, z] = rand.Next(1, 3);
                        }
                    }
                }
            }
            GetSubCount(data);
            return data;
        }
        static void GetSubCount(int[,,] data) {
            double subCount1 = 0;
            double subCount2 = 0;
            double subCount3 = 0;

            for (int y = 0; y < data.GetLength(1); y++) {
                for (int x = 0; x < data.GetLength(0); x++) {
                    if ((data[x, y, 0] == 1) || (data[x, y, 0] == 2)) {
                        subCount1++;
                    }
                    if ((data[x, y, 1] == 1) || (data[x, y, 1] == 2)) {
                        subCount2++;
                    }
                    if ((data[x, y, 2] == 1) || (data[x, y, 2] == 2)) {
                        subCount3++;
                    }
                }
            }
            subCount1 = subCount1 / 100;
            subCount2 = subCount2 / 100;
            subCount3 = subCount3 / 100;
            Console.WriteLine($"Surface sub density      - {subCount1}");
            Console.WriteLine($"Underwater sub density   - {subCount2}");
            Console.WriteLine($"Deepwater sub density    - {subCount3}");

        }
        static void GetSubRatio(int[,,] data) {
            double navySub1 = 0;
            double enemySub1 = 0;
            double navySub2 = 0;
            double enemySub2 = 0;
            double navySub3 = 0;
            double enemySub3 = 0;
            double navySubTotal;
            double enemySubTotal;
            double ratio;

            for (int y = 0; y < data.GetLength(1); y++) {
                for (int x = 0; x < data.GetLength(0); x++) {
                    if ((data[x, y, 0] == 1)) {
                        navySub1++;
                    } else if ((data[x, y, 0] == 2)) {
                        enemySub1++;
                    }
                    if ((data[x, y, 1] == 1)) {
                        navySub2++;
                    } else if ((data[x, y, 1] == 2)) {
                        enemySub2++;
                    }
                    if ((data[x, y, 2] == 1)) {
                        navySub3++;
                    } else if ((data[x, y, 2] == 2)) {
                        enemySub3++;
                    }

                }
            }
            navySubTotal = navySub1 + navySub2 + navySub3;
            enemySubTotal = enemySub1 + enemySub2 + enemySub3;

            ratio = navySubTotal / enemySubTotal;
            Console.WriteLine($"Sub / Enemy Sub ratio    - {ratio}");
            bool surfaceAttack = GoForAttack(navySub1, enemySub1);
            Console.WriteLine($"Go for surface attack    - {surfaceAttack}");
            bool underwaterAttack = GoForAttack(navySub2, enemySub2);
            Console.WriteLine($"Go for underwater attack - {underwaterAttack}");
            bool deepwaterAttack = GoForAttack(navySub3, enemySub3);
            Console.WriteLine($"Go for deepwater attack  - {deepwaterAttack}");
        }

        static bool GoForAttack(double navySub, double enemySub) {
            if (navySub > enemySub) {
                return true;
            } else return false;
        }

        static void DisplaySlice(int[,,] data, int z) {
            int y = 0;
            for ( int x = 0; x < data.GetLength(0) + 1; x++) {
                if (x == data.GetLength(0)) {
                    x = 0;
                    y++;
                    Console.WriteLine();
                }
                if (y == 10) {
                    break;
                }
                Console.Write($"{data[x, y, z]} ");
            }

        }
    }
}
