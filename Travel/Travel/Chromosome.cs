
namespace Travel
{
    using System;

    public class Chromosome : IComparable<Chromosome>
    {
        public Genotype i_genotype;

        public double i_fitness;

        public Chromosome()
        {
            this.i_genotype = new Genotype(true);
            this.i_fitness = 0.0;
        }

        public void evaluate()
        {
            this.i_fitness = this.CalculateDistance();
        }

        int IComparable<Chromosome>.CompareTo(Chromosome objI)
        {
            Chromosome iToCompare = (Chromosome)objI;
            if (i_fitness < iToCompare.i_fitness)
            {
                return -1; //if I am less fit than iCompare return -1
            }
            else if (i_fitness > iToCompare.i_fitness)
            {
                return 1; //if I am fitter than iCompare return 1
            }
            return 0; // if we are equally return 0
        }

        private double CalculateDistance()
        {
            var distanceToTravel = 0.0;
            City previousCity = null;

            //run through each city in the order specified in the chromosome
            for (int index = 0; index < i_genotype.genes.Count; index++)
            {
                var currentCity = (City)i_genotype.genes[index];

                if (previousCity != null)
                {
                    var distance = previousCity.GetDistanceFromPosition(currentCity._Latitude,
                                                                        currentCity._Longitude);

                    distanceToTravel += distance;
                }

                previousCity = currentCity;
            }

            return distanceToTravel;
        }
    }
}
