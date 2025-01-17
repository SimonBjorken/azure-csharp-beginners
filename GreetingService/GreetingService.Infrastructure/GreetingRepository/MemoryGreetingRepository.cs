﻿using GreetingService.Core.Entities;
using GreetingService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GreetingService.Infrastructure.GreetingRepository
{
    public class MemoryGreetingRepository : IGreetingRepository
    {
        private readonly IList<Greeting> _repository = new List<Greeting>();

        public async Task CreateAsync(Greeting greeting)
        {
            _repository.Add(greeting);
        }

        public async Task<Greeting> GetAsync(Guid id)
        {
            return _repository.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Greeting>> GetAsync()
        {
            return _repository;
        }

        public async Task<IEnumerable<Greeting>> GetAsync(string from, string to)
        {
            var greetings = await GetAsync();

            if (!string.IsNullOrWhiteSpace(from))
                greetings = greetings.Where(x => x.From.Equals(from, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(to))
                greetings = greetings.Where(x => x.To.Equals(to, StringComparison.OrdinalIgnoreCase));

            return greetings;
        }

        public async Task UpdateAsync(Greeting greeting)
        {
            var existingGreeting = _repository.FirstOrDefault(x => x.Id == greeting.Id);

            if (existingGreeting == null)
                throw new Exception($"Greeting with id: {greeting.Id} not found");

            existingGreeting.To = greeting.To;
            existingGreeting.From = greeting.From;
            existingGreeting.Message = greeting.Message;
        }
    }
}
