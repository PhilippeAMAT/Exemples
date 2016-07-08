
namespace Travel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Genotype
    {
        public List<City> genes;
        private static Random random = new Random();

        public Genotype(bool initCity)
        {
            if (initCity)
            {
                this.genes = new List<City>
            {
                new City("Birmingham", 52.486125, -1.890507),
                new City("Bristol", 51.460852, -2.588139),
                new City("London", 51.512161, -0.116215),
                new City("Leeds", 53.803895, -1.549931),
                new City("Manchester", 53.478239, -2.258549),
                new City("Liverpool", 53.409532, -3.000126),
                new City("Hull", 53.751959, -0.335941),
                new City("Newcastle", 54.980766, -1.615849),
                new City("Carlisle", 54.892406, -2.923222),
                new City("Edinburgh", 55.958426, -3.186893),
                new City("Glasgow", 55.862982, -4.263554),
                new City("Cardiff", 51.488224, -3.186893),
                new City("Swansea", 51.624837, -3.94495),
                new City("Exeter", 50.726024, -3.543949),
                new City("Falmouth", 50.152266, -5.065556),
                new City("Canterbury", 51.289406, 1.075802)
            };

                this.genes.Randomize();
            }
            else
            {
                var newGenes = new List<City>
                {
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0),
                    new City("", 0.0, 0.0)
                };
                this.genes = newGenes;
            }
        }

        public void mutate()
        {
            var index1 = this.GetRandomNumber(0, this.genes.Count - 1);
            var index2 = this.GetRandomNumber(0, this.genes.Count - 1);

            var gene = this.genes[index1];
            this.genes[index1] = this.genes[index2];
            this.genes[index2] = gene;
        }

        private int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
