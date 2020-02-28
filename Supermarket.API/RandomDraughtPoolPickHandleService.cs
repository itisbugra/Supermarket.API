using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API
{
    public class RandomDraughtPoolPickHandleService : IPoolPickHandleService
    {
        private readonly IPoolPickHandleRepository poolPickHandleRepository;

        private readonly IQuestionRepository questionRepository;

        private readonly IUnitOfWork unitOfWork;

        public RandomDraughtPoolPickHandleService(IPoolPickHandleRepository poolPickHandleRepository,
                                                  IQuestionRepository questionRepository,
                                                  IUnitOfWork unitOfWork)
        {
            this.poolPickHandleRepository = poolPickHandleRepository;
            this.questionRepository = questionRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PoolPickHandle> Pick(User user,
                                               Category category,
                                               Dictionary<string, object> options)
        {
            var question = await questionRepository.FindRandomAsync();
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
    }
}
