
namespace Travel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Population
    {
        private List<Chromosome> pop;

        private int Number { get; set; }
    
        private static Random random = new Random();

        public Population(int populationNum)
        {
            this.Number = populationNum;
            this.pop = new List<Chromosome>();

            for (int i = 0; i < populationNum; i++)
            {
                var chromosome = new Chromosome();
                chromosome.evaluate();
                this.pop.Add(chromosome);
            }

            // Order list by fitness value
            this.pop.OrderByDescending(o => o.i_fitness);
        }

        public void evolve()
        {
            var howMany = this.pop.Count / 2;

            for (int i = 0; i < howMany; i++)
            {
                // Select random Chromosome
                Chromosome a = select(howMany);
                Chromosome b = select(howMany);

                //breed the two selected individuals
                Chromosome x = breed(a, b);

                //evaluate the new individual (grow)
                x.evaluate();

                //place the offspring in the lowest position in the population, thus  replacing the previously weakest offspring
                this.pop[i] = x;
            }

            //the fitter offspring will find its way in the population ranks
            this.pop = this.pop.OrderByDescending(o => o.i_fitness).ToList();
        }

        private Chromosome select(int min)
        {
            int which = GetRandomNumber(min, this.Number);
            return pop[which];
        }

        public Chromosome GetBestChromosome()
        {
            return this.pop[this.pop.Count-1];
        }


        public void WriteChromosome(int generation)
        {
            using (StreamWriter stream = File.AppendText("c:\\test1.txt"))
            {
                stream.WriteLine("------------------------");
                stream.WriteLine(generation);

                /*for (int index = 0; index < this.pop.Count; index++)
                {
                    stream.WriteLine(string.Format("{0} -> {1}", index, this.pop[index].i_fitness));
                }*/
                stream.WriteLine(string.Format("{0}", this.pop[this.pop.Count-1].i_fitness));

                stream.WriteLine("--------------------------");
            }
        }

        public void WriteResult()
        {
            using (StreamWriter stream = File.AppendText("c:\\test1.txt"))
            {
                stream.WriteLine("------------------------");
                foreach (var city in pop[pop.Count-1].i_genotype.genes)
                {
                    stream.WriteLine(city._Name);
                }

                stream.WriteLine("--------------------------");
            }
        }

        private Chromosome breed(Chromosome a, Chromosome b)
        {
            Chromosome c = new Chromosome();
            c.i_genotype = crossover(a.i_genotype, b.i_genotype);
            c.i_genotype.mutate();
            return c;
        }

        private Genotype crossover(Genotype a, Genotype b)
        {
            Genotype c = new Genotype(false);

            var conservedIndex = a.genes.Count / 3;

            // On conserve 30% des valeurs du père
            for (int i = 0; i < conservedIndex; i++)
            {
                    c.genes[i] = a.genes[i];
            }

            var index = conservedIndex;
            // On conserve 30% des valeurs du père
            for (int j = 0; j < b.genes.Count; j++)
            {
                if (!c.genes.Contains(b.genes[j]))
                {
                    c.genes[conservedIndex] = b.genes[j];
                    conservedIndex++;
                }               
            }

            return c;
        }

        private int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
