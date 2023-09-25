using Lab_PIC_5.Data;
using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Controllers
{
    class AnimalCardService
    {
        public static void AddAnimalCard(string[] animalCard)
        {
            var otpAnimalCard = new AnimalCard(
                AnimalRepository.animalCards.Max(x => x.IdAnimalCard) + 1,
                animalCard[0], animalCard[1], animalCard[2],
                int.Parse(animalCard[3]), animalCard[4], animalCard[5],
                animalCard[6], animalCard[7], animalCard[8], animalCard[9],
                LocationCostReposiroty.locationCosts[LocationCostReposiroty.locationCosts.FindIndex(x => x.IdLocation == int.Parse(animalCard[10]))],
                ActRepository.acts[ActRepository.acts.FindIndex(x => x.ActNumber == int.Parse(animalCard[11]))], null);

            AnimalRepository.AddAnimalCard(otpAnimalCard);
        }
    }
}
