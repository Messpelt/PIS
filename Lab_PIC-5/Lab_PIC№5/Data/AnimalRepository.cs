using Lab_PIC_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_PIC_5.Data
{
    class AnimalRepository
    {
        public static List<AnimalCard> animalCards = new List<AnimalCard>
        {
            new AnimalCard(1, "Собака", "Женский", "Лабрадор", 40, "Длинная", "Рыжий",
                            "Висячие", "Длинный", "ID101", "Метка 2",
                            LocationCostReposiroty.locationCosts[0],
                            ActRepository.acts[0],
                            null),

            new AnimalCard(2, "Кот", "Мужской", "Британская", 30, "Короткая", "Черный",
                            "Прямые", "Короткий", "ID302", "Метка 1",
                            LocationCostReposiroty.locationCosts[0],
                            ActRepository.acts[1],
                            null),

            new AnimalCard(4, "Собака", "Женский", "Немецкая овчарка", 50, "Длинная", "Черно-серый",
                            "Висячие", "Длинный", "ID041", "Метка 4",
                            LocationCostReposiroty.locationCosts[1],
                            ActRepository.acts[2],
                            null),

            new AnimalCard(3, "Кот", "Мужской", "Сиамская", 25, "Короткая", "Серый",
                            "Прямые", "Длинный", "ID201", "Метка 3",
                            LocationCostReposiroty.locationCosts[0],
                            ActRepository.acts[2],
                            null),
        };

        public static void AddAnimalCard(AnimalCard animalCard)
        {
            animalCards.Add(animalCard);
        }
    }
}
