using MonkeyFinder.Core.Entities;
using MonkeyFinder.Core.Interfaces;
using MonkeyFinder.Services.Dtos;
using MonkeyFinder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeyFinder.Services
{
    public class MonkeyService : IMonkeyService
    {
        private readonly IMonkeyRepository _monkeyRepository;
       
        public MonkeyService(IMonkeyRepository monkeyRepository)
        {
            _monkeyRepository = monkeyRepository;
        }

        public async Task<IEnumerable<MonkeyDto>> GetMonkeysAsync()
        {
            var monkeys = await _monkeyRepository.GetMonkeysAsync();

            var monkeyDtos = monkeys.Select(m => new MonkeyDto
            {
                Name = m.Name,
                Details = m.Details,
                Image = m.ImageUri,
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            });

            return monkeyDtos;
        }

        public async Task<IEnumerable<MonkeyDto>> SearchMonkeyByIdAsync(int id)
        {
            var monkeys = await _monkeyRepository.SearchMonkeyByIdAsync(id);

            var monkeyDtos = monkeys.Select(m => new MonkeyDto
            {
                Name = m.Name,
                Details = m.Details,
                Image = m.ImageUri,
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            });

            return monkeyDtos;

        }

        public async Task<IEnumerable<MonkeyDto>> AddMonkeysAsync(Monkey monkey)
        {
            var monkeys = await _monkeyRepository.AddMonkeysAsync(monkey);

            var monkeyDtos = monkeys.Select(m => new MonkeyDto
            {
                Name = m.Name,
                Details = m.Details,
                Image = m.ImageUri,
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            });

            return monkeyDtos; ;
        }


        public async Task<IEnumerable<MonkeyDto>> UpdateMonkeysAsync(Monkey monkey)
        {
            var monkeys = await _monkeyRepository.UpdateMonkeysAsync(monkey);

            var monkeyDtos = monkeys.Select(m => new MonkeyDto
            {
                Name = m.Name,
                Details = m.Details,
                Image = m.ImageUri,
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            });

            return monkeyDtos;

        }

        public async Task<IEnumerable<MonkeyDto>> DeleteMonkeysAsync(Monkey monkey)
        {
            var monkeys = await _monkeyRepository.DeleteMonkeysAsync(monkey);

            var monkeyDtos = monkeys.Select(m => new MonkeyDto
            {
                Name = m.Name,
                Details = m.Details,
                Image = m.ImageUri,
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            });

            return monkeyDtos;

        }
    }
}
