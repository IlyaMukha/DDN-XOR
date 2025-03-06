namespace SPR
{

    public class Neiron
    {
        public string Id { get; set; }
        public int Lvl { get; set; }
        public double Value { get; set; }
        public List<Sinops> sinopses { get; set; }
    }
    public class Sinops
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public double W { get; set; }
    }

    public static class Helper
    {
        public static void Print(Neiron[,] neirons)
        {
            for (int i = 0; i < neirons.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < neirons.GetUpperBound(1) + 1; j++)
                {
                    if (neirons[i, j] is not null)
                    {
                        Console.Write(neirons[i, j].Id + " ");
                        if (neirons[i, j].sinopses is not null)
                        {
                            foreach (var sinops in neirons[i, j].sinopses)
                            {
                                Console.Write($"({sinops.Id}->{sinops.ParentId})-{sinops.W}");
                            }
                        }
                        Console.Write("   " + "   |   ");
                    }
                    else
                    {
                        Console.Write("   " + "   |   ");

                    }
                }
                Console.WriteLine();
            }
        }

        public static double Sigmod(double value)
        {
            return 1.0f / (1.0f + (float)Math.Exp(-value));
        }

        public static Neiron[,] Create(int x, int y)
        {
            Neiron[,] neirons = new Neiron[x, y];

            int laeryrs = neirons.GetUpperBound(0) + 1;
            int width = neirons.GetUpperBound(1) + 1;

            for (int i = 0; i < laeryrs; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i != 2 || j != 0)
                    {
                        if (i != laeryrs - 1)
                        {
                            List<Sinops> tempSinopses = new List<Sinops>();
                            for (int k = 0; k < width; k++)
                            {
                                tempSinopses.Add(new Sinops()
                                {
                                    Id = $"{i}-{j} sin",
                                    ParentId = $"{i + 1}-{k}",
                                    W = 0.45
                                });
                            }
                            neirons[i, j] = new Neiron()
                            {
                                Id = $"{i}-{j}",
                                Lvl = i,
                                sinopses = tempSinopses
                            };
                        }
                        else
                        {
                            neirons[i, j] = new Neiron()
                            {
                                Id = $"{i}-{j}",
                                Lvl = i
                            };
                        }
                    }
                }
            }

            return neirons;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var neirons = Helper.Create(3, 2);

            Helper.Print(neirons);
        }
    }
}
