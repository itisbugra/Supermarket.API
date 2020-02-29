using AutoMapper;
using Supermarket.API.Attributes;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API
{
    [Injected]
    public class RandomDraughtPoolPickHandleService : IPoolPickHandleService
    {
        private readonly IPoolPickHandleRepository poolPickHandleRepository;

        private readonly IQuestionRepository questionRepository;

        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public RandomDraughtPoolPickHandleService(IPoolPickHandleRepository poolPickHandleRepository,
                                                  IQuestionRepository questionRepository,
                                                  IUnitOfWork unitOfWork,
                                                  IMapper mapper)
        {
            this.poolPickHandleRepository = poolPickHandleRepository;
            this.questionRepository = questionRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PoolPickHandle> Pick(User user,
                                               Category category,
                                               Dictionary<string, object> options)
        {
            var pickOptions = options != null ? mapper.Map<PickOptions>(options) : new PickOptions();

            var question = pickOptions.UniqueToUser ?
                await questionRepository.FindUntouchedRandomAsync(user) :
                await questionRepository.FindRandomAsync();

            if (question == null)
            {
                throw new UserHasNoViablePickException("User has no remaining unsolved questions.");
            }

            var handle = new PoolPickHandle
            {
                Picker = user,
                Question = question,
                AvailableFor = 300,
            };

            await poolPickHandleRepository.AddAsync(handle);
            await unitOfWork.CompleteAsync();

            return handle;
        }

        private class PickOptions
        {
            public bool UniqueToUser { get; set; } = false;
        }
    }
}
